using Tizen.Applications;
using Tizen.Wearable.CircularUI.Forms.Renderer.Watchface;

namespace TizenWatchfaceApp1
{
    class Program : FormsWatchface
    {
        private ClockViewModel viewModel = new ClockViewModel();

        protected override void OnCreate()
        {
            base.OnCreate();

            LoadWatchface(new App() { BindingContext = viewModel });
        }
        protected override void OnAmbientChanged(AmbientEventArgs mode)
        {
            base.OnAmbientChanged(mode);
        }
        protected override void OnTick(TimeEventArgs time)
        {
            base.OnTick(time);

            if (viewModel != null)
                viewModel.Time = time.Time.UtcTimestamp;
        }
        protected override void OnAmbientTick(TimeEventArgs time)
        {
            base.OnAmbientTick(time);

            if (viewModel != null)
                viewModel.Time = time.Time.UtcTimestamp;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Xamarin.Forms.Platform.Tizen.Forms.Init(app);
            Tizen.Wearable.CircularUI.Forms.Renderer.FormsCircularUI.Init();
            app.Run(args);
        }
    }
}
