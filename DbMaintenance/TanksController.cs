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
    public class TanksController : Controller
    {
        private readonly AppDbContext _context;

        public TanksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tanks.ToListAsync());
        }

        // GET: Tanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.Tanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);
        }

        // GET: Tanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstRideYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeedAtRoad,MaxSpeedAtTerrain,MaxReverseSpeed,AccelerationTo100,TurnTurretTime,TurnHullTime,EnginePower,Weight,Cannon,Penetration,ShellSpeed,ReloadTime,UpAimAngle,DownAimAngle,ReducedArmorFrontTurret,ReducedArmorTopSheet,ReducedArmorBottomSheet,ShellAP,ShellAPHE,ShellHE,ShellAPCR,ShellAPDS,ShellAPFSDS,ShellHEAT,ShellHEATFS,ShellShrapnel,ShellHESH,ShellATGM,ShellSSM,ShellHEATGRENADE,ShellHEVT,ShellSAM,ShellSmoke,ShellATGMHE,ShellATGMTandem,ShellATGMHEVT,ShellVOG,AddOnArmor,ReactiveArmor,Hydropneumatic,IRSpotlight,AirSearchRadar,AirLockRadar,TankSearchRadar,GrenadeSmoke,ExhaustSmoke,Amphibious,AutoLoader,AAMachineGun,Stabilizer,HullBreak,NVDGunner,ThermalGunner,NVDCommander,ThermalCommander,RWR")] Tank tank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tank);
        }

        // GET: Tanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.Tanks.FindAsync(id);
            if (tank == null)
            {
                return NotFound();
            }
            return View(tank);
        }

        // POST: Tanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleId,Image,Name,Nation,Rank,BR,Type,Class,FirstRideYear,RepairCost,ViewCount,WikiLink,WikiDescription,MaxSpeedAtRoad,MaxSpeedAtTerrain,MaxReverseSpeed,AccelerationTo100,TurnTurretTime,TurnHullTime,EnginePower,Weight,Cannon,Penetration,ShellSpeed,ReloadTime,UpAimAngle,DownAimAngle,ReducedArmorFrontTurret,ReducedArmorTopSheet,ReducedArmorBottomSheet,ShellAP,ShellAPHE,ShellHE,ShellAPCR,ShellAPDS,ShellAPFSDS,ShellHEAT,ShellHEATFS,ShellShrapnel,ShellHESH,ShellATGM,ShellSSM,ShellHEATGRENADE,ShellHEVT,ShellSAM,ShellSmoke,ShellATGMHE,ShellATGMTandem,ShellATGMHEVT,ShellVOG,AddOnArmor,ReactiveArmor,Hydropneumatic,IRSpotlight,AirSearchRadar,AirLockRadar,TankSearchRadar,GrenadeSmoke,ExhaustSmoke,Amphibious,AutoLoader,AAMachineGun,Stabilizer,HullBreak,NVDGunner,ThermalGunner,NVDCommander,ThermalCommander,RWR")] Tank tank)
        {
            if (id != tank.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TankExists(tank.Id))
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
            return View(tank);
        }

        // GET: Tanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _context.Tanks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tank = await _context.Tanks.FindAsync(id);
            _context.Tanks.Remove(tank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TankExists(int id)
        {
            return _context.Tanks.Any(e => e.Id == id);
        }
    }
}
