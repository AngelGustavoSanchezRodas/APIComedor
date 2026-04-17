using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIComedor.model;

[Route("api/[controller]")]
[ApiController]
public class MenuComedorController : ControllerBase
{
    private readonly AppDbContext _context;

    public MenuComedorController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/MenuComedor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuComedor_13449>>> GetMenus()
    {
        return await _context.MenuComedor.ToListAsync();
    }

    // GET: api/MenuComedor/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MenuComedor_13449>> GetMenu(int id)
    {
        var menu = await _context.MenuComedor.FindAsync(id);

        if (menu == null)
            return NotFound();

        return menu;
    }

    // POST: api/MenuComedor
    [HttpPost]
    public async Task<ActionResult<MenuComedor_13449>> PostMenu(MenuComedor_13449 menu)
    {
        _context.MenuComedor.Add(menu);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
    }

    // PUT: api/MenuComedor/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMenu(int id, MenuComedor_13449 menu)
    {
        if (id != menu.Id)
            return BadRequest();

        _context.Entry(menu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MenuExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/MenuComedor/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        var menu = await _context.MenuComedor.FindAsync(id);

        if (menu == null)
            return NotFound();

        _context.MenuComedor.Remove(menu);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MenuExists(int id)
    {
        return _context.MenuComedor.Any(e => e.Id == id);
    }
}