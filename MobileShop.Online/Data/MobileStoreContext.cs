using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Online.Data
{
    public class MobileStoreContext : DbContext
    {
        public MobileStoreContext(DbContextOptions<MobileStoreContext> options)
            :base(options)
        {

        }
        public DbSet<Mobile> Mobiles { get; set; }
    }
}
