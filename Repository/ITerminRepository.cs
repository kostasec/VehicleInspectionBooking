using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public interface ITerminRepository:IRepository<Termin>
    {
        void Update(Termin termin);
    }
}
