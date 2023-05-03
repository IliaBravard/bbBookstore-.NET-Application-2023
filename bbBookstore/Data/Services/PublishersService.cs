using bbBookstore.Data.Base;
using bbBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bbBookstore.Data.Services
{
    public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
    {
        private readonly ApplicationDbContext _context;

        public PublishersService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
