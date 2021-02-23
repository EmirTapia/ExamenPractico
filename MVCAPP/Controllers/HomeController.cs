using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using WEBAPI.Models;

namespace MVCAPP.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string modelo)
        {
            var httpClient = new HttpClient();
            var productsList = new List<Producto>();
            string json = string.Empty;
            if (string.IsNullOrEmpty(modelo))
            {
                json = await httpClient.GetStringAsync("https://localhost:44370/api/productos");
            }
            else
            {
                json = await httpClient.GetStringAsync(string.Format("https://localhost:44370/api/productos/filtro/{0}",modelo));
            }
            productsList = JsonConvert.DeserializeObject<List<Producto>>(json);
            return View(productsList);
        }
        

        public async Task<ActionResult> Create()
        {
          return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Producto producto, int tipo)
        {
            producto.Tipo = Convert.ToInt16(tipo);
            var httpClient = new HttpClient();


            var myContent = JsonConvert.SerializeObject(producto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var json = await httpClient.PostAsync("https://localhost:44370/api/productos/agregar", byteContent);
            
            return RedirectToAction("Index");
        }
       
        public async Task<ActionResult> Editar(int? id)
        {
            var producto = new Producto();
            var httpClient = new HttpClient();
            string json = string.Empty;
            json = await httpClient.GetStringAsync(string.Format("https://localhost:44370/api/productos/detalle/{0}",id));
            producto = JsonConvert.DeserializeObject<Producto>(json);
            return View(producto);
        }

        public async Task<ActionResult> Details(int? id)
        {
            var producto = new Producto();
            var httpClient = new HttpClient();
            string json = string.Empty;
            json = await httpClient.GetStringAsync(string.Format("https://localhost:44370/api/productos/detalle/{0}", id));
            producto = JsonConvert.DeserializeObject<Producto>(json);
            return View(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Producto producto)
        {
            producto.Tipo = Convert.ToInt16(producto.Tipo);
            var httpClient = new HttpClient();

            var myContent = JsonConvert.SerializeObject(producto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var json = await httpClient.PutAsync("https://localhost:44370/api/productos/editar/", byteContent);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int? id)
        {
            var producto = new Producto();
            var httpClient = new HttpClient();
            string json = string.Empty;
            json = await httpClient.GetStringAsync(string.Format("https://localhost:44370/api/productos/detalle/{0}", id));
            producto = JsonConvert.DeserializeObject<Producto>(json);
            return View(producto);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            
            var httpClient = new HttpClient();
            var json = await httpClient.DeleteAsync(string.Format("https://localhost:44370/api/productos/eliminar/{0}",id));

            return RedirectToAction("Index");
        }
    }
}