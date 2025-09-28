using PregledPlus.Models;

namespace PregledPlus.Repository
{
    public interface INewsletterRepository : IRepository<Newsletter>
    {
        void Update(Newsletter newsletter);
    }
}
