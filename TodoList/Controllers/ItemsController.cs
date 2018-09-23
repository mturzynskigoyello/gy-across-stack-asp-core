using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Web.Models;

namespace TodoList.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly TodoItemsDbContext _context;

        public ItemsController(TodoItemsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
        {
            return await _context.TodoItems
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TodoItem))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                return item;
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<TodoItem>> Create([FromBody] TodoItem item)
        {
            item.CreatedOn = DateTime.UtcNow;
            item.Id = default(int);
            await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { item.Id}, item);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Update(int id, [FromBody] TodoItem item)
        {
            var entity = await _context.TodoItems.FindAsync(id);
            if (entity != null)
            {
                entity.Title = item.Title;
                entity.Content = item.Content;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _context.TodoItems.FindAsync(id);
            if (entity != null)
            {
                _context.TodoItems.Remove(entity);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
