using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingMe.Data
{
    public class PingMeContext : DbContext
    {
        public PingMeContext(DbContextOptions<PingMeContext> options) : base(options) { }



    }
}
