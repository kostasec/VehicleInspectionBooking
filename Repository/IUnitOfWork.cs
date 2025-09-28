namespace PregledPlus.Repository
{
    public interface IUnitOfWork
    {
        ITerminRepository TerminRepository { get; }
        IUslugaRepository UslugaRepository { get; }
        INewsletterRepository NewsletterRepository { get; } 
        IApplicationUserRepository ApplicationUserRepository { get; }
        IPorukaRepository PorukaRepository { get; }
        void Save();
    }
}
