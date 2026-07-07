namespace MyRecipeBook.Domain.Repositories;
public interface IUnityOfWork
{
    Task Commit();
}
