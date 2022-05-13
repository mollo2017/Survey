using CapaDatos.Data;
using CapaDatos.Seguridad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Conexion
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //Esquema de seguridad
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Acciones> Acciones { get; set; }
        public DbSet<Perfiles> Perfiles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }

        //Esquema de datos
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<CtrlEncuestaPregunta> CtrlEncuestaPregunta { get; set; }
        public DbSet<CtrlPreguntaRespuesta> CtrlPreguntaRespuesta { get; set; }
        public DbSet<Encuestas> Encuestas { get; set; }
        public DbSet<Preguntas> Preguntas { get; set; }
        public DbSet<Respuestas> Respuestas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuarios>(entity => {
                entity.HasIndex(e => e.Correo).IsUnique();
            });
        }
    }
}
