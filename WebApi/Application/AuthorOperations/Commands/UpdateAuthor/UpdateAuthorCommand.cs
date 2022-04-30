using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    { 
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public int AuthorId {get;set;}
        public UpdateAuthorModel Model {get;set;}

        public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var author = _context.Authors.SingleOrDefault(a=>a.Id==AuthorId);

            if(author is null)
            throw new InvalidOperationException("Güncellenecek yazar bulunamamıştır.");

             author.FirstName = String.IsNullOrEmpty(Model.FirstName) ? author.FirstName : Model.FirstName;
             author.LastName = String.IsNullOrEmpty(Model.LastName) ? author.LastName : Model.LastName;
             author.DateOfBirth = String.IsNullOrEmpty(Model.DateOfBirth) ? author.DateOfBirth : Convert.ToDateTime(Model.DateOfBirth);

            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}