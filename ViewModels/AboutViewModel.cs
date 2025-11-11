 csharp
    using Notes.Models;
using System.Windows.Input;

namespace Notes.ViewModels
{
    internal class AboutViewModel : BaseViewModel
    {
        public About AboutModel { get; }
        public ICommand ShowMoreInfoCommand { get; }

        public AboutViewModel()
        {
            AboutModel = new About();
            ShowMoreInfoCommand = new Command(async () => await ShowMoreInfo());
        }

        private async Task ShowMoreInfo()
        {
            if (AboutModel.MoreInfoUrl != null)
                await Launcher.OpenAsync(AboutModel.MoreInfoUrl);
        }
    }
}

