using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Senai.LanHouse.Web.Razor.Domains;

namespace Senai.LanHouse.Web.Razor.Controllers
{
    public class RegistroDefeitosController : Controller
    {
        private readonly LanHouseContext _context;

        public RegistroDefeitosController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: RegistroDefeitos
        public async Task<IActionResult> Index()
        {

            if (HttpContext.Session.GetString("email") == null)
                return RedirectToAction("Create", "Login");

            var lanHouseContext = _context.RegistroDefeitos.Include(r => r.IdTipoDefeitoNavigation).Include(r => r.IdTipoEquipamentoNavigation);
            return View(await lanHouseContext.ToListAsync());
        }

        // GET: RegistroDefeitos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDefeitos = await _context.RegistroDefeitos
                .Include(r => r.IdTipoDefeitoNavigation)
                .Include(r => r.IdTipoEquipamentoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroDefeitos == null)
            {
                return NotFound();
            }

            return View(registroDefeitos);
        }

        // GET: RegistroDefeitos/Create
        public IActionResult Create()
        {
            ViewData["IdTipoDefeito"] = new SelectList(_context.TiposDefeitos, "Id", "Nome");
            ViewData["IdTipoEquipamento"] = new SelectList(_context.TiposEquipamentos, "Id", "Nome");
            return View();
        }

        // POST: RegistroDefeitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataChamado,IdTipoEquipamento,IdTipoDefeito,Descricao")] RegistroDefeitos registroDefeitos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDefeitos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoDefeito"] = new SelectList(_context.TiposDefeitos, "Id", "Nome", registroDefeitos.IdTipoDefeito);
            ViewData["IdTipoEquipamento"] = new SelectList(_context.TiposEquipamentos, "Id", "Nome", registroDefeitos.IdTipoEquipamento);
            return View(registroDefeitos);
        }
    }
}
