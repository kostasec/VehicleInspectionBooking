using PregledPlus.Data;
using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public class TerminRepository : Repository<Termin>, ITerminRepository
    {
        private DBContext db;
        
        public TerminRepository(DBContext _db) : base(_db)
        {
            db = _db;
        }
        public void Update(Termin termin)
        {
            db.Update(termin);
        }
    }
}
