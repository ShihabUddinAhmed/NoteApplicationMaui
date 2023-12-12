using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoteApplicationMaui.ViewModel
{
    [QueryProperty(nameof(MainViewModel), "MainViewModel")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        MainViewModel mainViewModel;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
