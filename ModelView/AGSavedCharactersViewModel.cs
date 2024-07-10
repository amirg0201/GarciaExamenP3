using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GarciaExamenP3.Models;
using GarciaExamenP3.Services;

namespace GarciaExamenP3.ModelView
{
    public class AGSavedCharactersViewModel : INotifyPropertyChanged
    {
        private readonly AGCharacterDatabase _characterDatabase;
        public ObservableCollection<AGCharacter> SavedCharacters { get; }

        public AGSavedCharactersViewModel()
        {
            _characterDatabase = new AGCharacterDatabase(Constants.DatabasePath);
            SavedCharacters = new ObservableCollection<AGCharacter>();
            LoadSavedCharactersAsync();
        }

        private async Task LoadSavedCharactersAsync()
        {
            var characters = await _characterDatabase.GetCharactersAsync();
            SavedCharacters.Clear();
            foreach (var character in characters)
            {
                SavedCharacters.Add(character);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
