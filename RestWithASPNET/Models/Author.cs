using RestWithASPNET.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET.Models
{
    [Table("authors")]
    public class Author : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("cpf")]
        public string Cpf { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
