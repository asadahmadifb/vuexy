using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetCoreMvcStarter.Migrations
{
    /// <inheritdoc />
    public partial class GetListAllOfProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectViews",
                columns: table => new
                {
                    شناسه_طرح = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    نام_طرح_یا_پروژه = table.Column<string>(type: "TEXT", nullable: false),
                    مبلغ_مورد_نیاز = table.Column<decimal>(type: "TEXT", nullable: false),
                    نوع_تامین_مالی_جمعی = table.Column<string>(type: "TEXT", nullable: false),
                    وضعیت_طرح = table.Column<string>(type: "TEXT", nullable: false),
                    تاریخ_تایید_شده_شروع_جمع_آوری_وجوه = table.Column<DateTime>(type: "TEXT", nullable: false),
                    دوره_جمع_آوری_وجوه = table.Column<int>(type: "INTEGER", nullable: false),
                    نام_عامل = table.Column<string>(type: "TEXT", nullable: false),
                    لینک_عامل = table.Column<string>(type: "TEXT", nullable: false),
                    نام_سکو = table.Column<string>(type: "TEXT", nullable: false),
                    موضوع_طرح = table.Column<string>(type: "TEXT", nullable: false),
                    نام_شرکت = table.Column<string>(type: "TEXT", nullable: false),
                    نماد_طرح = table.Column<string>(type: "TEXT", nullable: false),
                    گروه_صنعت = table.Column<string>(type: "TEXT", nullable: false),
                    زیرگروه_صنعت = table.Column<string>(type: "TEXT", nullable: false),
                    حداقل_مبلغ_مورد_نیاز_جهت_موفقیت_تامین_مالی = table.Column<decimal>(type: "TEXT", nullable: false),
                    حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = table.Column<decimal>(type: "TEXT", nullable: false),
                    حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقیقی = table.Column<decimal>(type: "TEXT", nullable: false),
                    حداقل_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = table.Column<decimal>(type: "TEXT", nullable: false),
                    حداکثر_مبلغ_سرمایه_گذاری_برای_تامین_کننده_حقوقی = table.Column<decimal>(type: "TEXT", nullable: false),
                    تاریخ_پیشنهادی_شروع_جمع_آوری_وجوه = table.Column<DateTime>(type: "TEXT", nullable: false),
                    تاریخ_پیشنهادی_پایان_جمع_آوری_وجوه = table.Column<DateTime>(type: "TEXT", nullable: false),
                    تاریخ_شروع_پروژه = table.Column<DateTime>(type: "TEXT", nullable: false),
                    تاریخ_اتمام_پروژه = table.Column<DateTime>(type: "TEXT", nullable: false),
                    تعداد_گواهی_شراکت_متقاضی = table.Column<int>(type: "INTEGER", nullable: false),
                    کارمزد_فرابورس = table.Column<decimal>(type: "TEXT", nullable: false),
                    کارمزد_عامل = table.Column<decimal>(type: "TEXT", nullable: false),
                    نوع_وثیقه = table.Column<string>(type: "TEXT", nullable: false),
                    شناسه_ملی = table.Column<string>(type: "TEXT", nullable: false),
                    شماره_ثبت_شرکت = table.Column<string>(type: "TEXT", nullable: false),
                    تاریخ_ثبت_شرکت = table.Column<DateTime>(type: "TEXT", nullable: false),
                    کد_اقتصادی_شرکت = table.Column<string>(type: "TEXT", nullable: false),
                    نوع_شخصیت_حقوقی_شرکت = table.Column<string>(type: "TEXT", nullable: false),
                    کد_پستی_شرکت = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectViews", x => x.شناسه_طرح);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectViews");
        }
    }
}
