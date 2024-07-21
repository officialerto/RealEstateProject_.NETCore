using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    internal class NeighborhoodManager : GenericService<Neighborhood>
    {
        INeighborhoodRepository _neigh;

        public NeighborhoodManager(INeighborhoodRepository neigh)
        {
            _neigh = neigh;
        }

        public void Add(Neighborhood p)
        {
            _neigh.Add(p);
        }

        public void Delete(Neighborhood p)
        {
            _neigh.Delete(p);
        }

        public Neighborhood GetById(int id)
        {
            return _neigh.GetById(id);
        }

        public List<Neighborhood> List()
        {
            return _neigh.List();
        }

        public List<Neighborhood> List(Expression<Func<Neighborhood, bool>> filter)
        {
            return _neigh.List(filter);
        }

        public void Update(Neighborhood p)
        {
            _neigh.Update(p);
        }
    }
}
