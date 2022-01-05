using RestWithASPNET.Models.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Models
{
    [Table("book")]
    public class Book : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("author_id")]
        public long? AuthorId { get; set; }        
        public Author Author { get; set; }
    }
}
