using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class MapContext:DbContext
    {
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
    }
}
