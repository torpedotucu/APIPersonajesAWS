using APIPersonajesAWS.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPersonajesAWS.Data
{
    public class PersonajesContext: DbContext
    {
        public PersonajesContext(DbContextOptions<PersonajesContext> options) : base(options)
        {
        }

        public DbSet<Personaje> Personajes { get; set; }
    }
}
