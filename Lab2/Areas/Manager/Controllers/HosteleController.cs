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
    public class HosteleController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;

        public HosteleController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _context = unitOfWork;
            _mapper = mapper;
        }

        // GET: Hostele
        public async Task<IActionResult> Index()
        {
            var Hostele = await _context.Hostel.GetAll();

            var HostelViewModel = _mapper.Map<IEnumerable<Hostel>, IEnumerable<HostelViewModel>>(Hostele);

            return View(HostelViewModel);
        }

        // GET: Hostele/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Hostel = await _context.Hostel
                .Find(m => m.Id == id);

            var HostelViewModel = _mapper.Map<HostelViewModel>(Hostel);

            if (Hostel == null)
            {
                return NotFound();
            }

            return View(HostelViewModel);
        }

        // GET: Hostele/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hostele/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis")] HostelViewModel HostelViewModel)
        {
            var Hostel = _mapper.Map<Hostel>(HostelViewModel);
            if (ModelState.IsValid)
            {
                _context.Hostel.Add(Hostel);
                await _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(HostelViewModel);
        }

        // GET: Hostele/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Hostel = await _context.Hostel.Get(id);

            var HostelViewModel = _mapper.Map<EditViewModel>(Hostel);
            if (Hostel == null)
            {
                return NotFound();
            }
            return View(HostelViewModel);
        }

        // POST: Hostele/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis")] HostelViewModel HostelViewModel)
        {
            var Hostel = _mapper.Map<Hostel>(HostelViewModel);
            if (id != HostelViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Hostel.Update(Hostel);
                    await _context.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelExists(HostelViewModel.Id))
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
            return View(Hostel);
        }

        // GET: Hostele/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Hostel = await _context.Hostel
                .Find(m => m.Id == id);
            if (Hostel == null)
            {
                return NotFound();
            }

            return View(Hostel);
        }

        // POST: Hostele/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Hostel = await _context.Hostel.Get(id);
            _context.Hostel.Remove(Hostel);
            await _context.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelExists(int id)
        {
            return _context.Hostel.CheckIfExists(e => e.Id == id);
        }
    }
}
