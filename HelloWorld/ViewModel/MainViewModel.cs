using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace NoteApplicationMaui.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel(IConnectivity connectivity) 
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        // : INotifyPropertyChanged
        //string text;
        //public string Text
        //{
        //    get => text; 
        //    set
        //    {
        //        text = value;
        //        OnPropertyChanged(nameof(Text));
        //    }
        //}

        //public event PropertyChangedEventHandler? PropertyChanged;
        //void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;
        IConnectivity connectivity;

        [RelayCommand]
        async void Add()
        {
            if (string.IsNullOrWhiteSpace(Text)) 
            {
                return;
            }
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Uh Oh", "No Internet Access", "OK");
                return;
            }
            Items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        void Remove(string sample) 
        {
            if(Items.Contains(sample))
            {
                Items.Remove(sample);
            }
        }

        [RelayCommand]
        async void Tap(string sample)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={sample}");
        }
    }
}
