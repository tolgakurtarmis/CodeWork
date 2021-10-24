using CodeWork.Business.Abstract;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeWork.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var members = _memberService.List();
            return View(members.Data);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MemberCreateDto memberDto)
        {

            var memberAdd = _memberService.Add(memberDto);
            if (memberAdd.IsSuccessful)
                TempData["MemberAddSuccess"] = "Kullanıcı oluşturulmuştur. <br />";
            else
            {
                TempData["MemberSaveError"] = "Kullanıcı oluşturulurken hata oluştur";
                return RedirectToAction("Add", "Member");
            }
            return RedirectToAction("List", "Member");

        }

        public ActionResult Update(int memberId = 0)
        {
            var member = _memberService.Get(x => x.Id == memberId);
            if (!member.IsSuccessful) return RedirectToAction("NotFound", "Home");

            return View(member.Data);
        }

        [HttpPost]
        public ActionResult Update(MemberUpdateDto model, int memberId)
        {
            model.Id = memberId;
            var update = _memberService.Update(model);
            if (update.IsSuccessful)
                return RedirectToAction("List", "Member");
            else
            {
                TempData["memberUpdateError"] = "Güncelleme işleminde hata oluştu!";
                return RedirectToAction("Update", "Member", new { memberId = memberId });

            }
        }


        [HttpPost]
        public JsonResult FilterMember(string filter)
        {
            var results = _memberService.ListMemberByFilter(filter);

            return Json(results);
        }
    }
}