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
        var result = await _context.Newsletter.ToListAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result=await _context.Newsletter.FindAsync(id);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post(Newsletter newsletter)
    {
        newsletter.CreatedDate = DateTime.Now;
        await _context.Newsletter.AddAsync(newsletter);
        await _context.SaveChangesAsync();
        var results = new ResultModel()
        {
            Message = "ekleme işlemi başarılı"
        };
        return Ok(results);
    }
    [HttpPut]
    public async Task<IActionResult> Put(Newsletter newsletter)
    {
        _context.Newsletter.Update(newsletter);
        await _context.SaveChangesAsync();
        var result = new ResultModel()
        {
            Message = "guncelleme işlemi nbaşarılı"
        };
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result=await _context.Newsletter.FindAsync(id);
        _context.Newsletter.Remove(result);
        await _context.SaveChangesAsync();
        var resul = new ResultModel()
        {
            Message = "silme işlemi nbaşarılı"
        };
        return Ok(result);

    }
}

