using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Tp02SisWeb2.Controllers;
using Tp02SisWeb2.Models;
using Tp02SisWeb2.Data;

namespace Tp02SisWeb2.Controllers
{
    public class ContainersController:Controller
    {
        private readonly PortoContext portoContext;

        public ContainersController(PortoContext context)
        {
            portoContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var PortoContext = portoContext.Containers.Include(c => c.BL);
            return View(await PortoContext.ToListAsync());
        }
        public async Task<IActionResult> Detalhes(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var container = await portoContext.Containers
                .Include(c => c.BL).FirstOrDefaultAsync(m => m.IdContainer == id);
            if(container == null)
            {
                return NotFound();
            }
            return View(container);
        }
        public IActionResult Create()
        {
            ViewData["BLIdBl"] = new SelectList(portoContext.BLs, "IdBl", "IdBl");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(int id, [Bind("IdContainer,numContainer,tipo,tamanho,IdBl")] Models.Container container)
        {
            if (ModelState.IsValid)
            {
                portoContext.Add(container);
                await portoContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBl"] = new SelectList(portoContext.BLs, "IdBl", "IdBl");
            return View(container);
        }
        public async Task<IActionResult>Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var container = await portoContext.Containers.FindAsync(id);
            if(container == null)
            {
                return NotFound();
            }
            ViewData["IdBl"] = new SelectList(portoContext.BLs, "IdBl", "IdBl", container.IdBl);
                return View(container);
        }
        public async Task<IActionResult>Edit(int? id,[Bind("IdContainer,numContainer,tipo,tamanho,IdBl")] Models.Container container)
        {
            
            if(id != container.IdContainer)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    portoContext.Update(container);
                    await portoContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerExiste(container.IdContainer))
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
            ViewData["IdBl"] = new SelectList(portoContext.BLs, "IdBl", "IdBl", container.IdBl);
            return View(container);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var container = await portoContext.Containers
                .Include(c => c.BL).FirstOrDefaultAsync(m => m.IdContainer == id);
            if(container == null)
            {
                return NotFound();
            }
            return View(container);
        }
        public async Task<IActionResult>DeleteConfirm(int id)
        {
            var container = await portoContext.Containers.FindAsync(id);
            portoContext.Containers.Remove(container);
            return RedirectToAction(nameof(Index));
        }
        private bool ContainerExiste(int id)
        {
            return portoContext.Containers.Any(e => e.IdContainer == id);
        }
    }
}
