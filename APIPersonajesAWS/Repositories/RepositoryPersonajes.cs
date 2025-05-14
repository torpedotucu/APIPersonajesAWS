using APIPersonajesAWS.Data;
using APIPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace APIPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;
        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context=context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje>FindPersonaje(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje==id);
        }

        private async Task<int> GetMaxIdPersonajeAsync()
        {
            return await this.context.Personajes.MaxAsync(x => x.IdPersonaje)+1;
        }

        public async Task CreatePersonajeAsync(string nombre, string imagen)
        {
            Personaje p = new Personaje();
            p.IdPersonaje=await this.GetMaxIdPersonajeAsync();
            p.Nombre=nombre;
            p.Imagen=imagen;
            await this.context.Personajes.AddAsync(p);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonaje(int id, string nombre, string imagen)
        {
            Personaje p = await this.FindPersonaje(id);
            p.Nombre=nombre;
            p.Imagen=imagen;
            await this.context.SaveChangesAsync();
        }
    }
}
