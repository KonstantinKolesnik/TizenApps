using MetalDetector.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MetalDetector.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private MetalDetectorModel _metalDetectorModel;
        private bool _ready = false;
        private bool _isInRange = false;
        private int _relativeSignalStrength = 0;
        private int _signalStrength = 0;
        private double _rotation = 0;
        #endregion

        #region Properties
        public ICommand StartCommand { get; private set; }
        public ICommand StopCommand { get; private set; }

        public bool Ready
        {
            get => _ready;
            private set => SetProperty(ref _ready, value);
        }
        public bool IsInRange
        {
            get => _isInRange;
            set => SetProperty(ref _isInRange, value);
        }
        public int RelativeSignalStrength
        {
            get => _relativeSignalStrength;
            set => SetProperty(ref _relativeSignalStrength, value);
        }
        public int SignalStrength
        {
            get => _signalStrength;
            set => SetProperty(ref _signalStrength, value);
        }
        public double Rotation
        {
            get => _rotation;
            set => SetProperty(ref _rotation, value);
        }
        #endregion

        #region Methods

        public MainViewModel()
        {
            _metalDetectorModel = new MetalDetectorModel();
            InitCommands();

            _metalDetectorModel.Updated += (s, e) =>
            {
                IsInRange = _metalDetectorModel.IsInRange;
                RelativeSignalStrength = _metalDetectorModel.RelativeSignalStrength;
                SignalStrength = _metalDetectorModel.SignalStrength;
                Rotation = _metalDetectorModel.Rotation;
            };
        }

        /// <summary>
        /// Initializes view model's commands.
        /// </summary>
        private void InitCommands()
        {
            StartCommand = new Command(ExecuteStart);
            StopCommand = new Command(ExecuteStop);
        }
        private void ExecuteStart()
        {
            if (_metalDetectorModel.IsSupported())
            {
                _metalDetectorModel.Start();
                Ready = true;
            }
        }
        private void ExecuteStop()
        {
            _metalDetectorModel.Stop();
        }
        #endregion
    }
}
