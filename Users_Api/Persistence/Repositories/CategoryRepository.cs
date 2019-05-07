using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users_Api.Domain.Repositories;
using Users_Api.Models;
using Users_Api.Persistence.Contexts;

namespace Users_Api.Persistence.Repositories
{
    //in-memory collection of objects
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        //for post (Category) implementation
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        //Find a Category Item into DB
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // Update a Category Item into DB
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        // Delete a Category into DB
        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
