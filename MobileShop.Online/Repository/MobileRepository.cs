using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using MobileShop.Online.Data;
using MobileShop.Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MobileShop.Online.Repository
{
    public class MobileRepository
    {
        private readonly MobileStoreContext _context = null;

        public MobileRepository(MobileStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewMobile(MobilesModels mobilesModels)
        {
            var newMobile = new Mobile()
            {
                MobileName = mobilesModels.MobileName,
                CreateOn = DateTime.UtcNow,
                Description = mobilesModels.Description,
                MobileVersion = mobilesModels.MobileVersion,
                Language=mobilesModels.Language,
                Price=mobilesModels.Price.HasValue ? mobilesModels.Price.Value : 0,
                UpdateOn = DateTime.UtcNow
            };

            await _context.Mobiles.AddAsync(newMobile);
            await _context.SaveChangesAsync();

            return newMobile.Id;

        }
        public async Task<List<MobilesModels>> GetAllMobiles()
        {
            var mobiles = new List<MobilesModels>();
            var allMobiles = await _context.Mobiles.ToListAsync();
            if (allMobiles?.Any() == true)
            {
                foreach (var mobile in allMobiles)
                {
                    mobiles.Add(new MobilesModels()
                        {
                            MobileName=mobile.MobileName,
                            Id=mobile.Id,
                            Color=mobile.Color,
                            Description=mobile.Description,
                            MobileVersion=mobile.MobileVersion,
                            Language=mobile.Language,
                            Price=mobile.Price
                        });
                }
            }
            return mobiles;
        }
        public async Task<MobilesModels> GetMobilesById(int id)
        {
            var mobile = await _context.Mobiles.FindAsync(id);
            if (mobile != null)
            {
                var mobileDetails = new MobilesModels()
                {
                    MobileName = mobile.MobileName,
                    Id=mobile.Id,
                    Color = mobile.Color,
                    Description = mobile.Description,
                    MobileVersion = mobile.MobileVersion,
                    Language = mobile.Language,
                    Price = mobile.Price
                };
                    return mobileDetails;
            }
            else
            { return null; }
                
        }
        public List<MobilesModels> SearchMobile(string MobileName, string ModalVersion)
        {
            return DataSource().Where(x => x.MobileName.Contains(MobileName) || x.MobileVersion.Contains(ModalVersion)).ToList();
        }

        private List<MobilesModels> DataSource()
        {
            return new List<MobilesModels>()
            {
                new MobilesModels() { Id = 1, MobileName = "Vivo", MobileVersion = "S1 PRO", Description="This is Description of Vivo smart-phone", Price=21000, Color="Red,Blue,White,Black", Language="English,Hindi,Chaenies" },
                new MobilesModels() { Id = 2, MobileName = "OPPO", MobileVersion = "F15", Description="This is Description of OPPO smart-phone", Price=27000, Color="Blue,White,Black", Language="English,Hindi"  },
                new MobilesModels() { Id = 3, MobileName = "Samsung Galaxy", MobileVersion = "M21", Description="This is Description of Samsung Galaxy smart-phone", Price=18000, Color="Blue,White,Black", Language="English,Japniese"  },
                new MobilesModels() { Id = 4, MobileName = "IPhone 11", MobileVersion = "PRO MAX", Description="This is Description of IPhone 11 smart-phone", Price=115000, Color="White,Black", Language="English"  },
                new MobilesModels() { Id = 5, MobileName = "RealMe", MobileVersion = "C11", Description="This is Description of RealMe smart-phone", Price=15000, Color="Red,Blue,White,Black", Language="English,Hindi" },
                new MobilesModels() { Id = 6, MobileName = "RedMe 9", MobileVersion = "PRO MAX", Description="This is Description of RedMe 9 smart-phone", Price=13000, Color="Red,Blue,White,Black", Language="English,Hindi,Japanies" },
            };
        }
    }
}
