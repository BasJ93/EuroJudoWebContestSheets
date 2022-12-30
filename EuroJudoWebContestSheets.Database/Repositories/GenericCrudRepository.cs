using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Database.Repositories;

public class GenericCrudRepository<T> : IGenericCrudRepository<T> where T : BaseIdEntity
{
    protected readonly ContestSheetDbContext Db;
    protected DbSet<T> Entities;
    
    public GenericCrudRepository(ContestSheetDbContext db)
    {
        Db = db;
        Entities = Db.Set<T>();
    }
    
    public async Task<IList<T>?> All(CancellationToken ctx = default)
    {
        return Entities.AsNoTracking().ToList();
    }
    
    public async Task<T?> GetById(int id, CancellationToken ctx = default)
    {
        return await Entities.SingleOrDefaultAsync(x => x.Id == id, ctx);
    }

    public async Task<T> Insert(T value, CancellationToken ctx = default)
    {
        await Entities.AddAsync(value, ctx);
        await Db.SaveChangesAsync(ctx);

        return value;
    }

    public async Task<T?> Update(T value, CancellationToken ctx = default)
    {
        await Db.SaveChangesAsync(ctx);
        return value;
    }

    public async Task<bool> Delete(T value, CancellationToken ctx = default)
    {
        Entities.Remove(value);
        int changes = await Db.SaveChangesAsync(ctx);
        return changes == 1;
    }
}