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
    public class EfCityRepository : GenericRepository<City, DataContext>, ICityRepository
    {
        private DataContext context;

        public EfCityRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
