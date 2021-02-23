using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Models;

namespace WEBAPI.Services
{
    public class ProductService
    {
        private readonly PracticaWEBAPIContext _productoContext;
        public ProductService(PracticaWEBAPIContext productoContext)
        {
            _productoContext = productoContext;
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            var contactList = await _productoContext.Producto.ToListAsync();
            return contactList;
        }

        public async Task<List<Producto>> ObtenerProductos(string modelo)
        {
            var contactList = await _productoContext.Producto.Where(m => m.Modelo == modelo || m.Sku == modelo)
                .ToListAsync();
            return contactList;
        }
        public async Task <Producto> ObtenerProducto(int id)
        {
            var producto = await _productoContext.Producto.FindAsync(id);
            return producto;
        }

        public async Task <bool> AgregarProducto(Producto producto)
        {
            try
            {
               await _productoContext.Producto.AddAsync(producto);
               await _productoContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task <bool> ActualizarProducto(Producto nuevoProducto)
        {
            try
            {
                var producto = await _productoContext.Producto.FindAsync(nuevoProducto.ProductoId);
                producto.Sku = nuevoProducto.Sku;
                producto.Fert = nuevoProducto.Fert;
                producto.Modelo = nuevoProducto.Modelo;
                producto.Tipo = nuevoProducto.Tipo;
                producto.Serie = nuevoProducto.Serie;
                producto.Fecha = nuevoProducto.Fecha;
                await _productoContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task <bool> EliminarProducto(int id)
        {
            try
            {
                var producto = await _productoContext.Producto.FindAsync(id);

                _productoContext.Remove(producto);
                await _productoContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
