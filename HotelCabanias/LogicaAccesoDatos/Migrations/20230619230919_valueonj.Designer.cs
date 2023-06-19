﻿// <auto-generated />
using System;
using LogicaAccesoDatos.BaseDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(HotelCabaniaContext))]
    [Migration("20230619230919_valueonj")]
    partial class valueonj
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Cabania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HabilitadaReservas")
                        .HasColumnType("bit");

                    b.Property<int>("MaxPersonas")
                        .HasColumnType("int");

                    b.Property<int>("NumeroHabitacion")
                        .HasColumnType("int");

                    b.Property<bool>("TieneJacuzzi")
                        .HasColumnType("bit");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("Cabanias");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Mantenimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabaniaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreRealizo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabaniaId");

                    b.ToTable("Mantenimientos");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.TipoCabania", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoCabanias");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("System.Collections.Generic.List<string>", b =>
                {
                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.ToTable("List<string>");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Cabania", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesNegocio.TipoCabania", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LogicaNegocio.ValueObjects.Nombre", "Nombre", b1 =>
                        {
                            b1.Property<int>("CabaniaId")
                                .HasColumnType("int");

                            b1.Property<string>("TextoNombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("CabaniaId");

                            b1.HasIndex("TextoNombre")
                                .IsUnique();

                            b1.ToTable("Cabanias");

                            b1.WithOwner()
                                .HasForeignKey("CabaniaId");
                        });

                    b.Navigation("Nombre")
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Mantenimiento", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesNegocio.Cabania", "Cabania")
                        .WithMany()
                        .HasForeignKey("CabaniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LogicaNegocio.ValueObjects.Costo", "Costo", b1 =>
                        {
                            b1.Property<int>("MantenimientoId")
                                .HasColumnType("int");

                            b1.Property<int>("ValorCosto")
                                .HasColumnType("int");

                            b1.HasKey("MantenimientoId");

                            b1.HasIndex("ValorCosto");

                            b1.ToTable("Mantenimientos");

                            b1.WithOwner()
                                .HasForeignKey("MantenimientoId");
                        });

                    b.Navigation("Cabania");

                    b.Navigation("Costo")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.TipoCabania", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.Costo", "CostoxHuesped", b1 =>
                        {
                            b1.Property<int>("TipoCabaniaId")
                                .HasColumnType("int");

                            b1.Property<int>("ValorCosto")
                                .HasColumnType("int");

                            b1.HasKey("TipoCabaniaId");

                            b1.HasIndex("ValorCosto");

                            b1.ToTable("TipoCabanias");

                            b1.WithOwner()
                                .HasForeignKey("TipoCabaniaId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.NombreTipoCabania", "Nombre", b1 =>
                        {
                            b1.Property<int>("TipoCabaniaId")
                                .HasColumnType("int");

                            b1.Property<string>("TextoNombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("TipoCabaniaId");

                            b1.HasIndex("TextoNombre")
                                .IsUnique();

                            b1.ToTable("TipoCabanias");

                            b1.WithOwner()
                                .HasForeignKey("TipoCabaniaId");
                        });

                    b.Navigation("CostoxHuesped")
                        .IsRequired();

                    b.Navigation("Nombre")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesNegocio.Usuario", b =>
                {
                    b.OwnsOne("LogicaNegocio.ValueObjects.Nombre", "Nombre", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("TextoNombre")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("UsuarioId");

                            b1.HasIndex("TextoNombre")
                                .IsUnique();

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.Contrasenia", "Contrasenia", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("TextoContrasenia")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("UsuarioId");

                            b1.HasIndex("TextoContrasenia");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.Mail", "Mail", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("TextoMail")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.HasKey("UsuarioId");

                            b1.HasIndex("TextoMail")
                                .IsUnique();

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Contrasenia")
                        .IsRequired();

                    b.Navigation("Mail")
                        .IsRequired();

                    b.Navigation("Nombre")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
