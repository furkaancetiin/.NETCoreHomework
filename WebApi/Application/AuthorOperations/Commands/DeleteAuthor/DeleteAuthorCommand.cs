using System;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _context;

        public int AuthorId { get; set; }

        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;

        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == AuthorId);
            var books = _context.Books.Where(b => b.AuthorId == AuthorId).ToList();

            if (author is null)
                throw new InvalidOperationException("Silenecek yazar bulunamamıştır.");

            if (books.Count > 0)
                throw new InvalidOperationException("Kitabı yayında olan yazar silinemez. Öncelikle kitap silinmeli, daha sonra yazar silinebilir.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}