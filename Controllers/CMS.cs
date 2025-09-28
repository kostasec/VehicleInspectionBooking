
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PregledPlus.Data;
using PregledPlus.Models;
using PregledPlus.Repository;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Python.Runtime;
using NToastNotify;

namespace PregledPlus.Controllers
{
    public class CMS : Controller
    {
        private IUnitOfWork unitOfWork;
        private IToastNotification toast;

        public CMS(IUnitOfWork _unitOfWork, IToastNotification _toast)
        {
            toast = _toast;
            unitOfWork = _unitOfWork;
        }
        public IActionResult UslugaView()
        {
            return View("Usluge");
        }
        public IActionResult savePoruka(Poruka por)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.PorukaRepository.Add(por);
                unitOfWork.Save();
                toast.AddSuccessToastMessage("Poruka je uspesno dodata!");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                toast.AddErrorToastMessage("Doslo je do greske pri kreiranju poruke!");
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<string> getSessionToken()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double timestamp = (DateTime.UtcNow - unixEpoch).TotalSeconds;
            int timestampInSeconds = (int)timestamp;

            string apiKey = "381182";
            string privateKey = "80016d0ea304462b95ab9921c768adf9";

            string input = apiKey + privateKey;

            MD5 md5 = MD5.Create();

            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            string signature = sb.ToString();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.timetap.com/test/sessionToken?apiKey=" + apiKey + "&timestamp=" + timestampInSeconds + "&signature=" + signature)

            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var sessionToken = await response.Content.ReadAsStringAsync();
            JObject responseBody = JObject.Parse(sessionToken);

            return (string)responseBody["sessionToken"];
        }


        public async Task<OkResult> getInfo(string obj)
        {
            JArray jsonArray = JArray.Parse(obj);

            List<string> ime= new List<string>();
            List<string> prezime = new List<string>();
            List<string> email = new List<string>();
            List<string> brojTelefona = new List<string>();
            List<string> status = new List<string>();
            List<string> datum = new List<string>();
            List<string> registracija = new List<string>();
            IEnumerator<JToken> enumerator = jsonArray.GetEnumerator();
            Termin ter=new Termin(); 


            while (enumerator.MoveNext())
            {
                
                JObject property = (JObject)enumerator.Current;
                  
                        ime.Add(property["client"]["firstName"].ToString());
                        prezime.Add((string)property["client"]["lastName"]);
                        email.Add((string)property["client"]["emailAddress"]);
                        brojTelefona.Add((string)property["client"]["cellPhone"]);
                        status.Add((string)property["client"]["status"]);
                datum.Add((string)property["appointmentDateTimeClient"]);
                registracija.Add((string)property["client"]["homePhone"]);

           }
            int j = 1;

            for(int i=0;i<datum.Count;i++)
            {
                
                if (unitOfWork.TerminRepository.GetFirstOrDefault(x => x.datum == datum[i]) != null) { j++; continue; }
                else
                {
                    ter.id = j;
                    ter.ime = ime[i];
                    ter.prezime = prezime[i];
                    ter.datum = datum[i];
                    ter.email = email[i];
                    ter.brojTelefona = brojTelefona[i];
                    ter.status = status[i];
                    ter.reg_oznaka = registracija[i];
                    unitOfWork.TerminRepository.Add(ter);
                    unitOfWork.Save();
                    j++;
                }
            }

            return Ok();
            }

        public async Task<IActionResult> Index()
        {
            Task<string> task = getSessionToken();
            string sessionToken = await task;


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.timetap.com/test/appointmentList/report"),
                Headers =
                      {
                          { "Authorization", "Bearer "+sessionToken },
                      },
            };
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            await getInfo(body);

            return View("Index");

        }
    }
}
