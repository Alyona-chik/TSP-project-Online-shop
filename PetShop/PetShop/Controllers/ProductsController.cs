#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace PetShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products

        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }
        public ActionResult FoodCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FoodCategory(string typeButton)
        {
            switch (typeButton)
            {
                case "Cat":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Food, typeAnim = AnimalType.Cat});
                    break;
                case "Dog":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Food, typeAnim = AnimalType.Dog });
                    break;
                case "Small animal":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Food, typeAnim = AnimalType.Small_animal });
                    break;
                case "Fish":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Food, typeAnim = AnimalType.Fish });
                    break;
                case "Bird":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Food, typeAnim = AnimalType.Bird });
                    break;
            }
            return View();
        }
        public ActionResult ToyCategory()
        {
            return View();
        }
        //public async Task<IActionResult> AddToCart(long? id)
        //{
            
        //    return View();
        //}
        public async Task<ActionResult> ProductsForCategoryAsync(ProductType typeProd, AnimalType typeAnim)
        {
            List<Product> allProducts = await _context.Product.ToListAsync();
            List<Product> products = new List<Product>();  
            foreach(Product product in allProducts)
            {
                if(product.ProductType == typeProd && product.AnimalType == typeAnim)
                {
                    products.Add(product);
                }
            }
            return View(products);

        }

        [HttpPost]
        public ActionResult ToyCategory(string typeButton)
        {
            switch (typeButton)
            {
                case "Cat":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Toy, typeAnim = AnimalType.Cat });
                    break;
                case "Dog":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Toy, typeAnim = AnimalType.Dog });
                    break;
                case "Small animal":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Toy, typeAnim = AnimalType.Small_animal });
                    break;
                case "Fish":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Toy, typeAnim = AnimalType.Fish });
                    break;
                case "Bird":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Toy, typeAnim = AnimalType.Bird });
                    break;
            }
            return View();
        }
        public ActionResult MacationCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MedicationCategory(string typeButton)
        {
            switch (typeButton)
            {
                case "Cat":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Medication, typeAnim = AnimalType.Cat });
                    break;
                case "Dog":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Medication, typeAnim = AnimalType.Dog });
                    break;
                case "Small animal":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Medication, typeAnim = AnimalType.Small_animal });
                    break;
                case "Fish":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Medication, typeAnim = AnimalType.Fish });
                    break;
                case "Bird":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Medication, typeAnim = AnimalType.Bird });
                    break;
            }
            return View();
        }
        public ActionResult TreatCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TreatCategory(string typeButton)
        {
            switch (typeButton)
            {
                case "Cat":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Treat, typeAnim = AnimalType.Cat });
                    break;
                case "Dog":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Treat, typeAnim = AnimalType.Dog });
                    break;
                case "Small animal":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Treat, typeAnim = AnimalType.Small_animal });
                    break;
                case "Fish":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Treat, typeAnim = AnimalType.Fish });
                    break;
                case "Bird":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Treat, typeAnim = AnimalType.Bird });
                    break;
            }
            return View();
        }
        public ActionResult AccessoriesCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AccessoriesCategory(string typeButton)
        {
            switch (typeButton)
            {
                case "Cat":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Accessories, typeAnim = AnimalType.Cat });
                    break;
                case "Dog":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Accessories, typeAnim = AnimalType.Dog });
                    break;
                case "Small animal":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Accessories, typeAnim = AnimalType.Small_animal });
                    break;
                case "Fish":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Accessories, typeAnim = AnimalType.Fish });
                    break;
                case "Bird":
                    return RedirectToAction("ProductsForCategory", new { typeProd = ProductType.Accessories, typeAnim = AnimalType.Bird });
                    break;
            }
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductType,AnimalType,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,ProductType,AnimalType,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }
        public async Task<IActionResult> AddToCart(long? Id)
        {
            if(!User.Identity.IsAuthenticated)
            {
                return RedirectPermanent("/Identity/Account/Login");
            }

            if (Id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserCartsController userCartsController = new UserCartsController(_context);
            CartsController cartsController = new CartsController(_context);
           
            long cartId = userCartsController.GetCartIdAsync(userId).Result;
            Cart cart = cartsController.GetCart(cartId).Result;
            if(cartId == 0)
            { 
                cart = _context.Cart.Add(new Cart { }).Entity;
                await _context.SaveChangesAsync();
                _context.UserCart.Add(new UserCart{UserId = userId , Cart = cart});
                await _context.SaveChangesAsync();
            }
            CartItem cartItem = new CartItem { Quantity = 1, Product = product, Cart = cart };
            _context.CartItem.Add(cartItem);
            int result = await _context.SaveChangesAsync();

            if(result != 0)
            {
                cart.setTotalMoney(product.Price);
                cart.setProductQuantity();
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Category");
        }
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
