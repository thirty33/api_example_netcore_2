using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Models;

namespace Users_Api.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();

        //Post (Category) Service Implementation
        Task AddAsync(Category category);

        // to return the current data from the database, if it exists.
        Task<Category> FindByIdAsync(int id);

        //to update it into our DB.
        void Update(Category category);

        //To delete into our DB.
        void Remove(Category category);
    }
}
