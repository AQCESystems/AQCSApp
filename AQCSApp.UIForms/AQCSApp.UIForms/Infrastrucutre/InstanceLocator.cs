using AQCSApp.UIForms.ViewModels;

namespace AQCSApp.UIForms.Infrastrucutre
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
