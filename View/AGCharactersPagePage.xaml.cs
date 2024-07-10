using GarciaExamenP3.ModelView;
namespace GarciaExamenP3.View;

public partial class AGCharactersPagePage : ContentPage
{
	public AGCharactersPagePage()
	{
		InitializeComponent();
        BindingContext = new AGCharacterViewModel();
    }
}