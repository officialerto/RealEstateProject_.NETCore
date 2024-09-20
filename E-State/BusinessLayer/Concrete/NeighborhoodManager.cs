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
    public class NeighborhoodManager : NeighborhoodService
    {
        INeighborhoodRepository _neigh;

        public NeighborhoodManager(INeighborhoodRepository neigh)
        {
            _neigh = neigh;
        }

        public void Add(Neighborhood p)
        {
            p.Status = true;

            _neigh.Add(p);
        }

        public void Delete(Neighborhood p)
        {
            var neigh = _neigh.GetById(p.NeighborhoodId);
            neigh.Status = false;

            _neigh.Update(neigh);
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
            var neigh = _neigh.GetById(p.NeighborhoodId);
            neigh.NeighborhoodName = p.NeighborhoodName;
            neigh.DistrictId = p.DistrictId;

            _neigh.Update(neigh);
        }
    }
}
