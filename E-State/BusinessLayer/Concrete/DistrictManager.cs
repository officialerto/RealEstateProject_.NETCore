using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DistrictManager : DistrictService
    {
        IDistrictRepository _districtRepository;

        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }



        public void Add(District p)
        {
            p.Status = true;

            _districtRepository.Add(p);
        }

        public void Delete(District p)
        {
            var delete = _districtRepository.GetById(p.DistrictId);
            delete.Status = false;

            _districtRepository.Update(delete);
        }

        public District GetById(int id)
        {
            return _districtRepository.GetById(id);
        }

        public List<District> List()
        {
            return _districtRepository.List();
        }

        public List<District> List(Expression<Func<District, bool>> filter)
        {
            return _districtRepository.List(filter);
        }

        public void Update(District p)
        {
            var district = _districtRepository.GetById(p.DistrictId);

            district.DistrictName = p.DistrictName;
            district.CityId = p.CityId;


            _districtRepository.Update(district);
        }
    }
}
