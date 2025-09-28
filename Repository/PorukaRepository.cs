using PregledPlus.Data;
using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public class PorukaRepository:Repository<Poruka>,IPorukaRepository
    {
        private DBContext db;

        public PorukaRepository(DBContext _db) : base(_db)
        {
            db = _db;
        }
        public void Update(Poruka usluga)
        {
            db.Update(usluga);
        }
    }
}
