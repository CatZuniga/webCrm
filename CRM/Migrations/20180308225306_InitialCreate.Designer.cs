﻿// <auto-generated />
using CRM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CRM.Migrations
{
    [DbContext(typeof(CRMContext))]
    [Migration("20180308225306_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("CRM.Models.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula");

                    b.Property<string>("Direccion");

                    b.Property<int>("IDUsuario");

                    b.Property<string>("Nombre");

                    b.Property<string>("Pagina_Web");

                    b.Property<string>("Sector");

                    b.Property<string>("Telefono");

                    b.Property<int?>("usuarioID");

                    b.HasKey("ID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("CRM.Models.Contacto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos");

                    b.Property<string>("Correo");

                    b.Property<int>("IDCliente");

                    b.Property<int>("IDUsuario");

                    b.Property<string>("Nombre");

                    b.Property<string>("Puesto");

                    b.Property<string>("Telefono");

                    b.Property<int?>("clienteID");

                    b.Property<int?>("usuarioID");

                    b.HasKey("ID");

                    b.HasIndex("clienteID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("CRM.Models.Reunion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DiaHora");

                    b.Property<int>("IDCliente");

                    b.Property<int>("IDUsuario");

                    b.Property<string>("Titulo");

                    b.Property<bool>("Virtual");

                    b.Property<int?>("clienteID");

                    b.Property<int?>("usuarioID");

                    b.HasKey("ID");

                    b.HasIndex("clienteID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Reunion");
                });

            modelBuilder.Entity("CRM.Models.Ticket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalle");

                    b.Property<string>("Estado_Actual");

                    b.Property<int>("IDCliente");

                    b.Property<int>("IDUsuario");

                    b.Property<string>("Quien_reporto");

                    b.Property<string>("Titulo");

                    b.Property<int?>("clienteID");

                    b.Property<int?>("usuarioID");

                    b.HasKey("ID");

                    b.HasIndex("clienteID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("CRM.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Tipo");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CRM.Models.Cliente", b =>
                {
                    b.HasOne("CRM.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioID");
                });

            modelBuilder.Entity("CRM.Models.Contacto", b =>
                {
                    b.HasOne("CRM.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteID");

                    b.HasOne("CRM.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioID");
                });

            modelBuilder.Entity("CRM.Models.Reunion", b =>
                {
                    b.HasOne("CRM.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteID");

                    b.HasOne("CRM.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioID");
                });

            modelBuilder.Entity("CRM.Models.Ticket", b =>
                {
                    b.HasOne("CRM.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteID");

                    b.HasOne("CRM.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioID");
                });
#pragma warning restore 612, 618
        }
    }
}
