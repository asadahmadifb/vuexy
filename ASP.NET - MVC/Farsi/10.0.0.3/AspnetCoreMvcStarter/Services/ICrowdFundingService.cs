using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;
using System.Data;
using System.Dynamic;

namespace AspnetCoreMvcStarter.Services
{
    public interface ICrowdFundingService
    {
      public Task<List<Project>> GetProjects();
      public Task<List<ProjectInfo>> GetAllProject();
      public Task<List<UnderwritingByYear>> GetUnderwritingByYear();
      public Task<List<ProjectView>> GetListAllOfProjects();
      public Task<List<dynamic>> GetDataFromCF(string query);
      public Task<List<ProjectStatusCount>> GetProjectCountBystatus();
      public Task<List<ProjectFinancingSummary>> GetProjectFinancingSummary();
    
  }
}
