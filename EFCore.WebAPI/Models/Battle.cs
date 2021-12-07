using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    [Table("battle")]
    public class Battle
    {
        public int Id { get; set; }
        [Column("name")]
        public string  Name { get; set; }
        public string Description { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<HeroBattle> HeroBattles { get; set; }
    }
}
