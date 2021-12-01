using EasySave.Model.Data.ToolBox;

namespace EasySave.Model.Services
{
    public interface ILogService : IService
    {
        public void Handle(object sender, CopyFileEventArgs args);
    }
}
