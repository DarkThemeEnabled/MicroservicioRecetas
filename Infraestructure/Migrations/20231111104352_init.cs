using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasReceta",
                columns: table => new
                {
                    CategoriaRecetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasReceta", x => x.CategoriaRecetaId);
                });

            migrationBuilder.CreateTable(
                name: "Dificultad",
                columns: table => new
                {
                    DificultadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificultad", x => x.DificultadId);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    RecetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaRecetaId = table.Column<int>(type: "int", nullable: false),
                    DificultadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FotoReceta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Video = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Topics = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TiempoPreparacion = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.RecetaId);
                    table.ForeignKey(
                        name: "FK_Recetas_CategoriasReceta_CategoriaRecetaId",
                        column: x => x.CategoriaRecetaId,
                        principalTable: "CategoriasReceta",
                        principalColumn: "CategoriaRecetaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recetas_Dificultad_DificultadId",
                        column: x => x.DificultadId,
                        principalTable: "Dificultad",
                        principalColumn: "DificultadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientesReceta",
                columns: table => new
                {
                    IngredienteRecetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredienteId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientesReceta", x => x.IngredienteRecetaId);
                    table.ForeignKey(
                        name: "FK_IngredientesReceta_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "RecetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pasos",
                columns: table => new
                {
                    PasoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasos", x => x.PasoId);
                    table.ForeignKey(
                        name: "FK_Pasos_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "RecetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromedioPuntajes",
                columns: table => new
                {
                    PromedioPuntajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromedioPuntajes", x => x.PromedioPuntajeId);
                    table.ForeignKey(
                        name: "FK_PromedioPuntajes_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "RecetaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CategoriasReceta",
                columns: new[] { "CategoriaRecetaId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Pastas" },
                    { 2, "Minutas" },
                    { 3, "Ensaladas" },
                    { 4, "Pescado" },
                    { 5, "Carne" },
                    { 6, "Vegetariana" },
                    { 7, "Sopas" },
                    { 8, "Postres" },
                    { 9, "Desayunos" },
                    { 10, "Bebidas" },
                    { 11, "Aperitivos" }
                });

            migrationBuilder.InsertData(
                table: "Dificultad",
                columns: new[] { "DificultadId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Principiante" },
                    { 2, "Fácil" },
                    { 3, "Media" },
                    { 4, "Díficil" },
                    { 5, "Avanzado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesReceta_RecetaId",
                table: "IngredientesReceta",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasos_RecetaId",
                table: "Pasos",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PromedioPuntajes_RecetaId",
                table: "PromedioPuntajes",
                column: "RecetaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_CategoriaRecetaId",
                table: "Recetas",
                column: "CategoriaRecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_DificultadId",
                table: "Recetas",
                column: "DificultadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientesReceta");

            migrationBuilder.DropTable(
                name: "Pasos");

            migrationBuilder.DropTable(
                name: "PromedioPuntajes");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "CategoriasReceta");

            migrationBuilder.DropTable(
                name: "Dificultad");
        }
    }
}
