using APIPersonajesAWS.Models;
using APIPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;
        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo=repo;
        }

        [HttpGet]
        [Route("Personajes")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonaje(id);
        }

        [HttpPost]
        [Route("[action]/{nombre}/{imagen}")]
        public async Task<ActionResult>InsertPersonaje(string nombre,string imagen)
        {
            await this.repo.CreatePersonajeAsync(nombre, imagen);
            return Ok();
        }
        [HttpPut]
        [Route("[action]/{id}/{nombre}/{imagen}")]
        public async Task<ActionResult> UpdatePersonaje(int id, string nombre, string imagen)
        {
            await this.repo.UpdatePersonaje(id, nombre, imagen);
            return Ok();
        }
    }
}
