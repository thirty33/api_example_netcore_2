using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Users_Api.Domain.Repositories
{
    /// <summary>
    /// Unit of Work Pattern
    /// consists of a class that receives our AppDbContext instance as a dependency and exposes
    /// methods to start, complete or abort transactions.
    /// </summary>
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
