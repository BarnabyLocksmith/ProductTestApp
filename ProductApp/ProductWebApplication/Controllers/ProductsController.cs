namespace ProductWebApplication.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ProductWebApplication.DataServiceClients;
    using ProductWebApplication.Models;

    public class ProductsController : Controller
    {
        private readonly IDataServiceClient client;
        private readonly Guid userId;

        public ProductsController(IDataServiceClient client)
        {
            this.client = client;
            this.userId = Guid.NewGuid();
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await client.GetProducts();
            return View(products);

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await client.GetProduct((int)id);

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Image,ManufacturerId")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await client.CreateProduct(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var originalProduct = await client.GetProduct((int)id);
            var product = new ProductViewModel
            {
                Image = originalProduct.Image,
                ManufacturerId = originalProduct.Manufacturer.Id,
                Name = originalProduct.Name
            };

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,ManufacturerId")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await client.ModifyProduct(id, product);
                }
                catch
                {
                    return NotFound(); // TODO
                }

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await client.GetProduct((int)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberOfModifiedEntities = await client.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
