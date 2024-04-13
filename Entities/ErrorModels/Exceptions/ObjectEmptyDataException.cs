using Entities.ErrorModels.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModels.Exceptions
{
    public class ObjectEmptyDataException:EmptyData
    {
        public ObjectEmptyDataException():base("Boş Girdi Mevcut.")
        {
            
        }
    }
}
