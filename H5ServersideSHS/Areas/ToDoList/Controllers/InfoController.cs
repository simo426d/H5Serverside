using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using H5ServersideSHS.Areas.ToDoList.Models;
using Microsoft.AspNetCore.DataProtection;
using H5ServersideSHS.Areas.ToDoList.Code;
using Microsoft.AspNetCore.Authorization;

namespace H5ServersideSHS.Areas.ToDoList.Controllers
{
    [Area("ToDoList")]
    [Route("ToDoList/[controller]/[action]")]
    [Authorize("RequiredAuthenticateUser")]
    public class InfoController : Controller
    {
        private readonly ToDoServerContext _context;
        private readonly IDataProtector _dataProtector;
        private readonly Crypt _crypt;

        public InfoController(ToDoServerContext context, Crypt crypt, IDataProtectionProvider dataProtector)
        {
            _context = context;
            _crypt = crypt;
            _dataProtector = dataProtector.CreateProtector("H5ServersideProject.HomeController.SecretKey");
        }

        // GET: ToDoList/Info
        public async Task<IActionResult> Index()
        {
            var userIdentityName = User.Identity.Name;

            var rows = await _context.Infos.Where(s => s.UserName == userIdentityName).ToListAsync();
            bool matchFound = rows.Count > 0;

            if (matchFound)
            {
                foreach (Info row in rows)
                {
                    string encryptetText = row.Beskrivelse;
                    row.Beskrivelse = _crypt.Decrypt(encryptetText, _dataProtector);
                }
                return View(rows);
            }
            else
            {
                return View(new List<Info>());
            }

        }

        // GET: ToDoList/Info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // GET: ToDoList/Info/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Titel,Beskrivelse")] Info info)
        {
            if (ModelState.IsValid)
            {
                string description = info.Beskrivelse;
                info.Beskrivelse = _crypt.Encrypt(description, _dataProtector);

                _context.Add(info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(info);
        }

        // GET: ToDoList/Info/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }

        // POST: ToDoList/Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Titel,Beskrivelse")] Info info)
        {
            if (id != info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.Id))
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
            return View(info);
        }

        // GET: ToDoList/Info/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // POST: ToDoList/Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Infos.FindAsync(id);
            _context.Infos.Remove(info);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoExists(int id)
        {
            return _context.Infos.Any(e => e.Id == id);
        }
    }
}
