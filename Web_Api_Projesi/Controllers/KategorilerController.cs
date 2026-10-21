using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Projesi.Data;
using Web_Api_Projesi.Models;

namespace Web_Api_Projesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly ilkWebAPIDbContext _dbContext;
        public KategorilerController(ilkWebAPIDbContext context)
        {
            _dbContext = context;

        }
        // INSERT (POST): api/products
        [HttpPost]
        public async Task<IActionResult> kategoeriEkle(Kategoriler kategori)
        {
            if (kategori == null)
            {
                return BadRequest();
            }
            _dbContext.Kategorilers.Add(kategori);
            await _dbContext.SaveChangesAsync();
            return Ok(kategori);
        }
        [HttpGet]
        public async Task<IActionResult> kategoriGetir()
        {
            var kategoriler = await _dbContext.Kategorilers.ToListAsync();
            return Ok(kategoriler);
        }
        [HttpGet("getKategoriById")]
        public async Task<IActionResult> getKategoriById(int kategoriId)
        {
            var kategori = await _dbContext.Kategorilers.FindAsync(kategoriId);
            if (kategori == null)
            {
                return NotFound();
            }
            return Ok(kategori);

        }
        [HttpPut("{kategoriId}")]
        public async Task<IActionResult> kategoriGuncelle(int kategoriId, Kategoriler guncelleKategori)
        {
            if (kategoriId != guncelleKategori.KategoriId)
            {
                return BadRequest();
            }
            var kategoriDb = await _dbContext.Kategorilers.FindAsync(kategoriId);
            if (kategoriDb == null)
            {
                return NotFound();
            }
            kategoriDb.KategoriAdi= guncelleKategori.KategoriAdi;           

            await _dbContext.SaveChangesAsync();
            return Ok(kategoriDb);
        }
        [HttpDelete]
        public async Task<IActionResult> kategoriSil(int kategoriId)
        {
            var kategoriDb = await _dbContext.Kategorilers.FindAsync(kategoriId);
            if (kategoriDb == null)
            {
                return NotFound();
            }
            _dbContext.Kategorilers.Remove(kategoriDb);
            await _dbContext.SaveChangesAsync();
            return Ok(kategoriDb);
        }



    }
}