using PregledPlus.Data;

namespace PregledPlus.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITerminRepository TerminRepository {get;private set;}
        
        public IUslugaRepository UslugaRepository { get;private set;}  
        public INewsletterRepository NewsletterRepository { get;private set;}
        public IApplicationUserRepository ApplicationUserRepository { get;private set;}
        public IPorukaRepository PorukaRepository { get;private set;}   
        private DBContext db;

        public UnitOfWork(DBContext _db)
        {
            db = _db;
            TerminRepository=new TerminRepository(db);
            
            UslugaRepository = new UslugaRepository(db);
            NewsletterRepository = new NewsletterRepository(db);   
            ApplicationUserRepository = new ApplicationUserRepository(db);
            PorukaRepository=new PorukaRepository(db);

        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
