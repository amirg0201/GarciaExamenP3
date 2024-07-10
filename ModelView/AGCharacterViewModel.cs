using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Refit;
using GarciaExamenP3.Models;
using GarciaExamenP3.Services;

namespace GarciaExamenP3.ModelView
{
    public class AGCharacterViewModel : INotifyPropertyChanged
    {
        private readonly AGMarvelApi _marvelApi;
        private const string PublicKey = "2d154f798bb1b6c73075218d0d35a2d6";
        private const string PrivateKey = "93f900dfea672cd4993f6f791077270ba94acc45";
        private const string Timestamp = "1";
        private string Hash => CreateHash(Timestamp, PrivateKey, PublicKey);
        public ObservableCollection<AGCharacter> Characters { get; }
        private readonly AGCharacterDatabase _characterDatabase;

        public AGCharacterViewModel()
        {
            _marvelApi = RestService.For<AGMarvelApi>("https://gateway.marvel.com");
            _characterDatabase = new AGCharacterDatabase(Constants.DatabasePath);
            Characters = new ObservableCollection<AGCharacter>();
            LoadCharactersCommand = new Command(async () => await LoadCharactersAsync());
        }

        public ICommand LoadCharactersCommand { get; }

        private async Task LoadCharactersAsync()
        {
            var response = await _marvelApi.GetCharactersAsync(PublicKey, Hash, Timestamp);
            Characters.Clear();
            foreach (var character in response.Data.Results)
            {
                Characters.Add(character);
            }
        }

        private async Task SaveCharacterAsync(AGCharacter character)
        {
            await _characterDatabase.SaveCharacterAsync(character);
        }

        private string CreateHash(string timestamp, string privateKey, string publicKey)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes($"{timestamp}{privateKey}{publicKey}");
                var hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
