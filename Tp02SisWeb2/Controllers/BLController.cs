using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Tp02SisWeb2;
using Tp02SisWeb2.Models;
using Tp02SisWeb2.Data;
using Microsoft.IdentityModel.Tokens;

namespace Tp02SisWeb2.Controllers
{
    public class BLController : Controller
    {
        private readonly PortoContext portoContext;
        public BLController(PortoContext context)
        {
            portoContext = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await portoContext.BLs.ToListAsync());
        }
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bl = await portoContext.BLs.FirstOrDefaultAsync(m => m.IdBl == id);
            if (bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create([Bind("IdBl,Num,Consignee,Navio")]BL bl)
        {
            if (ModelState.IsValid)
            {
                portoContext.Add(bl);
                await portoContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdBl,Num,Consignee,Navio")] BL bl)
        {
            if(id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    portoContext.Update(bl);
                    await portoContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlExiste(bl.IdBl))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                 
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bl);
        }
        private bool BlExiste(int id)
        {
            return portoContext.BLs.Any(e => e.IdBl == id);
        }
        public async Task<IActionResult>Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var bl = await portoContext.BLs.FirstOrDefaultAsync(m => m.IdBl == id);
            if(bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmado(int id)
        {
            var bl = await portoContext.BLs.FindAsync(id);
            portoContext.BLs.Remove(bl);
            await portoContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
