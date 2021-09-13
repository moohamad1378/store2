using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string entityname,int key)
            :base($"Entity {entityname} With Key {key} Was Not Found.")
        {

        }
    }
}
