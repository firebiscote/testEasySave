using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
{
    public interface ILogService : IService
    {
        public void Handle(object sender, CopyFileEventArgs args);
    }
}
