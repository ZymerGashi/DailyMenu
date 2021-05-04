using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DailyMenu.Models
{
    public class Business
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public Category Category { get; set; }

        public int? CityId { get; set; }

        [ForeignKey("CityId")]

        public City City { get; set; }

        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]

        public ApplicationUser ApplicationUser { get; set; }

        public string MapPositionCoordinates { get; set; }

        public int MenuId { get; set; }

        [ForeignKey("MenuId")]

        public Menu Menu { get; set; }

        public bool IsDeleted { get; set; }
    }
}
