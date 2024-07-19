using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfNeighborhoodRepository : GenericRepository<Neighborhood, DataContext>, INeighborhoodRepository
    {
        private DataContext context;

        public EfNeighborhoodRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
