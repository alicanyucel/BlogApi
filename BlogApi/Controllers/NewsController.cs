using BlogApi.Context;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly NewsletterDb _context;
    public NewsController(NewsletterDb context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _context.Users.ToListAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result=await _context.Users.FindAsync(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post(Newsletter newsletter)
    {
        await _context.Newsletter.AddAsync(newsletter);
        await _context.SaveChangesAsync();
        return Ok("Haber kaydı yapıldı");
    }
    [HttpPut]
    public async Task<IActionResult> Put(Newsletter newsletter)
    {
        _context.Newsletter.Update(newsletter);
        await _context.SaveChangesAsync();
        return Ok("haber güncellendi");
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result=await _context.Newsletter.FindAsync(id);
        _context.Newsletter.Remove(result);
        await _context.SaveChangesAsync();
        return Ok("haber silindi");

    }
}

