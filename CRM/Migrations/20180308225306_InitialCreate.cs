using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CRM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Password = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cedula = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    IDUsuario = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Pagina_Web = table.Column<string>(nullable: true),
                    Sector = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    usuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Apellidos = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    IDCliente = table.Column<int>(nullable: false),
                    IDUsuario = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Puesto = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    clienteID = table.Column<int>(nullable: true),
                    usuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacto_Cliente_clienteID",
                        column: x => x.clienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacto_Usuario_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reunion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiaHora = table.Column<DateTime>(nullable: false),
                    IDCliente = table.Column<int>(nullable: false),
                    IDUsuario = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Virtual = table.Column<bool>(nullable: false),
                    clienteID = table.Column<int>(nullable: true),
                    usuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reunion_Cliente_clienteID",
                        column: x => x.clienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reunion_Usuario_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Detalle = table.Column<string>(nullable: true),
                    Estado_Actual = table.Column<string>(nullable: true),
                    IDCliente = table.Column<int>(nullable: false),
                    IDUsuario = table.Column<int>(nullable: false),
                    Quien_reporto = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    clienteID = table.Column<int>(nullable: true),
                    usuarioID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ticket_Cliente_clienteID",
                        column: x => x.clienteID,
                        principalTable: "Cliente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Usuario_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_usuarioID",
                table: "Cliente",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_clienteID",
                table: "Contacto",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_usuarioID",
                table: "Contacto",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Reunion_clienteID",
                table: "Reunion",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Reunion_usuarioID",
                table: "Reunion",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_clienteID",
                table: "Ticket",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_usuarioID",
                table: "Ticket",
                column: "usuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Reunion");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
