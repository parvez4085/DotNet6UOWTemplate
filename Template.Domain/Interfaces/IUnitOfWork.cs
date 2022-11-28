namespace Template.Domain.Interfaces;
 public interface IUnitOfWork
{
    Task<int> CommitAsync();
}