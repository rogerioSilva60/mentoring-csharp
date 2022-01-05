using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Implementations
{
    public class AuthorConverter : IParser<AuthorVO, Author>, IParser<Author, AuthorVO>
    {
        public Author Parse(AuthorVO origin)
        {
            if (origin == null) return null;
            return new Author
            {
                Id= origin.Id,
                Cpf= origin.Cpf,
                Name= origin.Name
            };
        }

        public AuthorVO Parse(Author origin)
        {
            if (origin == null) return null;
            return new AuthorVO
            {
                Id = origin.Id,
                Cpf = origin.Cpf,
                Name = origin.Name
            };
        }

        public List<Author> Parse(List<AuthorVO> origins)
        {
            var list = origins.Select(item => Parse(item)).ToList();
            return list;
        }

        public List<AuthorVO> Parse(List<Author> origins)
        {
            var list = origins.Select(item => Parse(item)).ToList();
            return list;
        }
    }
}
