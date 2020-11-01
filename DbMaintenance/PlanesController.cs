using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WTVersus.Models;

namespace DbMaintenance
{
    public class PlanesController : Controller
    {
        private readonly AppDbContext _context;

        public PlanesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planes.ToListAsync());
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Planes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }

        // GET: Planes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstFlyYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeedAt0,MaxSpeedAt5000,Climb,BombLoad,TurnAt0,EnginePower,Weight,Flutter,BurstMass,CourseWeapon,OptimalAilerons,OptimalElevator,OptimalAlitude,ASMissile,AAMissile,AAFoxOneMissile,AGMissile,HCannon,HBomb,HTorpedo,HMine,WrongMusic,Turrel,RWR,Flares,AirBrake,Parachute,Tailhook,AirRadar,GroundRadar,CCIP,GSuit,CCRP")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plane);
        }

        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Planes.FindAsync(id);
            if (plane == null)
            {
                return NotFound();
            }
            return View(plane);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstFlyYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeedAt0,MaxSpeedAt5000,Climb,BombLoad,TurnAt0,EnginePower,Weight,Flutter,BurstMass,CourseWeapon,OptimalAilerons,OptimalElevator,OptimalAlitude,ASMissile,AAMissile,AAFoxOneMissile,AGMissile,HCannon,HBomb,HTorpedo,HMine,WrongMusic,Turrel,RWR,Flares,AirBrake,Parachute,Tailhook,AirRadar,GroundRadar,CCIP,GSuit,CCRP")] Plane plane)
        {
            if (id != plane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaneExists(plane.Id))
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
            return View(plane);
        }

        // GET: Planes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plane = await _context.Planes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plane == null)
            {
                return NotFound();
            }

            return View(plane);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plane = await _context.Planes.FindAsync(id);
            _context.Planes.Remove(plane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaneExists(int id)
        {
            return _context.Planes.Any(e => e.Id == id);
        }
    }
}
