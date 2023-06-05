using AppData.DbContext;
using Microsoft.EntityFrameworkCore;

namespace AppData.Responstories;

public class Respon<T> : IRespon<T> where T : class
{
    private readonly Db_context _dbContext;
    private readonly DbSet<T> _dbSet;

    public Respon()
    {
    }

    public Respon(Db_context dbContext, DbSet<T> dbSet)
    {
        _dbContext = dbContext;
        _dbSet = dbSet;
    }

    public string Create(T entity)
    {
        try
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return "Them thanh cong";
        }
        catch (Exception e)
        {
            return e.Message;
            throw;
        }
    }

    public string Update(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return "Sua thanh cong";
        }
        catch (Exception e)
        {
            return e.Message;
            throw;
        }
    }

    public string Delete(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return "Xoa thanh cong";
        }
        catch (Exception e)
        {
            return e.Message;
            throw;
        }
    }

    public T GetOne(Guid id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
}