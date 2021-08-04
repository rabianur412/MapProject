using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodId { get; set; }
        [StringLength(100)]
        public string NeighborhoodName { get; set; }
        public string NeighborhoodCoordinate { get; set; }
        public ICollection<Gate> Gates { get; set; }
    }
}
