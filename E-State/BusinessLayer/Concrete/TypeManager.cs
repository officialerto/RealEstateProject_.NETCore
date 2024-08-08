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
    public class TypeManager : TypeService
    {
        ITypeRepository _type;

        public TypeManager(ITypeRepository type)
        {
            _type = type;
        }



        public void Add(EntityLayer.Entities.Type p)
        {
            _type.Add(p);
        }

        public void Delete(EntityLayer.Entities.Type p)
        {
            _type.Delete(p);
        }

        public EntityLayer.Entities.Type GetById(int id)
        {
            return _type.GetById(id);
        }

        public List<EntityLayer.Entities.Type> List()
        {
            return _type.List();
        }

        public List<EntityLayer.Entities.Type> List(Expression<Func<EntityLayer.Entities.Type, bool>> filter)
        {
            return _type.List(filter);
        }

        public void Update(EntityLayer.Entities.Type p)
        {
            _type.Update(p);
        }
    }
}
