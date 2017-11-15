using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Autofac;
using ReactiveUI;

namespace UwpClientApp.Presentation.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<Visibility> _spinnerVisibility;
        private bool _isBusy;
        private ContentDialog _contentDialog;

        protected ViewModelBase()
        {
            _spinnerVisibility = this.ObservableForProperty(x => x.IsBusy)
                .Select(args => args.Value ? Visibility.Visible : Visibility.Collapsed)
                .ToProperty(this, x => x.SpinnerVisibility, Visibility.Collapsed);
        
            _contentDialog = new ContentDialog();
        }

        public Visibility SpinnerVisibility => _spinnerVisibility.Value;

        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        protected async Task ShowErrorAsync(string message)
        {
            _contentDialog.Title = "Error";
            var textBlock = new TextBlock { Text = message };
            _contentDialog.Content = textBlock;

            _contentDialog.CloseButtonText = "OK";
            await _contentDialog.ShowAsync();
        }
    }
}
