using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {

            var author = _context.Authors.SingleOrDefault(a => a.FirstName == Model.FirstName && a.LastName == Model.LastName && a.DateOfBirth.ToString("dd/MM/yyyy") == Model.DateOfBirth);
            if (author != null)
                throw new InvalidOperationException("Girilen yazar zaten mevcuttur.");

            author = new Author();
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();


        }
    }

    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}