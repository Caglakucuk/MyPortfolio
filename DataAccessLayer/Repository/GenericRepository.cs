using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repository;

public class GenericRepository<T> : IGenericDal<T> where T:class
{
    private readonly AppDbContext c;

    public GenericRepository(AppDbContext context)
    {
        c = context;
    }
    
    public void Insert(T t)
    {
        c.Add(t);
        c.SaveChanges();
    }

    public void Update(T t)
    {
        c.Update(t);
        c.SaveChanges();
    }

    public void Delete(T t)
    {
        c.Remove(t);
        c.SaveChanges();
    }

    public List<T> GetList()
    {
        return c.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return c.Set<T>().Find(id);
    }
}