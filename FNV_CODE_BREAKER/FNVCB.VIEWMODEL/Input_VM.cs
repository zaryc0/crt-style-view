using FNVCB.COMMON.Events;
using FNVCB.COMMON.Interfaces;
using FNVCB.MODEL.Interfaces;
using FNVCB.VIEWMODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FNVCB.VIEWMODEL
{
    public class Input_VM : BaseViewModel, IInput_VM
    {
        #region local variables
        private IEventAggregator _eventAggregator;
        private IModelFactory _modelFactory;
        private string _value;
        private string _score;
        private int _state;

        #endregion
        
        #region constructors
        public Input_VM() { }
        public Input_VM(IEventAggregator ea, IModelFactory mf) 
        {
            _eventAggregator = ea;
            _modelFactory = mf;
            _state = -1;
            _value = "";
            _score = "";
            Submit = new RelayCommand(o => SubmitInput());
        }
        #endregion

        #region access properties
        public string Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value.ToUpper();
                    Update();
                    NotifyPropertyChanged(nameof(Value));
                }
            }
        }
        public string Score 
        { 
            get => _score;
            set 
            {
                if (Score != value)
                {
                    _score = value;
                    Update();
                    NotifyPropertyChanged(nameof(Score));
                }
            } 
        }
        public string Submission
        {
            get
            {
                return _state switch
                {
                    0  => "SUBM",
                    1  => "COMP",
                    _  => "NONE",
                };
            }
        }
        #endregion

        #region commands
        public ICommand Submit { get; private set; } 
        public void SubmitInput()
        { 
            switch(_state)
            {
                case 0:
                    SubmitGuess(); 
                    break;
                case 1:
                    SubmitComparisson();
                    break;
                default:
                    DontSubmit();
                    break;
            }
        }
        #endregion

        #region functions
        private void SubmitGuess()
        {
            GuessAddedEvent e = new()
            {
                Value = _value.ToUpper(),
                Score = _score
            };
            _eventAggregator.Publish(e);
            ClearValues();
        }

        private void SubmitComparisson()
        {
            ComparisonAddedEvent e = new()
            {
                Value = _value.ToUpper()
            };
            _eventAggregator.Publish(e);
            ClearValues();
        }

        private void DontSubmit() 
        {
            _eventAggregator.Publish(new ClearCacheEvent());
        }


        private void Update()
        {
            if (_value == "")
            {
                _state = -1;
            }
            else
            {
                if (_score == "")
                {
                    _state = 1;
                }
                else
                {
                    _state = 0;
                }
            }
            NotifyPropertyChanged(nameof(Submission));
        }
        private void ClearValues()
        {
            Score = "";
            Value = "";
        }
        #endregion
    }
}
