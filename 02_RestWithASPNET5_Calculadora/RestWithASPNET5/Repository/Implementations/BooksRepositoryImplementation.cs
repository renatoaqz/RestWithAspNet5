using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Repository.Implementations
{
    public class BooksRepositoryImplementation : IBooksRepository
    {
        private MySqlContext _context;

        public BooksRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Books Create(Books book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return book;
        }

        public Books Update(Books book)
        {
            if (!Exists(book.Id))
            {
                return null;
            }
            var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(x => x.Id.Equals(id));
        }

        public List<Books> FindAll()
        {
            return _context.Books.ToList();
        }

        public Books FindByID(long id)
        {
            return _context.Books.SingleOrDefault(x => x.Id.Equals(id));
        }

        
    }
}
