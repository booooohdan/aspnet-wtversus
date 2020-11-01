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
    public class HelisController : Controller
    {
        private readonly AppDbContext _context;

        public HelisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Helis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Helis.ToListAsync());
        }

        // GET: Helis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heli = await _context.Helis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heli == null)
            {
                return NotFound();
            }

            return View(heli);
        }

        // GET: Helis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstFlyYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeed,ClimbTo1000,Turn360,EnginePower,Weight,AGMCount,AGMArmorPenetration,AGMSpeed,AGMRange,AAMCount,ASMCount,BombLoad,OffensiveWeapon,AGMissile,AutoAGMissile,AAMissile,ASMissile,Bomb,TurningCannon,FixedCannon,IRCM,HIRSS,Flares,RWR,LaserDesignator,CCIP,ThermalGunner,AirRadar,GroundRadar,OpticalTracking")] Heli heli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(heli);
        }

        // GET: Helis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heli = await _context.Helis.FindAsync(id);
            if (heli == null)
            {
                return NotFound();
            }
            return View(heli);
        }

        // POST: Helis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstFlyYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeed,ClimbTo1000,Turn360,EnginePower,Weight,AGMCount,AGMArmorPenetration,AGMSpeed,AGMRange,AAMCount,ASMCount,BombLoad,OffensiveWeapon,AGMissile,AutoAGMissile,AAMissile,ASMissile,Bomb,TurningCannon,FixedCannon,IRCM,HIRSS,Flares,RWR,LaserDesignator,CCIP,ThermalGunner,AirRadar,GroundRadar,OpticalTracking")] Heli heli)
        {
            if (id != heli.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeliExists(heli.Id))
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
            return View(heli);
        }

        // GET: Helis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heli = await _context.Helis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (heli == null)
            {
                return NotFound();
            }

            return View(heli);
        }

        // POST: Helis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heli = await _context.Helis.FindAsync(id);
            _context.Helis.Remove(heli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeliExists(int id)
        {
            return _context.Helis.Any(e => e.Id == id);
        }
    }
}
