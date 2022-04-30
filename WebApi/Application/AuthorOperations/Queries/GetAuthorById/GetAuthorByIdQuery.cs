using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;

namespace WebApi.Application.AuthorOperations.Commands.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorId {get;set;}
        private readonly IMapper _mapper;
        public GetAuthorByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle(){
            var author = _context.Authors.SingleOrDefault(a=>a.Id==AuthorId);

            if(author == null)
                throw new InvalidOperationException("Yazar bulunamamıştır.");

            AuthorDetailViewModel authorModel = _mapper.Map<AuthorDetailViewModel>(author);

            return authorModel;
        }
    }

    public class AuthorDetailViewModel{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}