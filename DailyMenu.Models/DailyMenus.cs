using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DailyMenu.Models
{
    public class DailyMenus
    {
        public int ID { get; set; }
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]

        public Business Business { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public string MenuDescription { get; set; }

        public bool IsDeleted { get; set; }
    }
}
