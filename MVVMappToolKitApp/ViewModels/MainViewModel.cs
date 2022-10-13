using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MVVMappToolKitApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private const string V = "MKN Sorteios - App Oficial";
        [ObservableProperty]
        public string nome;

        [ObservableProperty]
        public string sobrenome;

        [ObservableProperty]
        private string pessoaGanhadora;

        [ObservableProperty]
        private string message;

        public ObservableCollection<string> Participantes { get; set; }

        public MainViewModel()
        {
            Title = V;

            Participantes = new ObservableCollection<string>();
        }

        [RelayCommand]
        private void SortearNome()
        {
            Message=string.Empty;
            try
            {
                if (!Participantes.Count.Equals(0))
                {
                    Random.Shared.Next(0, Participantes.Count);
                    var indice = Random.Shared.Next(0, Participantes.Count);
                    PessoaGanhadora = Participantes[indice];
                    Shell.Current.DisplayAlert($"Parabéns {PessoaGanhadora} !!!", "Voce foi o ganhador desta  rodada. ;)", "Ok");
                    Participantes.Remove(PessoaGanhadora);
                    Message = string.Empty;

                }
                else
                {
                    Message = "Impossivel realizar o sorteio. Erro: Lista vazia.";
                }
            }
            catch(Exception ex)
            {
                Message=$"Erro: Lista vazia. Erro: {ex.Message}";
                Shell.Current.DisplayAlert("ERRO.", $"{Message}", "Ok");
            }
        }

        [RelayCommand]
        private void IncluirNome()
        {
            Message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(Nome))
                {
                    Participantes.Add($"{Nome} {Sobrenome}");
                    Nome = string.Empty;
                    Sobrenome = string.Empty;
                    Message=string.Empty;

                }
                else
                {
                    Message=("Erro. O campo nome é obrigatorio.");
                }
            }
            catch(Exception ex)
            {
                Message = $"Impossibile inserir dados. Erro: {ex.Message}";
                Shell.Current.DisplayAlert("ERRO.", $"{Message}", "Ok");
                return;
            }
        }
    }
}
