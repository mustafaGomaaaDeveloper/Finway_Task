using Finway.extantion;
using Finway.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Finway.Services
{
    public class Base<T> : IBase<T> where T : class
    {
        protected readonly DbContext _context;
        public Base(DbContext context)
        {
            _context = context;
        }


        public GenericResponse<T> SoftDelete(int iD, bool isActive, string columnName)
        {
            try
            {
                var queryResult = _context.Set<T>().Find(iD);

                if (queryResult != null)
                {

                    queryResult.GetType().GetProperty(columnName).SetValue(queryResult, isActive);

                    return new GenericResponse<T>() { ResponseObject = queryResult, Status = EnumStatus.Success };
                }
                return new GenericResponse<T>() { ResponseObject = queryResult, Status = EnumStatus.Fail };

            }
            catch (Exception ex)
            {

                return new GenericResponse<T>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail }; throw;
            }

        }

        public GenericResponse<T> Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var incluse in includes)
                        query = query.Include(incluse);

                var returnObj = query.SingleOrDefault(criteria);
                return new GenericResponse<T>()
                {
                    ResponseObject = returnObj,
                    Status = returnObj == null ? EnumStatus.Fail : EnumStatus.Success,
                    ResponseText = returnObj == null ? EnumStatus.Fail.ToString() : EnumStatus.Success.ToString()
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<T>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<List<T>> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var include in includes)
                        query = query.Include(include);

                return new GenericResponse<List<T>>() { ResponseObject = query.Where(criteria).ToList(), Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<List<T>>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<IEnumerable<T>> GetAll()
        {
            try
            {
                return new GenericResponse<IEnumerable<T>>() { ResponseObject = _context.Set<T>().ToList(), Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<T>>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<IEnumerable<T>> GetAll(string[] includes = null)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                if (includes != null)
                    foreach (var incluse in includes)
                        query = query.Include(incluse);

                var returnObj = query.ToList();

                return new()
                {
                    ResponseObject = returnObj,
                    Status = returnObj == null ? EnumStatus.Fail : EnumStatus.Success,
                    ResponseText = returnObj == null ? EnumStatus.Fail.ToString() : EnumStatus.Success.ToString()
                };
            }
            catch (Exception ex)
            {
                return new() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<T> GetById(Guid id)
        {
            try
            {
                return new GenericResponse<T>() { ResponseObject = _context.Set<T>().Find(id), Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<T>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }
        public GenericResponse<T> GetById(int id)
        {
            try
            {
                return new GenericResponse<T>() { ResponseObject = _context.Set<T>().Find(id), Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<T>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }

        public GenericResponse<T> Insert(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return new GenericResponse<T>() { ResponseObject = entity, Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<T>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }
        public GenericResponse<T> Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
                return new GenericResponse<T>() { ResponseObject = entity, Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<T>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }
        public GenericResponse<IEnumerable<T>> InsertRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().AddRange(entities);
                return new GenericResponse<IEnumerable<T>>() { ResponseObject = entities, Status = EnumStatus.Success };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<T>>() { ResponseText = ex.Message + " " + ex.Source, Status = EnumStatus.Fail };
            }
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>().AsNoTracking();
        }
    }
}
