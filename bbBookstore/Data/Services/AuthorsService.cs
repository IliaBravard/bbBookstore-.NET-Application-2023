using bbBookstore.Data.Base;
using bbBookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace bbBookstore.Data.Services
{
    public class AuthorsService : EntityBaseRepository<Author>, IAuthorsService
    {
        private readonly ApplicationDbContext _context;

        public AuthorsService(ApplicationDbContext context) : base(context) { }
    }
}
