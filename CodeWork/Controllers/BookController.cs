using CodeWork.Business.Abstract;
using CodeWork.Business.DependencyResolvers;
using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace CodeWork.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;
        private IAuthorService _authorService;
        private IImageService _imageService;
        public BookController(IBookService bookService, IAuthorService authorService,
            IImageService imageService)
        {
            this.bookService = bookService;
            _authorService = authorService;
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BookDto bookDto, HttpPostedFileBase UploadFiles)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    var addedBook = bookService.Add(bookDto);

                    if (UploadFiles != null)
                    {
                        var image = ImageSave(addedBook.Data.Id, UploadFiles);                                               
                        if (image.IsSuccessful)
                        { 
                           var updateBook = bookService.UpdateImageId(addedBook.Data.Id,image.Data.Id);
                            
                        }
                    }

                    transaction.Complete();

                    return View();
                }
            }
            catch (System.Exception ex)
            {
                TempData["BookAddError"] = ex.Message;

                throw;
            }


        }
        public Response<ImageDto> ImageSave(int bookId, HttpPostedFileBase fuImage)
        {
            var name = bookId + Path.GetExtension(fuImage.FileName);

            var fullPath = System.Web.HttpContext.Current.Server.MapPath("/Content/img/books/" + bookId.ToString().ToCharArray()[0] + "/" + name);

            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("/Content/img/books/" + bookId.ToString().ToCharArray()[0] + "/")))
            {
                Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/Content/img/books/" + bookId.ToString().ToCharArray()[0] + "/"));
            }

            fuImage.SaveAs(fullPath);

            var imageCreateDto = new ImageCreateDto()
            {
                Name = name,
                Path = fullPath,
                IsActive = true,
                IsDelete = false
            };

            var image = _imageService.Add(imageCreateDto);

            return image;
        }

        public ActionResult List()
        {
            var productList = bookService.List();

            return View(productList.Data);
        }
        [HttpPost]
        public JsonResult FilterAuthor(string filter)
        {
            var results = _authorService.ListByFilter(filter);

            return Json(results);
        }

        [HttpPost]
        public JsonResult FilterBook(string filter)
        {
            var results = bookService.ListBookByFilter(filter);

            return Json(results);
        }

    }
}