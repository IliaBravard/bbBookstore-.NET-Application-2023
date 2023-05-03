using bbBookstore.Data.Base;
using bbBookstore.Data.ViewModels;
using bbBookstore.Models;

namespace bbBookstore.Data.Services
{
    public interface IBooksService:IEntityBaseRepository<Book>
    {
        Task<Book> GetBooksByIdAsync(int id);

        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();

        Task AddNewBookAsync(NewBookVM data);

        Task UpdateBookAsync(NewBookVM data);
    }
}
