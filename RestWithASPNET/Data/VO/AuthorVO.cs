using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.VO
{
    public class AuthorVO
    {
        public long Id { get; set; }
        public string  Name { get; set; }
        public string Cpf { get; set; }

        public List<BookAuthorVO> Books { get; set; }
    }
}
