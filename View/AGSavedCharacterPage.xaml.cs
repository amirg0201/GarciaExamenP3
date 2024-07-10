using GarciaExamenP3.ModelView;
namespace GarciaExamenP3.View;

public partial class AGSavedCharacterPage : ContentPage
{
	public AGSavedCharacterPage()
	{
		InitializeComponent();
        BindingContext = new AGSavedCharactersViewModel();
    }
}