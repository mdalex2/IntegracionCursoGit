using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Models.Entidades;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProductoDto>> GetProductos()
        {
            return ProductoData.listaProductos
            .Select(s => new ProductoDto{
                NombreProducto = s.NombreProducto,
                Categoria = s.Categoria,
                Marca = s.Marca,
                Precio = s.Precio,
                Costo = s.Costo
            }).ToList();
        }
    }
}