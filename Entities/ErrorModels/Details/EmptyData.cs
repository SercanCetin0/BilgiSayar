using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ErrorModels.Details
{
    public abstract class EmptyData : Exception
    {
        protected EmptyData(string message) : base(message)
        {

        }

    }
}
