using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FNVCG.VIEWMODEL.Interfaces
{
    public interface IConsole_VM
    {
        public string HeaderLine1 { get; set; }
        public string HeaderLine2 { get; set; }
        public string HeaderLine3 { get; set; }

        public ObservableCollection<string> Column_1 { get; set; }
        public ObservableCollection<string> Column_2 { get; set; }
        public ObservableCollection<string> Console_lines { get; set; }
        public int SelectedIndexColumn1 { get; set; }
        public int SelectedIndexColumn2 { get; set; }

    }
}
