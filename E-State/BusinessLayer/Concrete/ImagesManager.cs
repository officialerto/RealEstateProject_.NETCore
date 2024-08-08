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
    public class ImagesManager : ImagesService
    {
        IImagesRepository _imagesRepository;

        public ImagesManager(IImagesRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }

        public void Add(Images p)
        {
            _imagesRepository.Add(p);
        }

        public void Delete(Images p)
        {
            _imagesRepository.Delete(p);
        }

        public Images GetById(int id)
        {
            return _imagesRepository.GetById(id);
        }

        public List<Images> List()
        {
            return _imagesRepository.List();
        }

        public List<Images> List(Expression<Func<Images, bool>> filter)
        {
            return _imagesRepository.List(filter);
        }

        public void Update(Images p)
        {
            _imagesRepository.Update(p);
        }
    }
}
