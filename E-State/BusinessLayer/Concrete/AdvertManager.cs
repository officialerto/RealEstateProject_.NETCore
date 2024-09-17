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
    public class AdvertManager : AdvertService
    {
        IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }



        public void Add(Advert p)
        {
            p.Status = true;
            p.AdvertDate = DateTime.Now;

            _advertRepository.Add(p);
        }

        public void Delete(Advert p)
        {
            var delete = _advertRepository.GetById(p.Id);
            p.Status = false;
            _advertRepository.Update(delete);
        }

        public void FullDelete(Advert p)
        {
            var delete = _advertRepository.GetById(p.Id);
            _advertRepository.FullDelete(delete);
        }

        public Advert GetById(int id)
        {
            return _advertRepository.GetById(id);
        }

        public List<Advert> List()
        {
            return _advertRepository.List();
        }

        public List<Advert> List(Expression<Func<Advert, bool>> filter)
        {
            return _advertRepository.List(filter);
        }

        public void RestoreDelete(Advert p)
        {
            var delete = _advertRepository.GetById(p.Id);
            p.Status = true;
            _advertRepository.Update(delete);
        }

        public void Update(Advert p)
        {
            _advertRepository.Update(p);
        }
    }
}
