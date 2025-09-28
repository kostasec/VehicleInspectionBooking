using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public interface IUslugaRepository : IRepository<Usluga>
    {
        void Update(Usluga usluga);
    }
}
