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
    public class EfSituationRepository : GenericRepository<Situation, DataContext>, ISituationRepository
    {
        private DataContext context;

        public EfSituationRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
