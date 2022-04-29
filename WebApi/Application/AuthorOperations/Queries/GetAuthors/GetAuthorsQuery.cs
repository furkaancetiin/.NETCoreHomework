using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors{
    public class GetAuthorsQuery{
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public List<AuthorsViewModel> Handle(){
            var authors = _context.Authors.OrderBy(a=>a.Id);
            

            List<AuthorsViewModel> authorsModel = _mapper.Map<List<AuthorsViewModel>>(authors);

            return authorsModel;

        }
    }

    public class AuthorsViewModel{       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}