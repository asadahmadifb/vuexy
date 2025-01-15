using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Dynamic;

namespace AspnetCoreMvcStarter.Services
{
  public class CrowdFundingService : ICrowdFundingService
  {
        private readonly IConfiguration _configuration;

        IDbConnection con;
        public CrowdFundingService(IConfiguration configuration)
        {
            _configuration = configuration;
            //con = new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
            con = new SqliteConnection(_configuration.GetConnectionString("AspnetCoreMvcStarterContext")); // استفاده از اتصال SQLite

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
    }
}
