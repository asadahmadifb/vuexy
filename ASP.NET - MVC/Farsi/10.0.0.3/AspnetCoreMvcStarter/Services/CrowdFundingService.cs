using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;

namespace AspnetCoreMvcStarter.Services
{
  public class CrowdFundingService : ICrowdFundingService
  {
        private readonly IConfiguration _configuration;

        IDbConnection con;
        IDbConnection consqlserver;
    public CrowdFundingService(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new SqliteConnection(_configuration.GetConnectionString("AspnetCoreMvcStarterContext")); // استفاده از اتصال SQLite
            consqlserver=new SqlConnection(_configuration.GetConnectionString("CrowdFundingDBContext"));
    }
        public async Task<List<Project>> GetProjects()
        {

            //string query = "select * from vw_Projects";
            string query = "select * from Projects";
            var list = await con.QueryAsync<Project>(query);
            return list.ToList();

        }

        public async Task<List<ProjectView>> GetListAllOfProjects()
        {

          //string query = "select * from vw_Projects";
          string query = "select * from ProjectViews";
          var list = await con.QueryAsync<ProjectView>(query);
          return list.ToList();

        }

    public async Task<List<dynamic>> GetDataFromCF(string query)
        {
            var list = await con.QueryAsync<dynamic>(query);
            return list.ToList();

        }

    public async Task<List<ProjectInfo>> GetAllProject()
    {
      string query = "select * from ProjectInfos";
      var list = await con.QueryAsync<ProjectInfo>(query);
      return list.ToList();
    }

    public async Task<List<UnderwritingByYear>> GetUnderwritingByYear()
    {
      try
      {
        string query = "SELECT      SUBSTRING(PersianCreationDate, 1, 4) AS Year,    SUBSTRING(PersianCreationDate, 6, 2) AS Month,    COUNT(distinct ProjectID) AS ProjectCount	,    SUM(ProvidedFinancePrice) AS TotalPrice FROM     dbo.ProjectFinancingProvider WHERE     IsAccepted=1 AND SUBSTRING(PersianCreationDate, 1, 4) > '1399' GROUP BY     SUBSTRING(PersianCreationDate, 1, 4),     SUBSTRING(PersianCreationDate, 6, 2) ORDER BY     Year, Month";
        var list = await consqlserver.QueryAsync<UnderwritingByYear>(query);
        //string query = "select * from UnderwritingByYears";
        //var list = await con.QueryAsync<UnderwritingByYear>(query);
        return list.ToList();
      }
      catch (Exception ex)
      {

        return new List<UnderwritingByYear>();
      }
    }

    public async Task<List<ProjectStatusCount>> GetProjectCountBystatus()
    {
      try
      {
        string query = "WITH TotalProjects AS (    SELECT COUNT(*) AS TotalCount    FROM dbo.Project)SELECT     [ProjectStatus] AS ProjectStatusCode,    CASE [ProjectStatus]         WHEN 0 THEN N'نامشخص'         WHEN 1 THEN N'در انتظار تایید نهاد مالی'         WHEN 2 THEN N'در انتظار تایید عامل'         WHEN 3 THEN N'در انتظار صدور نماد'         WHEN 4 THEN N'رد طرح'         WHEN 5 THEN N'آغاز جمع آوری وجوه'         WHEN 6 THEN N'پایان دوره جمع آوری وجوه'         WHEN 7 THEN N'عدم موفقیت جمع آوری وجوه'         WHEN 8 THEN N'تایید موفقیت طرح توسط عامل'         WHEN 9 THEN N'تایید موفقیت طرح توسط نهاد مالی'         WHEN 10 THEN N'تایید نهایی موفقیت طرح'         WHEN 11 THEN N'تایید اتوماتیک طرح'         WHEN 12 THEN N'عدم تایید اتوماتیک طرح'         WHEN 13 THEN N'تایید موفقیت جمع آوری وجوه توسط نهاد مالی'         WHEN 14 THEN N'عدم تایید موفقیت جمع آوری وجوه توسط نهاد مالی'         WHEN 15 THEN N'تایید نهایی موفقیت جمع آوری وجوه'         WHEN 16 THEN N'عدم تایید نهایی موفقیت جمع آوری وجوه'         WHEN 17 THEN N'تعلیق'         WHEN 18 THEN N'لغو'         WHEN 19 THEN N'آماده سازی جمع آوری وجوه'         WHEN 20 THEN N'اعلام پرداخت متقاضی طرح'         WHEN 21 THEN N'اعلام پایان جمع آوری وجوه و درخواست واریز وجوه به متقاضی'        ELSE N'نامشخص'     END AS ProjectStatus,        CASE [ProjectStatus]        WHEN 0 THEN 'Unknown'        WHEN 1 THEN 'PendingForBroker'        WHEN 2 THEN 'PendingForEditByCompany'        WHEN 3 THEN 'Submit'        WHEN 4 THEN 'Rejected'        WHEN 5 THEN 'Started'        WHEN 6 THEN 'FundingFinished'        WHEN 7 THEN 'FundingFailed'        WHEN 8 THEN 'ApprovedByCompany'        WHEN 9 THEN 'ApprovedByBroker'        WHEN 10 THEN 'ApprovedByFarabourse'        WHEN 11 THEN 'ApprovedAutomatic'        WHEN 12 THEN 'FailedAutomatic'        WHEN 13 THEN 'FundingApprovedByBroker'        WHEN 14 THEN 'FundingRejectedByBroker'        WHEN 15 THEN 'FundingApprovedByFarabourse'        WHEN 16 THEN 'FundingRejectedByFarabourse'        WHEN 17 THEN 'Suspended'        WHEN 18 THEN 'Cancled'        WHEN 19 THEN 'PreparingForFunding'        WHEN 20 THEN 'ProjectCompanyPaymentAnnounced'        WHEN 21 THEN 'EndCollectionProject'        ELSE 'Unknown'    END AS ProjectStatusLatin,        COUNT(*) AS ProjectCount,    CAST(COUNT(*) * 100.0 / (SELECT TotalCount FROM TotalProjects) AS DECIMAL(5, 1)) AS Percentage FROM     dbo.Project GROUP BY     [ProjectStatus]ORDER BY     ProjectStatusCode;";
        var ProjectsCountBystatus = await consqlserver.QueryAsync<ProjectStatusCount>(query);
        return ProjectsCountBystatus.ToList();
      }
      catch (Exception ex)
      {

        return new List<ProjectStatusCount>();
      }


    }

    public async Task<List<ProjectFinancingSummary>> GetProjectFinancingSummary()
    {
      try
      {
        string query = "SELECT  LEFT(PersianCreationDate, 4) AS Year,     COUNT(DISTINCT ProjectID) AS TotalProjects,     COUNT(ID) AS TotalInvestments,     COUNT(DISTINCT NationalID) AS UniqueInvestors,     SUM(ProvidedFinancePrice) AS TotalInvestmentAmount FROM     dbo.ProjectFinancingProvider WHERE     IsAccepted =1 AND SUBSTRING(PersianCreationDate, 1, 4) > '1399' GROUP BY     LEFT(PersianCreationDate, 4) ORDER BY     Year desc ; ";
        var ProjectsCountBystatus = await consqlserver.QueryAsync<ProjectFinancingSummary>(query);
        return ProjectsCountBystatus.ToList();
      }
      catch (Exception ex)
      {

        return new List<ProjectFinancingSummary>();
      }
    }
  }
}
