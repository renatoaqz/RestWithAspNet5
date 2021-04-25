using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5.Business.Implementations
{
    public class BooksBusinnesImplementation : IBooksBusinnes
    {
        private readonly IRepository<Books> _repository;

        public BooksBusinnesImplementation(IRepository<Books> repository)
        {
            _repository = repository;
        }


        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindByID(long id)
        {
            return _repository.FindByID(id);

        }
        public Books Create(Books book)
        {
            return _repository.Create(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Books Update(Books book)
        {
            return _repository.Update(book);
        }
    }
}
