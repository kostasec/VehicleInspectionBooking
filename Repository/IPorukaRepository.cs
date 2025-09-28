using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public interface IPorukaRepository:IRepository<Poruka>
    {
        void Update(Poruka poruka);
    }
}
