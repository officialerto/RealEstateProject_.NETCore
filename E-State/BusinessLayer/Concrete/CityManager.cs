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
    public class CityManager : CityService
    {
        ICityRepository _cityRepository;

        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Add(City p)
        {
            p.Status = true;

            _cityRepository.Add(p);
        }

        public void Delete(City p)
        {
            var city = _cityRepository.GetById(p.CityId);
            city.Status = false;

            _cityRepository.Update(city);
        }

        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public List<City> List()
        {
            return _cityRepository.List();
        }

        public List<City> List(Expression<Func<City, bool>> filter)
        {
            return _cityRepository.List(filter);
        }

        public void Update(City p)
        {
            var city = _cityRepository.GetById(p.CityId);
            city.CityName = p.CityName;

            _cityRepository.Update(city);
        }
    }
}
