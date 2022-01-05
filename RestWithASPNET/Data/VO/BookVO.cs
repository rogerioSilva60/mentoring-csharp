using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public AuthorVO Author { get; set; }
    }
}
