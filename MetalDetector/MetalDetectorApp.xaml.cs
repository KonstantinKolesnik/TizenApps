using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetalDetector
{
    /// <summary>
    /// Xamarin application class for Metal Detector application.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MetalDetectorApp : Application
    {
        #region methods

        /// <summary>
        /// The application constructor.
        /// </summary>
        public MetalDetectorApp()
        {
            InitializeComponent();
        }

        #endregion
    }
}