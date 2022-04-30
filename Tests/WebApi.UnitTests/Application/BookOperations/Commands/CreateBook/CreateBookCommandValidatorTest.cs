using System;
using AutoMapper;
using FluentAssertions;
using Tests.WebApi.UnitTests.TestSetup;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DBoperations;
using WebApi.Entities;
using Xunit;

namespace Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord of The Rings",0,0,0)]
        [InlineData("Lord of The Rings",0,0,1)]
        [InlineData("",0,0,1)]
        [InlineData("",100,0,1)]
        [InlineData("",100,0,1)]
        //[InlineData("Lord of The Rings",200,1,1)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId,int authorId)
        {
            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Model = new CreateBookModel(){
                Title=title ,PageCount=pageCount,PublishDate=DateTime.Now.Date.AddYears(-1),GenreId=genreId,AuthorId=authorId
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }

        [Fact]
        public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError(){

            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Model = new CreateBookModel(){
                Title="Lord of The Rings" ,PageCount=500,PublishDate=DateTime.Now.Date,GenreId=1,AuthorId=1
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError(){

            CreateBookCommand command = new CreateBookCommand(null,null);
            command.Model = new CreateBookModel(){
                Title="Lord of The Rings" ,PageCount=500,PublishDate=DateTime.Now.Date.AddYears(-2),GenreId=1,AuthorId=1
            };

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Equals(0);
        }

        
    }
}