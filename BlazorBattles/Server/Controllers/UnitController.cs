﻿using BlazorBattles.Server.Data;
using BlazorBattles.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorBattles.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UnitController : Controller
{
    private readonly DataContext _context;

    public UnitController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUnits()
    {
        var units = await _context.Units.ToListAsync();
        return Ok(units);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUnit(Unit unit)
    {
        await _context.Units.AddAsync(unit);
        await _context.SaveChangesAsync();
        return Ok(await _context.Units.ToListAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUnit(int id, Unit unit)
    {
        var dbUnit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);
        if (dbUnit == null) return NotFound("Unit not found!");
        dbUnit.Title = unit.Title;
        dbUnit.Attack = unit.Attack;
        dbUnit.Defense = unit.Defense;
        dbUnit.BananaCost = unit.BananaCost;
        dbUnit.HitPoints = unit.HitPoints;
        dbUnit.BananaCost = unit.BananaCost;
        await _context.SaveChangesAsync();
        return Ok(dbUnit);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUnit(int id)
    {
        var dbUnit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);
        if (dbUnit == null) return NotFound("Unit not found!");
        _context.Units.Remove(dbUnit);
        await _context.SaveChangesAsync();
        return Ok(await _context.Units.ToListAsync());
    }

}