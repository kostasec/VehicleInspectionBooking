using PregledPlus.Data;
using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public class UslugaRepository:Repository<Usluga>, IUslugaRepository
    {
        private DBContext db;

        public UslugaRepository(DBContext _db) : base(_db)
        {
            db = _db;
        }
        public void Update(Usluga usluga)
        {
            db.Update(usluga);
        }
    }
}
