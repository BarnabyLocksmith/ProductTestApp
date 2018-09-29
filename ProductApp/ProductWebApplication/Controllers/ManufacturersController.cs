namespace ProductWebApplication.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ProductWebApplication.DataServiceClients;
    using ProductWebApplication.Models;

    public class ManufacturersController : Controller
    {
        private readonly IDataServiceClient client;
        private readonly Guid userId;

        public ManufacturersController(IDataServiceClient client)
        {
            this.client = client;
            this.userId = Guid.NewGuid();
        }

        // GET: Manufacturers
        public async Task<IActionResult> Index()
        {
            return View(await client.GetManufacturers());
        }

        // GET: Manufacturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await client.GetManufacturer((int)id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Logo")] ManufacturerViewModel manufacturer)
        {
            if (ModelState.IsValid)
            {
                var response = await client.CreateManufacturer(manufacturer); //TODO Userid?

                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await client.GetManufacturer((int)id);

            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo")] ManufacturerViewModel manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var response = await client.ModifyManufacturer(id, manufacturer);

                }
                catch (DbUpdateConcurrencyException)
                {
                    throw; // TODO
                }
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await client.GetManufacturer((int)id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var numberOfModifiedEntities = await client.DeleteManufacturer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
