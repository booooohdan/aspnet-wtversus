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
    public class ShipsController : Controller
    {
        private readonly AppDbContext _context;

        public ShipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ships.ToListAsync());
        }

        // GET: Ships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // GET: Ships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstLaunchYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeed,ReverseSpeed,Acceleration,BrakingTime,Turn360,Displacement,CrewCount,ArmorTower,ArmorHull,MainCaliberSize,MainCaliberReload,MainCaliberName,AUCaliberName,AACaliberName,TorpedoItem,TorpedoMaxSpeed,TorpedoTNT,IsHaveDepthCharge,IsHaveTorpedo,IsHaveRocket,IsHaveMine,IsHaveAirRadar,IsHaveShipRadar,MC_SAP,MC_AP,MC_APHE,MC_APCR,MC_HE,MC_HEVT,MC_HEDF,MC_FOG,MC_Shrapnel,AU_SAP,AU_AP,AU_APHE,AU_APCR,AU_HE,AU_HEVT,AU_HEDF,AU_FOG,AU_Shrapnel,AAA_SAP,AAA_AP,AAA_APHE,AAA_APCR,AAA_HE,AAA_HEVT,AAA_HEDF,AAA_FOG,AAA_Shrapnel")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ship);
        }

        // GET: Ships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            return View(ship);
        }

        // POST: Ships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstLaunchYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeed,ReverseSpeed,Acceleration,BrakingTime,Turn360,Displacement,CrewCount,ArmorTower,ArmorHull,MainCaliberSize,MainCaliberReload,MainCaliberName,AUCaliberName,AACaliberName,TorpedoItem,TorpedoMaxSpeed,TorpedoTNT,IsHaveDepthCharge,IsHaveTorpedo,IsHaveRocket,IsHaveMine,IsHaveAirRadar,IsHaveShipRadar,MC_SAP,MC_AP,MC_APHE,MC_APCR,MC_HE,MC_HEVT,MC_HEDF,MC_FOG,MC_Shrapnel,AU_SAP,AU_AP,AU_APHE,AU_APCR,AU_HE,AU_HEVT,AU_HEDF,AU_FOG,AU_Shrapnel,AAA_SAP,AAA_AP,AAA_APHE,AAA_APCR,AAA_HE,AAA_HEVT,AAA_HEDF,AAA_FOG,AAA_Shrapnel")] Ship ship)
        {
            if (id != ship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.Id))
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
            return View(ship);
        }

        // GET: Ships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // POST: Ships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(int id)
        {
            return _context.Ships.Any(e => e.Id == id);
        }
    }
}
