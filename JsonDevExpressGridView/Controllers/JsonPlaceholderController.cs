using JsonDevExpressGridView.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JsonDevExpressGridView.Controllers
{
    public class JsonPlaceholderController : Controller
    {
        // GET: JsonPlaceholder
        public async Task<ActionResult> Index()
        {
            return View(await getData());
        }

        /// <summary>
        /// retrieves the data from https://jsonplaceholder.typicode.com/todos
        /// </summary>
        /// <returns>Task<List<JsonPlaceholderModel>></returns>
        private async Task<List<JsonPlaceholderModel>> getData()
        {
            using(var cliente = new HttpClient())
            {
                var respuesta = await cliente.GetAsync("https://jsonplaceholder.typicode.com/todos"); //retrieve the data

                var contenido = await respuesta.Content.ReadAsStringAsync();

                var datos = JsonConvert.DeserializeObject<List<JsonPlaceholderModel>>(contenido); 
                return datos;
            }
        }
    }
}