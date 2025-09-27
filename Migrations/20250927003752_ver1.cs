using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instituto.Migrations
{
    /// <inheritdoc />
    public partial class ver1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    EstId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstDenominacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.EstId);
                });

            migrationBuilder.CreateTable(
                name: "mtemas",
                columns: table => new
                {
                    MatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mtemas", x => x.MatId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolDenominacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    mtemasMatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_carreras_mtemas_mtemasMatId",
                        column: x => x.mtemasMatId,
                        principalTable: "mtemas",
                        principalColumn: "MatId");
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    UsuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuDni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AlumnoMatricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alumno_CarId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    MatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.UsuId);
                    table.ForeignKey(
                        name: "FK_usuarios_carreras_Alumno_CarId",
                        column: x => x.Alumno_CarId,
                        principalTable: "carreras",
                        principalColumn: "CarId");
                    table.ForeignKey(
                        name: "FK_usuarios_estados_EstId",
                        column: x => x.EstId,
                        principalTable: "estados",
                        principalColumn: "EstId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_RolId",
                        column: x => x.RolId,
                        principalTable: "roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carrerasDocente",
                columns: table => new
                {
                    CarDocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrerasDocente", x => x.CarDocId);
                    table.ForeignKey(
                        name: "FK_carrerasDocente_carreras_CarId",
                        column: x => x.CarId,
                        principalTable: "carreras",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carrerasDocente_usuarios_UsuId",
                        column: x => x.UsuId,
                        principalTable: "usuarios",
                        principalColumn: "UsuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materiasAlumno",
                columns: table => new
                {
                    MatAluId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuId = table.Column<int>(type: "int", nullable: false),
                    MatId = table.Column<int>(type: "int", nullable: false),
                    AlumnoUsuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiasAlumno", x => x.MatAluId);
                    table.ForeignKey(
                        name: "FK_materiasAlumno_mtemas_MatId",
                        column: x => x.MatId,
                        principalTable: "mtemas",
                        principalColumn: "MatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_materiasAlumno_usuarios_AlumnoUsuId",
                        column: x => x.AlumnoUsuId,
                        principalTable: "usuarios",
                        principalColumn: "UsuId");
                    table.ForeignKey(
                        name: "FK_materiasAlumno_usuarios_UsuId",
                        column: x => x.UsuId,
                        principalTable: "usuarios",
                        principalColumn: "UsuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carreras_mtemasMatId",
                table: "carreras",
                column: "mtemasMatId");

            migrationBuilder.CreateIndex(
                name: "IX_carrerasDocente_CarId",
                table: "carrerasDocente",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_carrerasDocente_UsuId_CarId",
                table: "carrerasDocente",
                columns: new[] { "UsuId", "CarId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_materiasAlumno_AlumnoUsuId",
                table: "materiasAlumno",
                column: "AlumnoUsuId");

            migrationBuilder.CreateIndex(
                name: "IX_materiasAlumno_MatId",
                table: "materiasAlumno",
                column: "MatId");

            migrationBuilder.CreateIndex(
                name: "IX_materiasAlumno_UsuId_MatId",
                table: "materiasAlumno",
                columns: new[] { "UsuId", "MatId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Alumno_CarId",
                table: "usuarios",
                column: "Alumno_CarId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_EstId",
                table: "usuarios",
                column: "EstId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_RolId",
                table: "usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carrerasDocente");

            migrationBuilder.DropTable(
                name: "materiasAlumno");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "mtemas");
        }
    }
}
