using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FNVCB.VIEWMODEL.Interfaces
{
    public interface IConsole_VM
    {
        public ObservableCollection<IGuess_VM> Guesses { get; set; }
        public ObservableCollection<string> Console_lines { get; set; }
        public IGuess_VM SelectedItem { get; set; }
        public ICommand RemoveItem { get; }
    }
}
