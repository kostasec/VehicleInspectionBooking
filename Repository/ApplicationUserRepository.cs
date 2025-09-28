using PregledPlus.Data;
using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private DBContext db;

        public ApplicationUserRepository(DBContext _db) : base(_db)
        {
            db = _db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            db.Update(applicationUser);
        }
    }
}
