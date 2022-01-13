using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Business.Implementations
{
    public class AuthorBusinessImplementation : IAuthorBusiness
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorConverter _converter;

        public AuthorBusinessImplementation(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _converter = new AuthorConverter();
        }

        public List<AuthorVO> FindAll()
        {
            return _converter.Parse(_authorRepository.FindAll());
        }
    }
}
