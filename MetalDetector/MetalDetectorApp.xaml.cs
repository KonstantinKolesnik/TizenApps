using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetalDetector
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MetalDetectorApp : Application
    {
        public MetalDetectorApp()
        {
            InitializeComponent();
        }
    }
}