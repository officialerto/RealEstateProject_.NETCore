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
    public class EfAdvertRepository : GenericRepository<Advert, DataContext>, IAdvertRepository
    {
        private DataContext context;

        public EfAdvertRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
