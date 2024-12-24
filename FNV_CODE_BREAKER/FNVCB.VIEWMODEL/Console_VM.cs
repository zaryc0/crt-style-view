using FNVCB.COMMON.Events;
using FNVCB.COMMON.Interfaces;
using FNVCB.MODEL.Interfaces;
using FNVCB.VIEWMODEL.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FNVCB.VIEWMODEL
{
    public class Console_VM : BaseViewModel, IConsole_VM, 
        ISubscriber<GuessAddedEvent>, 
        ISubscriber<UpdateOutputEvent>, 
        ISubscriber<ComparisonAddedEvent>,
        ISubscriber<ClearCacheEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IModelFactory _modelFactory;
        private readonly ICodeBreaker _codeBreaker;

        public Console_VM() { }
        public Console_VM(IEventAggregator ea, IViewModelFactory vmf , IModelFactory mf)
        {
            _eventAggregator = ea;
            _viewModelFactory = vmf;
            _modelFactory = mf;
            Guesses = [];
            Console_lines = new ObservableCollection<string>();
            _eventAggregator.Subsribe((ISubscriber<ComparisonAddedEvent>)this);
            _eventAggregator.Subsribe((ISubscriber<GuessAddedEvent>)this);
            _eventAggregator.Subsribe((ISubscriber<UpdateOutputEvent>)this);
            _eventAggregator.Subsribe((ISubscriber<ClearCacheEvent>)this);
            _codeBreaker = mf.GenerateCodeBreaker();
            RemoveItem = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        }
        public ObservableCollection<IGuess_VM> Guesses { get; set; }
        public ObservableCollection<string> Console_lines { get; set; }
        public IGuess_VM SelectedItem { get; set; }

        public ICommand RemoveItem { get; }

        public void OnEventHandler(GuessAddedEvent e)
        {
            if (int.TryParse(e.Score, out int result))
            {
                IGuess guess = _modelFactory.GenerateGuess(value: e.Value, 
                                                           score: result);
                _codeBreaker.AddGuess(guess);
                IGuess_VM guess_vm = _viewModelFactory.GetGuessVM(guess);
                Guesses.Add(guess_vm);
            }
            else
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"ERROR score :{e.Score}: is not a valid integer...\n" });
            }
        }

        public void OnEventHandler(UpdateOutputEvent e)
        {
            string formattedLine = $">> {e.NewLine}";
            Application.Current.Dispatcher.Invoke(() =>
            {
                Console_lines.Add(formattedLine);
            });
        }

        public void OnEventHandler(ComparisonAddedEvent e)
        {
            _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"CHECKING {e.Value} ... " });
            int err_code = _codeBreaker.CompareResult(e.Value, out bool result);
            if (err_code < 0)
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"INCORRECT {e.Value} incorrect length ..." });
            }
            if (err_code == 1)
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"INCORRECT {e.Value} too few matches ..." });
            }
            if (err_code == 2)
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"INCORRECT {e.Value} too many matches ..." });
            }
            if (err_code == 0)
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"POSSIBLE ANSWER {e.Value}" });
            }
        }

        public void OnEventHandler(ClearCacheEvent e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Guesses.Clear();
                _codeBreaker.ClearCache();
            });
        }

        // Can execute logic (Only executes if the selected item is not null)
        private bool CanExecuteDeleteCommand(object parameter)
        {
            return SelectedItem is not null && Guesses.Contains(SelectedItem);
        }

        // Executes the logic to delete the selected item
        private void ExecuteDeleteCommand(object parameter)
        {
            int selectedIndex = Guesses.IndexOf(SelectedItem);
            Guesses.RemoveAt(selectedIndex);
            _codeBreaker.RemoveGuessAt(selectedIndex);

        }
    }
}
