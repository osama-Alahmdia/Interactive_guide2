using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interactive_guide2.Data;
using Interactive_guide2.Models;

namespace Interactive_guide2.Controllers
{
    public class orangsController : Controller
    {
        private readonly Interactive_guide2Context _context;

        public orangsController(Interactive_guide2Context context)
        {
            _context = context;
        }

        // GET: orangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.orangs.ToListAsync());
        }

        // GET: orangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orangs = await _context.orangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orangs == null)
            {
                return NotFound();
            }

            return View(orangs);
        }

        // GET: orangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: orangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,IFormFile files,[Bind("Id,title,info,poss_dis")] orangs orangs)
        {

            if (file != null)
            {
                string filename = file.FileName;
                //  string  ext = Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                { await file.CopyToAsync(filestream); }

                orangs.imgfile = filename;
            }


            if (files != null)
            {
                string filename = files.FileName;
                //  string  ext = Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\videos"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                { await files.CopyToAsync(filestream); }

                orangs.videofile = filename;
            }








            _context.Add(orangs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: orangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orangs = await _context.orangs.FindAsync(id);
            if (orangs == null)
            {
                return NotFound();
            }
            return View(orangs);
        }

        // POST: orangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, IFormFile files,int id, [Bind("Id,title,info,poss_dis,imgfile,videofile")] orangs orangs)
        {
            if (file != null)
            {
                string filename = file.FileName;
                //  string  ext = Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                { await file.CopyToAsync(filestream); }

                orangs.imgfile = filename;
            }


            if (files != null)
            {
                string filename = files.FileName;
                //  string  ext = Path.GetExtension(file.FileName);
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\videos"));
                using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                { await files.CopyToAsync(filestream); }

                orangs.videofile = filename;
            }
            _context.Update(orangs);
                    await _context.SaveChangesAsync();
             
                return RedirectToAction(nameof(Index));
            
        }

        // GET: orangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orangs = await _context.orangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orangs == null)
            {
                return NotFound();
            }

            return View(orangs);
        }

        // POST: orangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orangs = await _context.orangs.FindAsync(id);
            if (orangs != null)
            {
                _context.orangs.Remove(orangs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool orangsExists(int id)
        {
            return _context.orangs.Any(e => e.Id == id);
        }
    }
}
