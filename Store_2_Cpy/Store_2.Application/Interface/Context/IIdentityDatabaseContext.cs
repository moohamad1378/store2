using Microsoft.EntityFrameworkCore;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Interface.Context
{
    public interface IIdentityDatabaseContext
    {
        DbSet<User> Users { get; set; }
    }
}
