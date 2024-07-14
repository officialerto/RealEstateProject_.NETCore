using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Advert
    {
        public Advert()
        {
            Images = new List<Images>();
        }

        [Key]
        public int Id { get; set; }
        public string AdvertTitle { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Garage { get; set; }
        public bool Garden { get; set; }
        public bool FirePlace { get; set; }
        public bool Furniture { get; set; }
        public bool Pool { get; set; }
        public bool Teras { get; set; }
        public bool AirConditioner { get; set; }
        public int NumberOfRooms { get; set; }
        public int BathroomNumbers { get; set; }
        public bool Credit { get; set; }
        public int Area { get; set; }
        public DateTime AdvertDate { get; set; }
        public int Floor { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int NeighbourhoodId { get; set; }
        public int SituationId { get; set; }
        public int TypeId { get; set; }
        public string UserAdminId { get; set; }
        public bool Status { get; set; }

        [NotMapped]
        public IEnumerable<IFormFile> Image { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }
        public virtual Type Type { get; set; }
        public virtual UserAdmin UserAdmin { get; set; }
        public virtual List<Images> Images { get; set; }
    }
}
