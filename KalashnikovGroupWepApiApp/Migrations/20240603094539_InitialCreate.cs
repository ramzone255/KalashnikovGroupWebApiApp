using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KalashnikovGroupWepApiApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    id_components = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.id_components);
                });

            migrationBuilder.CreateTable(
                name: "OperationsTypes",
                columns: table => new
                {
                    operations_types = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsTypes", x => x.operations_types);
                });

            migrationBuilder.CreateTable(
                name: "Payday",
                columns: table => new
                {
                    id_payday = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paycheck = table.Column<float>(type: "real", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payday", x => x.id_payday);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    id_payments_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.id_payments_type);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    denomination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id_post);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    id_operations = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<float>(type: "real", nullable: false),
                    Componentsid_components = table.Column<int>(type: "int", nullable: false),
                    OperationsTypesoperations_types = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.id_operations);
                    table.ForeignKey(
                        name: "FK_Operations_Components_Componentsid_components",
                        column: x => x.Componentsid_components,
                        principalTable: "Components",
                        principalColumn: "id_components",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_OperationsTypes_OperationsTypesoperations_types",
                        column: x => x.OperationsTypesoperations_types,
                        principalTable: "OperationsTypes",
                        principalColumn: "operations_types",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id_payments = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<float>(type: "real", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentTypeid_payments_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id_payments);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentType_PaymentTypeid_payments_type",
                        column: x => x.PaymentTypeid_payments_type,
                        principalTable: "PaymentType",
                        principalColumn: "id_payments_type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id_employess = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middlename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wage_rate = table.Column<float>(type: "real", nullable: false),
                    Postid_post = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id_employess);
                    table.ForeignKey(
                        name: "FK_Employees_Post_Postid_post",
                        column: x => x.Postid_post,
                        principalTable: "Post",
                        principalColumn: "id_post",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payday_linking_Payments",
                columns: table => new
                {
                    id_payments = table.Column<int>(type: "int", nullable: false),
                    id_payday = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payday_linking_Payments", x => new { x.id_payments, x.id_payday });
                    table.ForeignKey(
                        name: "FK_Payday_linking_Payments_Payday_id_payday",
                        column: x => x.id_payday,
                        principalTable: "Payday",
                        principalColumn: "id_payday",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payday_linking_Payments_Payments_id_payments",
                        column: x => x.id_payments,
                        principalTable: "Payments",
                        principalColumn: "id_payments",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    id_deal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quality = table.Column<int>(type: "int", nullable: false),
                    total_amount = table.Column<float>(type: "real", nullable: false),
                    Employeesid_employess = table.Column<int>(type: "int", nullable: false),
                    Operationsid_operations = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.id_deal);
                    table.ForeignKey(
                        name: "FK_Deal_Employees_Employeesid_employess",
                        column: x => x.Employeesid_employess,
                        principalTable: "Employees",
                        principalColumn: "id_employess",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deal_Operations_Operationsid_operations",
                        column: x => x.Operationsid_operations,
                        principalTable: "Operations",
                        principalColumn: "id_operations",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deal_Linking_Payday",
                columns: table => new
                {
                    id_payday = table.Column<int>(type: "int", nullable: false),
                    id_deal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal_Linking_Payday", x => new { x.id_deal, x.id_payday });
                    table.ForeignKey(
                        name: "FK_Deal_Linking_Payday_Deal_id_deal",
                        column: x => x.id_deal,
                        principalTable: "Deal",
                        principalColumn: "id_deal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deal_Linking_Payday_Payday_id_payday",
                        column: x => x.id_payday,
                        principalTable: "Payday",
                        principalColumn: "id_payday",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deal_Employeesid_employess",
                table: "Deal",
                column: "Employeesid_employess");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_Operationsid_operations",
                table: "Deal",
                column: "Operationsid_operations");

            migrationBuilder.CreateIndex(
                name: "IX_Deal_Linking_Payday_id_payday",
                table: "Deal_Linking_Payday",
                column: "id_payday");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Postid_post",
                table: "Employees",
                column: "Postid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Componentsid_components",
                table: "Operations",
                column: "Componentsid_components");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationsTypesoperations_types",
                table: "Operations",
                column: "OperationsTypesoperations_types");

            migrationBuilder.CreateIndex(
                name: "IX_Payday_linking_Payments_id_payday",
                table: "Payday_linking_Payments",
                column: "id_payday");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentTypeid_payments_type",
                table: "Payments",
                column: "PaymentTypeid_payments_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deal_Linking_Payday");

            migrationBuilder.DropTable(
                name: "Payday_linking_Payments");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "Payday");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "OperationsTypes");
        }
    }
}
