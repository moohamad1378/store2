using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditableAttribute:Attribute
    {

    }
}
