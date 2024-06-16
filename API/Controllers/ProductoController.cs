using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductoController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            var lista = await _db.Productos
                            .Include(c => c.Categoria)
                            .Include(m => m.Marca)
                            .Select(s => new ProductoDto{
                                NombreProducto = s.Nombre,
                                Categoria = s.Categoria.Nombre,
                                Marca = s.Marca.Nombre,
                                Precio = s.Precio,
                                Costo = s.Costo
                            }).ToListAsync();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProductoById(int id)
        {
            var producto = await _db.Productos
                            .Include(c => c.Categoria)
                            .Include(m => m.Marca)
                            .FirstOrDefaultAsync(f => f.Id == id);

            if (producto == null){
                return NotFound();
            }

        return Ok(new ProductoDto {
                NombreProducto = producto.Nombre,
                Categoria = producto.Categoria.Nombre,
                Marca = producto.Marca.Nombre,
                Precio = producto.Precio,
                Costo = producto.Costo
            });
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            try
            {
                await _db.Productos.AddAsync(producto);
                await _db.SaveChangesAsync();
                return CreatedAtAction("GetProductoById",new {id = producto.Id }, producto);
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProducto(int id, Producto producto){
            try
            {
                if (id != producto.Id){
                    return BadRequest("No se encontró el producto a modificar.");
                }
                var productoDb = await _db.Productos.FindAsync(id);
                if (productoDb == null){
                    return NotFound("No se encontró el producto a modificar.");
                }
                productoDb.Nombre = producto.Nombre;
                producto.CategoriaId = producto.CategoriaId;
                producto.MarcaId = producto.MarcaId;
                producto.Precio = producto.Precio;
                producto.Costo = producto.Costo;

                await _db.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id){
            try
            {
                var producto = await _db.Productos.FindAsync(id);
                if (producto == null){
                    return NotFound("Producto no encontrado");
                }
                _db.Productos.Remove(producto);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}