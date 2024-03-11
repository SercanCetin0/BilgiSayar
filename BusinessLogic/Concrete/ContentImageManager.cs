using BusinessLogic.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ContentImageManager : IContentImageService
    {
        private readonly IContentImageDal _contentImageDal;

        public ContentImageManager(IContentImageDal contentImageDal)
        {
            _contentImageDal = contentImageDal;
        }

        public void Add(ContentImage contentImage)
        {
            _contentImageDal.Add(contentImage); 
        }

        public void Delete(ContentImage contentImage)
        {
            _contentImageDal.Delete(contentImage);  
        }

        public ContentImage Get(int id)
        {
            return _contentImageDal.Get(x=>x.Equals(id));
        }

        public List<ContentImage> GetAll()
        {
            return _contentImageDal.GetAll().ToList();
        }

        public void Update(ContentImage contentImage)
        {
            _contentImageDal.Update(contentImage);  
        }
    }
}
