using Xamarin.Forms.Platform.Tizen;

namespace MetalDetector
{
    /// <summary>
    /// Metal Detector forms application class for Tizen Wearable profile.
    /// </summary>
    class Program : FormsApplication
    {
        #region methods

        /// <summary>
        /// Handles creation phase of the forms application.
        /// Sets up windows settings and loads Xamarin application.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new MetalDetectorApp());
        }

        /// <summary>
        /// Entry method of the program/application.
        /// </summary>
        /// <param name="args">Launch arguments.</param>
        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app);
            app.Run(args);
        }

        #endregion
    }
}
