using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P10.Server.Controllers;
using P10.Shared;

namespace P10.Server.DB
{
    public class kalaProvider
    {
        //*********************Yek object az class ClotheDBContext
        private readonly KalaDBContext _context;
        private readonly ILogger _logger;
        public kalaProvider(KalaDBContext context, ILoggerFactory loggerFactory)
        {
            this._context = context;
            this._logger = loggerFactory.CreateLogger("ClotheProvider");
        }
        public async Task AddClothe(kala kala)
        {
            var LastClothe = this._context.Kalas.ToArray().LastOrDefault();
            var LastId = this._context.Kalas.Select(k => k.id).Max();
            var newID = 0;
            if(!(LastClothe is null))
                newID = LastId + 1;
            kala.id = newID;

            await _context.Kalas.AddAsync(kala);
            await _context.SaveChangesAsync();
        }
        
        public List<kala> GetAllClothes()
            => this._context.Kalas.ToList();
        public List<kala> GetAllClothesByCategory(string Category)
            => this._context.Kalas.Where(clothe => clothe.p_category == Category).ToList();
        
        public async Task RemoveClothes(int[] ids)
        {
            var k = this._context.Kalas.ToList();
            var d = k.Where(arg => ids.Contains(arg.id));
            foreach(var i in d)
            {
                this._context.Kalas.Remove(i);
            }
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateClotheCount(int id, int newcount)
        {
            var kala = this._context.Kalas.Where(clothe => clothe.id == id).FirstOrDefault();
            kala.p_count += newcount ;
            await this._context.SaveChangesAsync();
        }
        public async Task UpdateKala(kala ka)
        {
            this._context.Kalas.Update(ka);
            await this._context.SaveChangesAsync();
        }

    }
}