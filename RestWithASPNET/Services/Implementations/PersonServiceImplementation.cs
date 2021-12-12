using RestWithASPNET.Models;
using RestWithASPNET.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SqlServerContext _context;

        public PersonServiceImplementation(SqlServerContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var oldPerson = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (oldPerson != null)
            {
                try
                {
                    _context.Persons.Remove(oldPerson);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public Person Update(Person person)
        {
            if (Exists(person.Id))
            {
                var oldPerson = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
                if(oldPerson != null)
                {
                    try
                    {
                        _context.Entry(oldPerson).CurrentValues.SetValues(person);
                        _context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return person;
                }
                
            }

            return null;
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
