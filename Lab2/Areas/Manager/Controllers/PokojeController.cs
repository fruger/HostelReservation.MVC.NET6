using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Lab2.ViewModel;
using Lab2.Repositories;


namespace Lab2.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class PokojeController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public PokojeController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _context = unitOfWork;
            _mapper = mapper;
        }

        // GET: Pokoje
        public async Task<IActionResult> Index()
        {
            var pokoje = await _context.Pokoj.GetAll(includeProperties: "Hostel");

            var pokojViewModel = _mapper.Map<IEnumerable<Pokoj>, IEnumerable<PokojViewModel>>(pokoje);

            return View(pokojViewModel);
        }

        // GET: Pokoje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = await _context.Pokoj
                .Find(m => m.Id == id);

            var pokojViewModel = _mapper.Map<PokojViewModel>(pokoj);

            if (pokoj == null)
            {
                return NotFound();
            }

            return View(pokojViewModel);
        }

        // GET: Pokoje/Create
        public async Task<IActionResult> Create()
        {
            var listaHosteli = await _context.Hostel.GetAll();

            //var selectLyst = new List<SelectListItem>();
            //foreach (var item in listaHosteli)
            //{
            //    selectLyst.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Nazwa});
            //}
            //ViewBag.SelectLyst = selectLyst;
            var pokojvm = new CreateViewModel();
            pokojvm.ListaHosteli = new SelectList(listaHosteli, "Id", "Nazwa", pokojvm.HostelId);
            return View(pokojvm);
        }

        // POST: Pokoje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vmcId,Hostel,vmcNazwa,vmcOpis,vmcCenaZaNocleg,vmcIloscLozek,vmcRodzajPokoju,HostelId")]
        CreateViewModel pokojViewModel)
        {
            var pokoj = _mapper.Map<Pokoj>(pokojViewModel);

            if (ModelState.IsValid)
            {
                _context.Pokoj.Add(pokoj);
                await _context.Save();
                return RedirectToAction(nameof(Index));
            }

            var listaHosteli = await _context.Hostel.GetAll();


            pokojViewModel.ListaHosteli = new SelectList(listaHosteli, "Id", "Nazwa", pokojViewModel.HostelId);

            return View(pokojViewModel);
        }


        // GET: Pokoje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = await _context.Pokoj.Get(id);

            var pokojViewModel = _mapper.Map<EditViewModel>(pokoj);

            var listaHostel = await _context.Hostel.GetAll();

            pokojViewModel.ListaHosteli = new SelectList(listaHostel, "Id", "Nazwa", pokojViewModel.HostelId);


            if (pokoj == null)
            {
                return NotFound();
            }
            return View(pokojViewModel);
        }

        // POST: Pokoje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vmeId,HostelId,vmeNazwa,vmeOpis,vmeCenaZaNocleg,vmeIloscLozek,vmeRodzajPokoju")]
        EditViewModel pokojViewModel)
        {
            var pokoj = _mapper.Map<Pokoj>(pokojViewModel);
            if (id != pokoj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Pokoj.Update(pokoj);
                    await _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokojExists(pokoj.Id))
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

            var listaHosteli = await _context.Hostel.GetAll();

            pokojViewModel.ListaHosteli = new SelectList(listaHosteli, "Id", "Nazwa", pokojViewModel.HostelId);

            return View(pokoj);
        }

        // GET: Pokoje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokoj = await _context.Pokoj
                .Find(m => m.Id == id);
            if (pokoj == null)
            {
                return NotFound();
            }

            return View(pokoj);
        }

        // POST: Pokoje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokoj = await _context.Pokoj.Get(id);
            _context.Pokoj.Remove(pokoj);
            await _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PokojExists(int id)
        {
            return _context.Pokoj.CheckIfExists(e => e.Id == id);
        }
    }
}
