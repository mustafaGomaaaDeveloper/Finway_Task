using Finway.extantion;
using System.Linq.Expressions;

namespace Finway.Interfaces
{
    public interface IBase<T> where T : class
    {
        GenericResponse<T> GetById(Guid id);

        GenericResponse<T> GetById(int id);

        GenericResponse<IEnumerable<T>> GetAll();

        GenericResponse<IEnumerable<T>> GetAll(string[] includes = null);

        GenericResponse<T> Insert(T entity);

        GenericResponse<T> Update(T entity);
        GenericResponse<IEnumerable<T>> InsertRange(IEnumerable<T> entities);

        GenericResponse<T> Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        GenericResponse<List<T>> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);

        //Soft Delete
        GenericResponse<T> SoftDelete(int iD, bool isActive, string columnName);


    }
}
