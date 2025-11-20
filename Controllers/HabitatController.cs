using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamTheAnhKTPMK21B.Data;
using PhamTheAnhKTPMK21B.Models;

namespace PhamTheAnhKTPMK21B.Controllers
{
    public class HabitatController : Controller
    {
        private readonly PhamTheAnhKTPMK21BContext _context;

        public HabitatController(PhamTheAnhKTPMK21BContext context)
        {
            _context = context;
        }

        // GET: Habitat
        public async Task<IActionResult> Index(string searchString, string sortOrder, int page = 1, int pageSize = 3)
        {
            var query = _context.Habitat.Where(h => h.HabitatName != "Unknown Habitat").AsQueryable();

            // Search
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(h => h.HabitatName.Contains(searchString));
            }

            // Đẩy tham số sort sang View (style Presentation)
            ViewData["NameSortParm"] = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewData["ClimateSortParm"] = sortOrder == "Climate" ? "Climate_desc" : "Climate";
            ViewData["AreaSortParm"] = sortOrder == "Area" ? "Area_desc" : "Area";

            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentSearch"] = searchString;

            // Logic sort theo đúng pattern như Presentation
            switch (sortOrder)
            {
                case "Name":
                    query = query.OrderBy(h => h.HabitatName);
                    break;
                case "Name_desc":
                    query = query.OrderByDescending(h => h.HabitatName);
                    break;

                case "Climate":
                    query = query.OrderBy(h => h.Climate);
                    break;
                case "Climate_desc":
                    query = query.OrderByDescending(h => h.Climate);
                    break;

                case "Area":
                    query = query.OrderBy(h => h.Area);
                    break;
                case "Area_desc":
                    query = query.OrderByDescending(h => h.Area);
                    break;

                default:
                    query = query.OrderBy(h => h.HabitatName); // mặc định
                    break;
            }

            // Paging
            var totalCount = await query.CountAsync();

            var items = await query.Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            var result = new PagedResult<Habitat>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            return View(result);
        }


        // GET: Habitat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitat = await _context.Habitat
                .FirstOrDefaultAsync(m => m.HabitatId == id);
            if (habitat == null)
            {
                return NotFound();
            }

            return View(habitat);
        }

        // GET: Habitat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitatId,HabitatName,Climate,Area")] Habitat habitat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitat);
        }

        // GET: Habitat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitat = await _context.Habitat.FindAsync(id);
            if (habitat == null)
            {
                return NotFound();
            }
            return View(habitat);
        }

        // POST: Habitat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitatId,HabitatName,Climate,Area")] Habitat habitat)
        {
            if (id != habitat.HabitatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitatExists(habitat.HabitatId))
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
            return View(habitat);
        }

        // GET: Habitat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitat = await _context.Habitat
                .FirstOrDefaultAsync(m => m.HabitatId == id);
            if (habitat == null)
            {
                return NotFound();
            }

            return View(habitat);
        }

        // POST: Habitat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, bool confirm = false)
        {
            var habitat = _context.Habitat.Include(h => h.Animals).FirstOrDefault(h => h.HabitatId == id);
            if (habitat.Animals.Any() && !confirm)
            {
                ViewBag.ConfirmDelete = true; 
                return View(habitat);
            }
            if (habitat.Animals.Any())
            {
                var unknownHabitat = await _context.Habitat.FirstOrDefaultAsync(s => s.HabitatName == "Unknown Habitat");

                if (unknownHabitat == null)
                {
                    unknownHabitat = new Habitat
                    {
                        HabitatName = "Unknown Habitat",
                        Climate = "Unknown Climate",
                        Area = 0
                    };
                    _context.Habitat.Add(unknownHabitat);
                    await _context.SaveChangesAsync();
                }
                foreach (var hab in habitat.Animals)
                {
                    hab.HabitatId = unknownHabitat.HabitatId;
                }
            }
            _context.Habitat.Remove(habitat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
 

        private bool HabitatExists(int id)
        {
            return _context.Habitat.Any(e => e.HabitatId == id);
        }
    }
}
