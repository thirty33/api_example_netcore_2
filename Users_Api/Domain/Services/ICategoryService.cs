using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Domain.Services.Comunication;
using Users_Api.Models;

namespace Users_Api.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        //Implementing method to Post (Category) Service
        Task<SaveCategoryResponse> SaveAsync(Category category);

        // Implementing method to update Category
        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);

        //Method to Delete Category Item
        Task<SaveCategoryResponse> DeleteAsync(int id);
    }
}
