using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapaDatos.Data;
using CapaDatos.Seguridad;

namespace SuerveyAPI.Data
{
    public class SuerveyAPIContext : DbContext
    {
        public SuerveyAPIContext (DbContextOptions<SuerveyAPIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EncuestaSelect>().ToSqlQuery(@"EXEC SPR_EncuestasSeleccionar").HasNoKey();
            modelBuilder.Entity<EncuestasTiempoSelec>().ToSqlQuery("EXEC SPR_EncuestasTiempoSeleccionar").HasNoKey();
            modelBuilder.Entity<PreguntasResultadoSelect>().ToSqlQuery("EXEC SPR_PreguntasResultadoSeleccionar").HasNoKey();
            modelBuilder.Entity<PreguntasSelect>().ToSqlQuery("EXEC SPR_PreguntasSeleccionar").HasNoKey();
            modelBuilder.Entity<PreguntasTiempoSelect>().ToSqlQuery("EXEC SPR_PreguntasTiempoSeleccionar").HasNoKey();
            modelBuilder.Entity<RespuestasSelect>().ToSqlQuery("EXEC SPR_RespuestasSeleccionar").HasNoKey();
        }

        public DbSet<CapaDatos.Data.Categorias>? Categorias { get; set; }

        public DbSet<CapaDatos.Data.Encuestas>? Encuestas { get; set; }

        public DbSet<CapaDatos.Seguridad.Usuarios>? Usuarios { get; set; }

        public DbSet<CapaDatos.Seguridad.Perfiles>? Perfiles { get; set; }

        public DbSet<CapaDatos.Seguridad.Permisos>? Permisos { get; set; }

        public DbSet<CapaDatos.Data.Preguntas>? Preguntas { get; set; }

        public DbSet<CapaDatos.Data.RegistroEncuesta>? RegistroEncuesta { get; set; }

        public DbSet<CapaDatos.Data.RegistroEncuestaPregunta>? RegistroEncuestaPregunta { get; set; }

        public DbSet<CapaDatos.Data.RegistroPreguntaRespuesta>? RegistroPreguntaRespuesta { get; set; }

        public DbSet<CapaDatos.Data.RegistroUsuarioEncuesta>? RegistroUsuarioEncuesta { get; set; }

        public DbSet<CapaDatos.Seguridad.Acciones>? Acciones { get; set; }

        public DbSet<CapaDatos.Data.Respuestas>? Respuestas { get; set; }
    }
}
