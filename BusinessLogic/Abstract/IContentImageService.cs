using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IContentImageService
    {
        List<ContentImage> GetAll();
        ContentImage Get(int id);

        void Add(ContentImage contentImage);
        void Update(ContentImage contentImage);
        void Delete(ContentImage contentImage);
    }
}
