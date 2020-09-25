using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Online.Controllers
{
    public class MoblielsController : Controller
    {
        public string GetAllMobiles()
        {
            return "All Mobiles";
        }

        public string GetMobiles()
        {
            return "Mobiles";
        }
    }
}
