﻿using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRespository
    {
        private MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context) {
            _context = context;
        }


        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));

        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return null;
            }
            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return person;
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(x=>x.Id.Equals(id));
        }

    }
}