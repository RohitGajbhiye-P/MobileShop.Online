using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Online.Models;
using MobileShop.Online.Repository;

namespace MobileShop.Online.Controllers
{
    public class MobileController : Controller
    {
        private readonly MobileRepository _mobileRepository = null;
        public MobileController(MobileRepository mobileRepository)
        {
            _mobileRepository = mobileRepository;
        }
        public async Task<ViewResult> GetAllMobiles()
        {
            var data = await _mobileRepository.GetAllMobiles();
            return View(data);
        }
        [Route("product-detail/{id}", Name ="mobileDetailsRoute")]
        public async Task<ViewResult> GetMobiles(int id)
        {
            var data = await _mobileRepository.GetMobilesById(id);
            return View(data);
        }
        public List<MobilesModels> SearchMobile(string MobileName, string ModalVersion)
        {
            return _mobileRepository.SearchMobile(MobileName, ModalVersion);
        }
        public ViewResult AddNewMobile( bool isSuccess=false, int mobileId=0 )
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.MobileId = mobileId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMobile(MobilesModels mobilesModels)
        {
            if (ModelState.IsValid)
            {
                int id = await _mobileRepository.AddNewMobile(mobilesModels);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewMobile), new { isSuccess = true, mobileId = id });
                }
            }
            return View();
        }
    }
}
