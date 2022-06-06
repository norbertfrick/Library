using Library.Core.Abstractions;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.UI.Base;
using Library.UI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI.Pages
{
    internal class AddTitlePage : MenuPageBase
    {
        private const string PAGE_HEADER = "Add Title";
        public AddTitlePage(Application app) : base(PAGE_HEADER, app)
        {
            this._bookRepository = app.Services.GetService<IBookRepository>();
            this._dvdRepository = app.Services.GetService<IDvdRepository>();

            InitializeOptions();
        }

        private IBookRepository _bookRepository;
        private IDvdRepository _dvdRepository;

        public override void Display()
        {
            base.Display();

            this.Menu.Display();
        }

        private void AddTitle(eTitleType titleType)
        {
            var author = InputHelper.ReadString("Enter author's name:");
            var titleName = InputHelper.ReadString("Enter title's name:");
            var numberOfCopies = InputHelper.ReadInt("Enter number of available copies:", 1, int.MaxValue);

            switch (titleType)
            {
                case eTitleType.Book:
                    AddBook(author, titleName, numberOfCopies);
                    break;
                case eTitleType.Dvd:
                    AddDvd(author, titleName, numberOfCopies);
                    break;
                default:
                    OutputHelper.WriteLine("Title type not supported!");
                    break;
            }
        }

        private void AddBook(string author, string name, int availableCopies)
        {
            var book = new Book();

            var isbn = InputHelper.ReadString("Enter ISBN:");
            var numberOfPages = InputHelper.ReadInt("Enter number of Pages:", 1, int.MaxValue);

            book.Author = author;
            book.Name = name;
            book.ISBN = isbn;
            book.AvailableCopies = availableCopies;
            book.NumberOfPages = numberOfPages;

            try
            {
                var result = _bookRepository.Create(book);

                if (result is null)
                    OutputHelper.WriteLine("Book not added.");
                else OutputHelper.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                OutputHelper.WriteLine("Book not added.");
                InputHelper.ReadKey("Press any key to continue...");
            }
            finally
            {
                this.Application.NavigateBack();
            }
        }

        private void AddDvd(string author, string name, int availableCopies)
        {
            var dvd = new Dvd();

            var length = InputHelper.ReadInt("Enter Length (minutes):", 1, 600);
            var numberOfChapters = InputHelper.ReadInt("Enter number of chapters:", 1, 25);

            dvd.Author = author;
            dvd.Name = name;
            dvd.AvailableCopies = availableCopies; ;
            dvd.NumberOfChapters = numberOfChapters;
            dvd.LengthInMinutes = length;

            var result = _dvdRepository.Create(dvd);

            if (result is null)
                OutputHelper.WriteLine("Dvd not added.");
            else OutputHelper.WriteLine("Dvd added successfully.");

            this.Application.NavigateBack();
        }

        private void InitializeOptions()
        {
            this.Menu.Add(1, "Add Book", () => this.AddTitle(eTitleType.Book)) ;
            this.Menu.Add(2, "Add Dvd", () => this.AddTitle(eTitleType.Dvd));
        }
    }
}
