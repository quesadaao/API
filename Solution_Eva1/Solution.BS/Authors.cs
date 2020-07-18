using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DAL.EF;
using ent = Solution.DO.Objects;
using Solution.DO.Interfases;
using Solution.DAL;
using Solution.Maps;
using System.Linq.Expressions;
using AutoMapper;


namespace Solution.BS
{
    public class Authors : ICRUD<ent.Authors2>
    {
        private DAL.Authors _dal = new DAL.Authors();
        public void Delete(ent.Authors2 t)
        {
            var _ent = Mapper.Map<ent.Authors2, data.authors2>(t);
            _dal.Delete(_ent);
        }

        public IEnumerable<ent.Authors2> GetAll()
        {
            var t = _dal.GetAll();
            var _ent = Mapper.Map<IEnumerable<data.authors2>, IEnumerable<ent.Authors2>>(t);
            return _ent;
        }

        public ent.Authors2 GetOneById(int id)
        {
            var t = _dal.GetOneById(id);
            var _ent = Mapper.Map<data.authors2, ent.Authors2>(t);
            return _ent;
        }

        public void Insert(ent.Authors2 t)
        {
            var _ent = Mapper.Map<ent.Authors2, data.authors2>(t);
            _dal.Insert(_ent);
        }

        public IEnumerable<ent.Authors2> SearchByFirstName(string FirstName)
        {
            IEnumerable < data.authors2> t = _dal.SearchByFirstName(FirstName);
            var _ent = Mapper.Map< IEnumerable<data.authors2>, IEnumerable<ent.Authors2>>(t);
            return _ent;
        }

        public IEnumerable<ent.Authors2> Search(Expression<Func<ent.Authors2, bool>> predicado)
        {
            return null;
        }

        public void Updated(ent.Authors2 t)
        {
            var _ent = Mapper.Map<ent.Authors2, data.authors2>(t);
            _dal.Updated(_ent);
        }
    }
}
