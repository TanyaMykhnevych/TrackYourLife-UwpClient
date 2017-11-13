using System.Reactive.Linq;
using Windows.UI.Xaml;
using ReactiveUI;

namespace UwpClientApp.Presentation.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<Visibility> _spinnerVisibility;
        private bool _isBusy;

        protected ViewModelBase()
        {
            _spinnerVisibility = this.ObservableForProperty(x => x.IsBusy)
                .Select(args => args.Value ? Visibility.Visible : Visibility.Collapsed)
                .ToProperty(this, x => x.SpinnerVisibility, Visibility.Collapsed);
        }

        public Visibility SpinnerVisibility => _spinnerVisibility.Value;

        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }
    }
}
