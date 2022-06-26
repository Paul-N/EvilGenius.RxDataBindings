using System;
using System.Windows.Input;
using EvilGenius.RxDataBindings.Core;
using EvilGenius.RxDataBindings.Properties;

namespace RxMvvmDemo.Core.ViewModels
{
    public class FirstViewModel
    {
        public ICommand ViewTapCommand { get; private set; }

        private IPropertySetter<string> _tapInfoSetter;

        public IReadonlyProperty<string> TapInfo { get; private set; }

        private int selectedVisibility = 0;

        public int SelectedVisibility
        {
            get => selectedVisibility;
            set
            {
                selectedVisibility = value;
                _viewVisibilitySetter?.SetValue((Visibility)value);
            }
        }

        private IPropertySetter<Visibility> _viewVisibilitySetter;
        public IReadonlyProperty<Visibility> ViewVisibility { get; private set; }

        public IProperty<bool> IsViewVisible { get; private set; }

        public IProperty<DateTime> MinDate { get; private set; }

        public IProperty<DateTime> MaxDate { get; private set; }

        public IProperty<DateTime> SelectedDate { get; private set; }

        public IProperty<string> TxtProp { get; private set; }

        public IProperty<double> StepperProp { get; private set; }
        public IProperty<float> SliderProp { get; private set; }

        public FirstViewModel()
        {
            TapInfo = new ReadonlyProperty<string>(ref _tapInfoSetter);
            ViewTapCommand = new AsyncAwaitBestPractices.MVVM.AsyncCommand<string>(async (tapInfo) => _tapInfoSetter.SetValue(tapInfo));

            ViewVisibility = new ReadonlyProperty<Visibility>(ref _viewVisibilitySetter);

            IsViewVisible = new Property<bool>(false);

            MinDate = new Property<DateTime>(DateTime.Now - TimeSpan.FromDays(7));

            MaxDate = new Property<DateTime>(DateTime.Now + TimeSpan.FromDays(7));

            SelectedDate = new Property<DateTime>(DateTime.Now);

            TxtProp = new Property<string>(LoremIpsum.Text);

            StepperProp = new Property<double>();
            SliderProp = new Property<float>();
    }
    }
}
