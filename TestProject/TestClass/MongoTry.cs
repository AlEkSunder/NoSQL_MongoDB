using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Concrete;
using DAL.Interface;
using TestProject.Entity;

namespace TestProject.TestClass
{
    public class MongoTry
    {
        private void FillTheCollection(IRepository<Book> repository)
        {
            repository.Insert(new Book
            {
                Author = "Konan Doil",
                Caption = "Adventures of Sherlock Holmes",
                NumberOfPages = 547,
                Year = 1892
            });

            repository.Insert(new Book
            {
                Author = "Konan Doil",
                Caption = "Memoirs of Sherlock Holmes",
                NumberOfPages = 542,
                Year = 1894
            });

            repository.Insert(new Book
            {
                Author = "Konan Doil",
                Caption = "Sign of Four",
                NumberOfPages = 325,
                Year = 1890
            });

            repository.Insert(new Book
            {
                Author = "Konan Doil",
                Caption = "The return of Sherlock Holmes",
                NumberOfPages = 415,
                Year = 1905
            });

        }

        private void Print(params Book[] collection)
        {
            Console.Clear();

            if (collection == null || !collection.Any() || collection.Any(n => n == null))
            {
                Console.WriteLine("Database is empty.");
                return;
            }

            foreach (var book in collection)
                Console.WriteLine($"Author: {book.Author}\n"
                                  + $"Caption: {book.Caption}\n"
                                  + $"Number of pages: {book.NumberOfPages}\n"
                                  + $"Year: {book.Year}\n"
                                  + $"---*---*---*---");
        }

        public void Run()
        {
            string connectionString = "mongodb://127.0.0.1:27017/Books";
            var repository =
                (IRepository<Book>)new MongoRepository<Book>(new ContextMongoDb(connectionString));

            this.FillTheCollection(repository);

            this.Print(repository.ListOfEntities.ToArray());

            var book = repository.Get(entity => entity.Year == 1894).FirstOrDefault();

            this.Print(book);

            book.Author = "Aleksey Beletsky";

            repository.Update(book);

            this.Print(repository.ListOfEntities.ToArray());

            repository.Delete(book);

            this.Print(repository.ListOfEntities.ToArray());

            var allBooks = repository.Get(entity => true);

            repository.Delete(allBooks.ToArray());

            this.Print(repository.ListOfEntities.ToArray());
        }
    }
}
