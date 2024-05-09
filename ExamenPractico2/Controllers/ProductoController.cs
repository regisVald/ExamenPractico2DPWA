using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExamenPractico2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly List<Producto> _productos = new List<Producto>() {

            new Producto { Id = 1, Nombre = "Producto 1", Descripcion = "Descripción del producto 1" },
            new Producto { Id = 2, Nombre = "Producto 2", Descripcion = "Descripción del producto 2" }
        
    };

        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _productos;
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = _productos.Find(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto producto)
        {
            _productos.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult<Producto> Put(int id, [FromBody] Producto producto)
        {
            var existingProducto = _productos.Find(p => p.Id == id);
            if (existingProducto == null)
            {
                return NotFound();
            }

            existingProducto.Nombre = producto.Nombre;
            existingProducto.Descripcion = producto.Descripcion;

            // Devolver el producto actualizado junto con un mensaje de éxito
            return Ok(new { Message = "Producto actualizado correctamente", Producto = existingProducto });
        }


        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = _productos.Find(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            _productos.Remove(producto);
            return Ok(new { Message = "Producto eliminado correctamente", Producto = producto });
        }

    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
