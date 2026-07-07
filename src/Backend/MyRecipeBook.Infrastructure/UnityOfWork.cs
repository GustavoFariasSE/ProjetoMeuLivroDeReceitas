using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Infrastructure.DataAccess;

namespace MyRecipeBook.Infrastructure;
internal class UnityOfWork : IUnityOfWork
{
    private readonly MyRecipeBookDbContext _dbContext;  
    public UnityOfWork(MyRecipeBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
