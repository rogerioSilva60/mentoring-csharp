using RestWithASPNET.Data.Converter.Contract;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Data.Converter.Implementations
{

    public class AuthorBookConverter : IParser<AuthorBookVO, Author>, IParser<Author, AuthorBookVO>
    {
        public AuthorBookVO Parse(Author origin)
        {
            return new AuthorBookVO
            {
                Id= origin.Id,
                Name= origin.Name,
                Cpf= origin.Cpf
            };
        }

        public Author Parse(AuthorBookVO origin)
        {
            return new Author
            {
                Id = origin.Id,
                Name = origin.Name,
                Cpf = origin.Cpf
            };
        }

        public List<AuthorBookVO> Parse(List<Author> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }

        public List<Author> Parse(List<AuthorBookVO> origins)
        {
            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
