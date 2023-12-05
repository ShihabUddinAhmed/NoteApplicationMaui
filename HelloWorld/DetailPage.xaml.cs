using NoteApplicationMaui.ViewModel;

namespace NoteApplicationMaui;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}