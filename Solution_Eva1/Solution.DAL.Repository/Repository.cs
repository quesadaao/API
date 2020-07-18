using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Solution.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        public Repository(DbContext context)
        {
            dbContext = context;
        }

        public IQueryable<T> AsQueryble()
        {
            return dbContext.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
            //dbContext.Dispose();
        }

        //public void Delete1(T entity)
        //{
        //    try
        //    {
        //        //if (dbContext.Entry<T>(entity).State == EntityState.Detached)
        //        //{
        //        //    dbContext.Set<T>().Add(entity);
        //        //}
        //        //dbContext.Entry<T>(entity).State = EntityState.Deleted;

        //        if (entity == null)
        //        {
        //            throw new ArgumentNullException("entity");
        //        }

        //        dbContext.Set<T>().Remove(entity);
        //    }
        //    catch (Exception ee)
        //    {
        //        dbContext.Dispose();
        //        throw;
        //    }


        //}

        public void Delete(T entity)
        {
            try
            {
                DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
                DbSet<T> DbSet = dbContext.Set<T>();
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    DbSet.Attach(entity);
                    DbSet.Remove(entity);
                }
            }
            catch (Exception ee)
            {
                dbContext.Dispose();
                throw;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var entity = GetOneByID(id);
                if (entity == null) return; // not found; assume already deleted.
                Delete(entity);
            }
            catch (Exception ee)
            {
                dbContext.Dispose();
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetOne(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado).FirstOrDefault();
        }

        public T GetOneByID(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {

            try
            {
                if (dbContext.Entry<T>(entity).State == EntityState.Detached)
                {
                    dbContext.Entry<T>(entity).State = EntityState.Added;
                }
                else
                {
                    dbContext.Set<T>().Add(entity);
                }

            }
            catch (Exception)
            {
                dbContext.Dispose();
                throw;
            }
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicado)
        {
            return dbContext.Set<T>().Where(predicado);
        }

        public void Updated(T entity)
        {
            try
            {
                if (dbContext.Entry<T>(entity).State == EntityState.Detached)
                {
                    dbContext.Set<T>().Attach(entity);
                }
                dbContext.Entry<T>(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                dbContext.Dispose();
                throw;
            }

        }
    }
}
