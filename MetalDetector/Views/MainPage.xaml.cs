using MetalDetector.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetalDetector.Views
{
    /// <summary>
    /// Main (and only one) page of the application.
    /// Handles UI logic for the application.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        #region fields

        /// <summary>
        /// Reference to the object of the MainViewModel class.
        /// It allows to listen to the main view model events and execute its commands.
        /// </summary>
        private MainViewModel _mainViewModel;

        /// <summary>
        /// Reference to the object of the Animation class.
        /// It allows to create and start animation of the radar element.
        /// </summary>
        private Animation _radarAnimation;

        #endregion

        #region methods

        /// <summary>
        /// The page constructor.
        /// Creates page structure defined in the XAML file.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            InitRadarAnimation();
        }

        /// <summary>
        /// Initializes radar animation.
        /// </summary>
        private void InitRadarAnimation()
        {
            _radarAnimation = new Animation(v => radar.Rotation = v, 0, 360);
        }

        /// <summary>
        /// Starts radar animation.
        /// </summary>
        private void StartRadarAnimation()
        {
            _radarAnimation.Commit(this, "RadarAnimation", 16, 2000, Easing.Linear, (v, c) => radar.Rotation = 0, () => true);
        }

        /// <summary>
        /// Handles "PropertyChanged" event of the view model.
        /// Starts radar animation.
        /// </summary>
        /// <param name="sender">Object firing the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_mainViewModel.Ready))
            {
                StartRadarAnimation();
            }
        }

        /// <summary>
        /// Performs action when the main page appears.
        /// Starts metal detector.
        /// </summary>
        protected override void OnAppearing()
        {
            _mainViewModel = (MainViewModel)BindingContext;
            _mainViewModel.PropertyChanged += OnPropertyChanged;
            _mainViewModel.StartCommand.Execute(null);
        }
        /// <summary>
        /// Performs action when the main page disappears.
        /// Stops metal detector.
        /// </summary>
        protected override void OnDisappearing()
        {
            _mainViewModel.StopCommand.Execute(null);
        }
        #endregion
    }
}
