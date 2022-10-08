using MVVMappToolKitApp.ViewModels;

namespace MVVMappToolKitApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
	}

	private void EntryNomeFocus(object sender, EventArgs e)
	{
		entryNome.Focus();
		entrySobrenome.Unfocus();
		
	}
	private void EntryNomeCompletado(object sender, EventArgs e)
	{
		entryNome.Unfocus();
		entrySobrenome.Focus();
		lblMessagem.Text=string.Empty;
    }

	private void EntrySobrenomeCompletado(object sender, EventArgs e)
	{
		
		btnInserirNome.Command.Execute(btnInserirNome);
		entryNome.Focus();
		entrySobrenome.Unfocus();
    }

	private void BtnInserirNome(object sender, EventArgs e)
	{
		entryNome.Focus();
		entrySobrenome.Unfocus();
	}

}