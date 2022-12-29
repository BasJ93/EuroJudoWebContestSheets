using EuroJudoWebContestSheets.Database.Models;

namespace EuroJudoWebContestSheets.Database.Repositories.Interfaces;

public interface IGenericCrudRepository<T> where T : BaseIdEntity
{
    Task<IList<T>?> All(CancellationToken ctx = default);

    Task<T?> GetById(int id, CancellationToken ctx = default);

    Task Insert(T value, CancellationToken ctx = default);

    Task<T?> Update(T value, CancellationToken ctx = default);

    Task<bool> Delete(T value, CancellationToken ctx = default);
}