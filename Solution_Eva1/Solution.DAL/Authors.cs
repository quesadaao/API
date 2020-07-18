using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DAL.EF;

namespace Solution.DAL
{
    public class Authors : ICRUD<data.authors2>
    {
        private Repository<data.authors2> _repository = new Repository<data.authors2>(new TinEntities());
        public void Delete(data.authors2 t)
        {
            try
            {
                //t.PhotoPath = true.ToString();
                //_repository.Updated(t);

                _repository.Delete(t.au_id);
                _repository.Commit();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<data.authors2> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public data.authors2 GetOneById(int id)
        {
            try
            {
                return _repository.GetOneByID(id);
            }
            catch (Exception ee)
            {
                throw;
            };
        }

        public void Insert(data.authors2 t)
        {
            try
            {
                _repository.Insert(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<data.authors2> SearchByFirstName(string FirstName)
        {
            try
            {
                return _repository.Search(p => p.au_fname.Contains(FirstName));
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public IEnumerable<data.authors2> Search(Expression<Func<data.authors2, bool>> predicado)
        {
            try
            {
                return _repository.Search(predicado);
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public void Updated(data.authors2 t)
        {
            try
            {
                _repository.Updated(t);
                _repository.Commit();
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
