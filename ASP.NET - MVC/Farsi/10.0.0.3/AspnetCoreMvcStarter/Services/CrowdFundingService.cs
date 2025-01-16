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
      //string query = "  SELECT     YEAR(p.UnderwritingStartDate) AS Year,    MONTH(p.UnderwritingStartDate) AS Month,    COUNT(p.ID) AS ProjectCount,    SUM(p.TotalPrice) AS TotalPrice FROM    dbo.Project AS p WHERE     p.UnderwritingStartDate IS NOT NULL and  YEAR(p.UnderwritingStartDate)>2020  GROUP BY    YEAR(p.UnderwritingStartDate),    MONTH(p.UnderwritingStartDate)  ORDER BY    YEAR(p.UnderwritingStartDate),    MONTH(p.UnderwritingStartDate);";
      //var list = await consqlserver.QueryAsync<UnderwritingByYear>(query);
      string query = "select * from UnderwritingByYears";
      var list = await con.QueryAsync<UnderwritingByYear>(query);
      return list.ToList();
    }
  }
}
