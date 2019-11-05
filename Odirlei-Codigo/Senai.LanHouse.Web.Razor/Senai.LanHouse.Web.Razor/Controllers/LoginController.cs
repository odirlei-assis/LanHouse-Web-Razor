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
    public class LoginController : Controller
    {
        private readonly LanHouseContext _context;

        public LoginController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

       
        // GET: Login/Create
        public IActionResult Create()
        {
            HttpContext.Session.Clear();
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Senha")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {

                Usuarios retorno = _context.Usuarios.FirstOrDefault(x => x.Email == usuarios.Email && x.Senha == usuarios.Senha);

                if (retorno == null)
                {
                    ViewBag.Mensagem = "Email ou Senha invalidos";
                    return View(usuarios);
                }

                HttpContext.Session.SetString("email", usuarios.Email);
                ViewBag.Mensagem = "Usuario Valido";
                return RedirectToAction("Index", "RegistroDefeitos");

            }
            return View(usuarios);
        }
    }
}
