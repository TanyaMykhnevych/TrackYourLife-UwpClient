using ReactiveUI;

namespace UwpClientApp.Presentation.ViewModels
{
    public class MenuContentViewModel : ReactiveObject
    {
        private bool _isPaneOpened;

        public MenuContentViewModel()
        {
            OpenClosePaneCommand = ReactiveCommand.Create(OpenClosePaneCommandExecuted);
        }

        public bool IsPaneOpened
        {
            get => _isPaneOpened;
            set => this.RaiseAndSetIfChanged(ref _isPaneOpened, value);
        }

        public ReactiveCommand OpenClosePaneCommand { get; }

        private void OpenClosePaneCommandExecuted()
        {
            IsPaneOpened = !IsPaneOpened;
        }
    }
}
