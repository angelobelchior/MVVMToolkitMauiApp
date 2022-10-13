using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVMappToolKitApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;

        public BaseViewModel()
        {

        }
    }
}
