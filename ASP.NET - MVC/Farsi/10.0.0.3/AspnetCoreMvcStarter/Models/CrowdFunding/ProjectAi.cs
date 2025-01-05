namespace AspnetCoreMvcStarter.Models.CrowdFunding
{
    public class ProjectAi
    {
        public ProjectAi() {
            messages = new List<Message>();
            projects = new List<Project>();
        }
        public List<Message> messages = new List<Message>();
        public List<Project> projects  = new List<Project>();
    }
}
