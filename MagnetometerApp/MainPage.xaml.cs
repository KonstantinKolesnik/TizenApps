﻿using MagnetometerApp.ViewModels;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagnetometerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : CirclePage
    {
        #region fields
        private MainViewModel _mainViewModel;
        private Animation _radarAnimation;
        #endregion

        public MainPage()
        {
            InitializeComponent();
            InitRadarAnimation();
        }

        private void InitRadarAnimation()
        {
            _radarAnimation = new Animation(v => radar.Rotation = v, 0, 360);
        }
        private void StartRadarAnimation()
        {
            _radarAnimation.Commit(this, "RadarAnimation", 16, 2000, Easing.Linear, (v, c) => radar.Rotation = 0, () => true);
        }

        protected override void OnAppearing()
        {
            _mainViewModel = (MainViewModel)BindingContext;
            _mainViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(_mainViewModel.Ready))
                    StartRadarAnimation();
            };

            _mainViewModel.StartCommand.Execute(null);
        }
        protected override void OnDisappearing()
        {
            _mainViewModel.StopCommand.Execute(null);
        }
    }
}