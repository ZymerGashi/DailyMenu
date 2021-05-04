using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DailyMenu.Models
{
    public class MenuItem
    {

        public int ID { get; set; }
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]

        public Menu Menu { get; set; }

        public bool Drink { get; set; }

        public bool Food { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool IsDeleted { get; set; }
    }
}
