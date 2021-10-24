using CodeWork.Business.Abstract;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeWork.Controllers
{
    public class BookTransactionController : Controller
    {
        // GET: BookTransaction
        private IBookTransactionService _bookTransactionService;
        public BookTransactionController(IBookTransactionService bookTransactionService)
        {
            _bookTransactionService = bookTransactionService;
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
        public ActionResult Add(BookTransactionCreateDto bookTransactionCreateDto)
        {

            var bookTransaction = _bookTransactionService.Add(bookTransactionCreateDto);
            if (bookTransaction.IsSuccessful)
                TempData["BookTransactionAddSuccess"] = "Başarıyla kaydedildi. <br />";
            else
            {
                TempData["BookTransactionSaveError"] = "Hata oluştu!";
                return RedirectToAction("Add", "BookTransaction");
            }
            return RedirectToAction("List", "BookTransaction");
        }
        public ActionResult List()
        {
            var bookTransactions = _bookTransactionService.List();
            return View(bookTransactions.Data);
        }

     

    }
}