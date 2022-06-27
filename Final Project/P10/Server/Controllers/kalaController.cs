using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P10.Server.DB;
using P10.Shared;

namespace P10.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KalaController : Controller
    {
        public static List<kala> kalas = new List<kala>
        {};

        private readonly kalaProvider _provider;
        public KalaController(kalaProvider provider)
        {
            this._provider = provider;
        }
        [HttpPost]
        [Route("AddNewClotheToDB")]
        public async Task<kala> AddNewClotheToDB(kala newClothe)
        {
            await this._provider.AddClothe(newClothe);
            return newClothe;
        }
        [HttpGet]
        [Route("GetAllClothesFromDB")]
        public List<kala> GetAllClothesFromDB()
            => this._provider.GetAllClothes();
        
        [HttpGet("getClotheByCategory/{Category}")]
        public List<kala> getKalaByCategory(string Category)
            => this._provider.GetAllClothesByCategory(Category);


        [HttpDelete]
        [Route("RemovekalaFromDB")]
        public async Task<kala> RemoveClothes(int[] ids)
        {
            await this._provider.RemoveClothes(ids);
            return this._provider.GetAllClothes().ToList().FirstOrDefault();
        }
        


        [HttpPut]
        [Route("UpdateClothCountFromDB")]//-->Params
        public async Task<kala> UpdateClotheCount(kala ka)
        {
            await this._provider.UpdateKala(ka);
            return this._provider.GetAllClothes().ToList().FirstOrDefault();
        }

    }
}