using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Neighborhood
    {
        [Key]
        public int NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }
        public bool Status { get; set; }
        public int DistrictId { get; set; }
        //public int Id { get; set; }

        //public virtual Advert Advert { get; set; }

        public virtual District District { get; set; }
    }
}
