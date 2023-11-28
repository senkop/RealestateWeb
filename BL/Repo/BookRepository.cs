//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Try.BL.Interface;
//using Try.DAL.Database;
//using Try.DAL.Entity;
//using Try.Models;

//namespace Try.BL.Repo
//{
//    public class BookRepository : IBookRepository
//    {
//        private readonly DbContainer db;
//        private readonly IConfiguration _configuration;
//        //private readonly IMapper mapper;


//        public BookRepository(DbContainer db, IConfiguration configuration)
//        {
//            this.db = db;
//            // mapper = _Mapper;
//            _configuration = configuration;

//        }


//        public async Task<int> AddNewBook(BookModel model)
//        {
//            var newBook = new BookModel()
//            {
//                Author = model.Author,
//              //  CreatedOn = DateTime.UtcNow,
//                Description = model.Description,
//                Title = model.Title,
//                LanguageId = model.LanguageId,
//                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
//              //  UpdatedOn = DateTime.UtcNow,
//               // CoverImageUrl = model.CoverImageUrl,
//                //BookPdfUrl = model.BookPdfUrl
//            };

//            newBook.GalleryModel = new List<GalleryModel>();

//            foreach (var file in model.Gallery)
//            {
//                newBook.GalleryModel.Add(new GalleryModel()
//                {
//                    Name = file.Name,
//                    URL = file.URL
//                });
//            }

//            await db.BookModel.AddAsync(newBook);
//            await db.SaveChangesAsync();

//            return newBook.Id;

//        }

//        public async Task<List<BookModel>> GetAllBooks()
//        {
//            return await db.BookModel
//                  .Select(book => new BookModel()
//                  {
//                      Author = book.Author,
//                      Category = book.Category,
//                      Description = book.Description,
//                      Id = book.Id,
//                      LanguageId = book.LanguageId,
//                      Language = book.Language,
//                      Title = book.Title,
//                      TotalPages = book.TotalPages,
//                     // CoverImageUrl = book.CoverImageUrl
//                  }).ToListAsync();
//        }

//        public async Task<List<BookModel>> GetTopBooksAsync(int count)
//        {
//            return await db.BookModel
//                  .Select(book => new BookModel()
//                  {
//                      Author = book.Author,
//                      Category = book.Category,
//                      Description = book.Description,
//                      Id = book.Id,
//                      LanguageId = book.LanguageId,
//                      Language = book.Language,
//                      Title = book.Title,
//                      TotalPages = book.TotalPages,
//                    //  CoverImageUrl = book.CoverImageUrl
//                  }).Take(count).ToListAsync();
//        }

//        public async Task<BookModel> GetBookById(int id)
//        {
//            return await db.BookModel.Where(x => x.Id == id)
//                 .Select(book => new BookModel()
//                 {
//                     Author = book.Author,
//                     Category = book.Category,
//                     Description = book.Description,
//                     Id = book.Id,
//                     LanguageId = book.LanguageId,
//                     Language = book.Language,
//                     Title = book.Title,
//                     TotalPages = book.TotalPages,
//                  //   CoverImageUrl = book.CoverImageUrl,
//                     Gallery = book.GalleryModel.Select(g => new GalleryModel()
//                     {
//                         Id = g.Id,
//                         Name = g.Name,
//                         URL = g.URL
//                     }).ToList(),
//                   //  BookPdfUrl = book.BookPdfUrl
//                 }).FirstOrDefaultAsync();
//        }

//        public List<BookModel> SearchBook(string title, string authorName)
//        {
//            return null;
//        }

//        public string GetAppName()
//        {
//            return _configuration["AppName"];
//        }
//    }
//}