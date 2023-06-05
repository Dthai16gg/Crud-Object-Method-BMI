namespace AppData.Responstories;

public interface IRespon<T>
{
    public string Create(T entity);
    public string Update(T entity);
    public string Delete(T entity);
    public T GetOne(Guid id);
    public IEnumerable<T> GetAll();
}