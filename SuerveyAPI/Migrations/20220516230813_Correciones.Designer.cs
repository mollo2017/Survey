// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuerveyAPI.Data;

#nullable disable

namespace SuerveyAPI.Migrations
{
    [DbContext(typeof(SuerveyAPIContext))]
    [Migration("20220516230813_Correciones")]
    partial class Correciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CapaDatos.Data.Categorias", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("CapaDatos.Data.CtrlEncuestaPregunta", b =>
                {
                    b.Property<int>("IdCtrlEncuestaPregunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCtrlEncuestaPregunta"), 1L, 1);

                    b.Property<int?>("EncuestasIdEncuesta")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdEncuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<int?>("PreguntasIdPregunta")
                        .HasColumnType("int");

                    b.HasKey("IdCtrlEncuestaPregunta");

                    b.HasIndex("EncuestasIdEncuesta");

                    b.HasIndex("PreguntasIdPregunta");

                    b.ToTable("CtrlEncuestaPregunta");
                });

            modelBuilder.Entity("CapaDatos.Data.CtrlPreguntaRespuesta", b =>
                {
                    b.Property<int>("IdCtrlPreguntaRespuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCtrlPreguntaRespuesta"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<int>("IdRespuesta")
                        .HasColumnType("int");

                    b.Property<bool?>("IsRespuesta")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<int?>("PreguntasIdPregunta")
                        .HasColumnType("int");

                    b.Property<int?>("RespuestasIdRespuesta")
                        .HasColumnType("int");

                    b.HasKey("IdCtrlPreguntaRespuesta");

                    b.HasIndex("PreguntasIdPregunta");

                    b.HasIndex("RespuestasIdRespuesta");

                    b.ToTable("CtrlPreguntaRespuesta");
                });

            modelBuilder.Entity("CapaDatos.Data.Encuestas", b =>
                {
                    b.Property<int>("IdEncuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEncuesta"), 1L, 1);

                    b.Property<int?>("CategoriasIdCategoria")
                        .HasColumnType("int");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEncuesta");

                    b.HasIndex("CategoriasIdCategoria");

                    b.ToTable("Encuestas");
                });

            modelBuilder.Entity("CapaDatos.Data.EncuestaSelect", b =>
                {
                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdEncuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToSqlQuery("EXEC SPR_EncuestasSeleccionar");
                });

            modelBuilder.Entity("CapaDatos.Data.EncuestasTiempoSelec", b =>
                {
                    b.Property<string>("Encuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEncuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("TiempoEncuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToSqlQuery("EXEC SPR_EncuestasTiempoSeleccionar @IdEncuesta, @IdUsuario");
                });

            modelBuilder.Entity("CapaDatos.Data.Preguntas", b =>
                {
                    b.Property<int>("IdPregunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPregunta"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPregunta");

                    b.ToTable("Preguntas");
                });

            modelBuilder.Entity("CapaDatos.Data.PreguntasResultadoSelect", b =>
                {
                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToSqlQuery("EXEC SPR_PreguntasResultadoSeleccionar");
                });

            modelBuilder.Entity("CapaDatos.Data.PreguntasSelect", b =>
                {
                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToSqlQuery("EXEC SPR_PreguntasSeleccionar");
                });

            modelBuilder.Entity("CapaDatos.Data.PreguntasTiempoSelect", b =>
                {
                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TiempoRespuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToSqlQuery("EXEC SPR_PreguntasTiempoSeleccionar");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroEncuesta", b =>
                {
                    b.Property<int>("IdRegistroEncuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistroEncuesta"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdRegistroUsuarioEncuesta")
                        .HasColumnType("int");

                    b.Property<string>("RegistoEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta")
                        .HasColumnType("int");

                    b.Property<DateTime>("TiempoRegistro")
                        .HasColumnType("datetime2");

                    b.HasKey("IdRegistroEncuesta");

                    b.HasIndex("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

                    b.ToTable("RegistroEncuesta");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroEncuestaPregunta", b =>
                {
                    b.Property<int>("IdRegistroEncuestaPregunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistroEncuestaPregunta"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<int>("IdRegistroUsuarioEncuesta")
                        .HasColumnType("int");

                    b.Property<int>("PreguntasIdPregunta")
                        .HasColumnType("int");

                    b.Property<string>("RegistoEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta")
                        .HasColumnType("int");

                    b.Property<DateTime>("TiempoRegistro")
                        .HasColumnType("datetime2");

                    b.HasKey("IdRegistroEncuestaPregunta");

                    b.HasIndex("PreguntasIdPregunta");

                    b.HasIndex("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

                    b.ToTable("RegistroEncuestaPregunta");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroPreguntaRespuesta", b =>
                {
                    b.Property<int>("IdRegistroPreguntaRespuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistroPreguntaRespuesta"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPregunta")
                        .HasColumnType("int");

                    b.Property<int>("IdRegistroUsuarioEncuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdRespuesta")
                        .HasColumnType("int");

                    b.Property<int?>("PreguntasIdPregunta")
                        .HasColumnType("int");

                    b.Property<int?>("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta")
                        .HasColumnType("int");

                    b.Property<int?>("RespuestasIdRespuesta")
                        .HasColumnType("int");

                    b.HasKey("IdRegistroPreguntaRespuesta");

                    b.HasIndex("PreguntasIdPregunta");

                    b.HasIndex("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

                    b.HasIndex("RespuestasIdRespuesta");

                    b.ToTable("RegistroPreguntaRespuesta");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroUsuarioEncuesta", b =>
                {
                    b.Property<int>("IdRegistroUsuarioEncuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistroUsuarioEncuesta"), 1L, 1);

                    b.Property<int?>("EncuestasIdEncuesta")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdEncuesta")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("UsuariosIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdRegistroUsuarioEncuesta");

                    b.HasIndex("EncuestasIdEncuesta");

                    b.HasIndex("UsuariosIdUsuario");

                    b.ToTable("RegistroUsuarioEncuesta");
                });

            modelBuilder.Entity("CapaDatos.Data.Respuestas", b =>
                {
                    b.Property<int>("IdRespuesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRespuesta"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRespuesta");

                    b.ToTable("Respuestas");
                });

            modelBuilder.Entity("CapaDatos.Data.RespuestasSelect", b =>
                {
                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdRespuesta")
                        .HasColumnType("int");

                    b.Property<bool>("IsRespuesta")
                        .HasColumnType("bit");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToSqlQuery("EXEC SPR_RespuestasSeleccionar");
                });

            modelBuilder.Entity("CapaDatos.Seguridad.Acciones", b =>
                {
                    b.Property<int>("IdAccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccion"), 1L, 1);

                    b.Property<string>("Accion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.HasKey("IdAccion");

                    b.ToTable("Acciones");
                });

            modelBuilder.Entity("CapaDatos.Seguridad.Perfiles", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerfil"), 1L, 1);

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPerfil");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("CapaDatos.Seguridad.Permisos", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermiso"), 1L, 1);

                    b.Property<int?>("AccionesIdAccion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAccion")
                        .HasColumnType("int");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<int?>("PerfilesIdPerfil")
                        .HasColumnType("int");

                    b.HasKey("IdPermiso");

                    b.HasIndex("AccionesIdAccion");

                    b.HasIndex("PerfilesIdPerfil");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("CapaDatos.Seguridad.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Amaterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Apaterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAgrego")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgrego")
                        .HasColumnType("int");

                    b.Property<int>("IdModifico")
                        .HasColumnType("int");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PerfilesIdPerfil")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("PerfilesIdPerfil");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CapaDatos.Data.CtrlEncuestaPregunta", b =>
                {
                    b.HasOne("CapaDatos.Data.Encuestas", "Encuestas")
                        .WithMany()
                        .HasForeignKey("EncuestasIdEncuesta");

                    b.HasOne("CapaDatos.Data.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("PreguntasIdPregunta");

                    b.Navigation("Encuestas");

                    b.Navigation("Preguntas");
                });

            modelBuilder.Entity("CapaDatos.Data.CtrlPreguntaRespuesta", b =>
                {
                    b.HasOne("CapaDatos.Data.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("PreguntasIdPregunta");

                    b.HasOne("CapaDatos.Data.Respuestas", "Respuestas")
                        .WithMany()
                        .HasForeignKey("RespuestasIdRespuesta");

                    b.Navigation("Preguntas");

                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("CapaDatos.Data.Encuestas", b =>
                {
                    b.HasOne("CapaDatos.Data.Categorias", "Categorias")
                        .WithMany()
                        .HasForeignKey("CategoriasIdCategoria");

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroEncuesta", b =>
                {
                    b.HasOne("CapaDatos.Data.RegistroUsuarioEncuesta", "RegistroUsuarioEncuesta")
                        .WithMany()
                        .HasForeignKey("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

                    b.Navigation("RegistroUsuarioEncuesta");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroEncuestaPregunta", b =>
                {
                    b.HasOne("CapaDatos.Data.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("PreguntasIdPregunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CapaDatos.Data.RegistroUsuarioEncuesta", "RegistroUsuarioEncuesta")
                        .WithMany()
                        .HasForeignKey("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

                    b.Navigation("Preguntas");

                    b.Navigation("RegistroUsuarioEncuesta");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroPreguntaRespuesta", b =>
                {
                    b.HasOne("CapaDatos.Data.Preguntas", "Preguntas")
                        .WithMany()
                        .HasForeignKey("PreguntasIdPregunta");

                    b.HasOne("CapaDatos.Data.RegistroUsuarioEncuesta", "RegistroUsuarioEncuesta")
                        .WithMany()
                        .HasForeignKey("RegistroUsuarioEncuestaIdRegistroUsuarioEncuesta");

                    b.HasOne("CapaDatos.Data.Respuestas", "Respuestas")
                        .WithMany()
                        .HasForeignKey("RespuestasIdRespuesta");

                    b.Navigation("Preguntas");

                    b.Navigation("RegistroUsuarioEncuesta");

                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("CapaDatos.Data.RegistroUsuarioEncuesta", b =>
                {
                    b.HasOne("CapaDatos.Data.Encuestas", "Encuestas")
                        .WithMany()
                        .HasForeignKey("EncuestasIdEncuesta");

                    b.HasOne("CapaDatos.Seguridad.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosIdUsuario");

                    b.Navigation("Encuestas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CapaDatos.Seguridad.Permisos", b =>
                {
                    b.HasOne("CapaDatos.Seguridad.Acciones", "Acciones")
                        .WithMany()
                        .HasForeignKey("AccionesIdAccion");

                    b.HasOne("CapaDatos.Seguridad.Perfiles", "Perfiles")
                        .WithMany()
                        .HasForeignKey("PerfilesIdPerfil");

                    b.Navigation("Acciones");

                    b.Navigation("Perfiles");
                });

            modelBuilder.Entity("CapaDatos.Seguridad.Usuarios", b =>
                {
                    b.HasOne("CapaDatos.Seguridad.Perfiles", "Perfiles")
                        .WithMany()
                        .HasForeignKey("PerfilesIdPerfil");

                    b.Navigation("Perfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
