using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindJqueryAjaxMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindJqueryAjaxMvc.Controllers
{
    public class ShipperController : Controller
    {
        private readonly NorthwindContext _context;

        public ShipperController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Shippers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shippers.ToListAsync());
        }

        // GET: Shippers/Edit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Shipper());
            }
            else
            {
                var shippers = await _context.Shippers.FindAsync(id);
                if (shippers == null)
                {
                    return NotFound();
                }
                return View(shippers);
            }
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ShipperId,CompanyName,Phone")] Shipper shippers)
        {
            if (ModelState.IsValid)
            {
                // Insert
                if (id ==0)
                {
                    _context.Shippers.Add(shippers);
                    await _context.SaveChangesAsync();
                }
                // Update
                else 
                {                
                    try
                    {
                        _context.Update(shippers);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ShippersExists(shippers.ShipperId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shippers.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", shippers) });
        }

        // GET: Shippers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippers = await _context.Shippers
                .FirstOrDefaultAsync(m => m.ShipperId == id);
            if (shippers == null)
            {
                return NotFound();
            }

            return View(shippers);
        }

        // POST: Shippers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shippers = await _context.Shippers.FindAsync(id);
            _context.Shippers.Remove(shippers);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shippers.ToList()) });
        }

        private bool ShippersExists(int id)
        {
            return _context.Shippers.Any(e => e.ShipperId == id);
        }
    }
}
