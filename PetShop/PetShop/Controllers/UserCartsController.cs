using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class UserCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCartsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserCart>> AllAsync()
        {
            return await _context.UserCart.ToListAsync();
        }
        public async Task<Cart> GetCartAsync(string UserId)
        {
            List<UserCart> userCarts = await AllAsync();
            foreach(var userCart in userCarts)
            {
                if(userCart.UserId == UserId)
                {
                    return userCart.Cart;
                }
            }
            return null;
        }
        public async Task<long> GetCartIdAsync(string UserId)
        {
            List<UserCart> userCarts = await AllAsync();
            foreach(var userCart in userCarts)
            {
                if(userCart.UserId == UserId)
                {
                    return userCart.CartId;
                }
            }
            return 0;
        }
        // GET: UserCarts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserCart.Include(u => u.Cart);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserCarts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.UserCart == null)
            {
                return NotFound();
            }

            var userCart = await _context.UserCart
                .Include(u => u.Cart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCart == null)
            {
                return NotFound();
            }

            return View(userCart);
        }

        // GET: UserCarts/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id");
            return View();
        }

        // POST: UserCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,CartId")] UserCart userCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id", userCart.CartId);
            return View(userCart);
        }

        // GET: UserCarts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.UserCart == null)
            {
                return NotFound();
            }

            var userCart = await _context.UserCart.FindAsync(id);
            if (userCart == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id", userCart.CartId);
            return View(userCart);
        }

        // POST: UserCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,CartId")] UserCart userCart)
        {
            if (id != userCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCartExists(userCart.Id))
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
            ViewData["CartId"] = new SelectList(_context.Cart, "Id", "Id", userCart.CartId);
            return View(userCart);
        }

        // GET: UserCarts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.UserCart == null)
            {
                return NotFound();
            }

            var userCart = await _context.UserCart
                .Include(u => u.Cart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCart == null)
            {
                return NotFound();
            }

            return View(userCart);
        }

        // POST: UserCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.UserCart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserCart'  is null.");
            }
            var userCart = await _context.UserCart.FindAsync(id);
            if (userCart != null)
            {
                _context.UserCart.Remove(userCart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCartExists(long id)
        {
          return (_context.UserCart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
