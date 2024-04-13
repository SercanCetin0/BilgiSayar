using Entities.ErrorModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controls
{
    public static class DataControl
    {

        public static void ControlNullData(object entity)
        {
            if (entity is null) { throw new ObjectEmptyDataException(); }
        }
        public static void ControlFoundData(object entity)
        {
            if (entity is null) { throw new ObjectNotFountException(); }
        }
    }
}
