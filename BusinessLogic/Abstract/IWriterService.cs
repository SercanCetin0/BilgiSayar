using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IWriterService
    {

        List<Writer> GetAll();
        Writer Get(int id);
        Writer GetWriterByUsername(string username);
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);
    }
}
