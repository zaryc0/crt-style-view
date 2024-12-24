using FNVCG.COMMON.Events;
using FNVCG.COMMON.Interfaces;
using FNVCG.MODEL.Interfaces;
using FNVCG.VIEWMODEL.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;

namespace FNVCG.VIEWMODEL
{
    public class Console_VM : BaseViewModel, IConsole_VM,
        ISubscriber<SelectionMadeEvent>,
        ISubscriber<UpdateOutputEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IModelFactory _modelFactory;
        private readonly ICodeGenerator _codeGenerator;
        private ICodeBreaker _codeBreaker;

        private string _headerBlockLine1; // intro
        private string _headerBlockLine2; // warning message
        private string _headerBlockLine3; // remianing attempts notificaiton
        private int _attemptsRemaining;
        private int _selectedIndex1;
        private int _selectedIndex2;
        private List<string> _words;

        public Console_VM() { }
        public Console_VM(IEventAggregator ea, IViewModelFactory vmf , IModelFactory mf)
        {
            Column_1 = [];
            Column_2 = [];
            Console_lines = [];

            _eventAggregator = ea;
            _viewModelFactory = vmf;
            _modelFactory = mf;
            _codeGenerator = mf.GenerateCodeGenerator();
            _codeBreaker = mf.GenerateCodeBreaker();
            _codeBreaker.ResetAttempts();
            _headerBlockLine1 = "ZARYCO INDUSTRIES (TM) TERMLINK PROTOCOL";
            _headerBlockLine2 = "ENTER PASSWORD NOW";
            _headerBlockLine3 = SetLineValue(_codeBreaker.GetRemainingAttempts());
            for (int i = 0; i < _attemptsRemaining; i++)
            {
                _headerBlockLine3 += " []";
            }
            ResetCode();
            for(int i = 0; i < 20; i++ )
            {
                if (i<10) Column_1.Add($"0X{i+925:X4}  " + PadString(_words[i]));
                else Column_2.Add($"0X{i + 925:X4}  " + PadString(_words[i]));
            }
            _eventAggregator.Subsribe((ISubscriber<UpdateOutputEvent>)this);
            _eventAggregator.Subsribe((ISubscriber<SelectionMadeEvent>)this);
        }

        public ObservableCollection<string> Column_1 { get; set; }
        public ObservableCollection<string> Column_2 { get; set; }
        public ObservableCollection<string> Console_lines { get; set; }

        public int SelectedIndexColumn1
        {
            get => _selectedIndex1;
            set
            {
                if (value != _selectedIndex1)
                {
                    _selectedIndex1 = value;
                    _eventAggregator.Publish(new SelectionMadeEvent() { Value = _words[value] });
                    NotifyPropertyChanged(nameof(SelectedIndexColumn1));
                }
            }
        }
        public int SelectedIndexColumn2
        {
            get => _selectedIndex2;
            set
            {
                if (value != _selectedIndex2)
                {
                    _selectedIndex2 = value;
                    _eventAggregator.Publish(new SelectionMadeEvent() { Value = _words[value + 10] });
                    NotifyPropertyChanged(nameof(SelectedIndexColumn2));
                }
            }
        }

        public string HeaderLine1
        {
            get => _headerBlockLine1;
            set
            {
                if (value != _headerBlockLine1)
                {
                    _headerBlockLine1 = value;
                    NotifyPropertyChanged(nameof(HeaderLine1));
                }
            }
        }
        public string HeaderLine2 
        { 
            get => _headerBlockLine2;
            set
            {
                if (value != _headerBlockLine2)
                {
                    _headerBlockLine2 = value;
                    NotifyPropertyChanged(nameof(HeaderLine2));
                }
            }
        }
        public string HeaderLine3
        {
            get => _headerBlockLine3;
            set
            {
                if (value != _headerBlockLine3)
                {
                    _headerBlockLine3 = value;
                    NotifyPropertyChanged(nameof(HeaderLine3));
                }
            }
        }
        private void ResetCode()
        {
            _codeGenerator.ResetCache();
            _codeBreaker.ResetAttempts();
            _codeBreaker.ClearCache();

            _words = _codeGenerator.GetWordList();
            _codeGenerator.GenerateCode(out string code);
            _codeBreaker.SetCode(code);
        }

        private string SetLineValue(int value)
        {
            return $"{value} ATTEMPT(S) LEFT:";
        }

        private string PadString(string input)
        {
            char[] chars = ['!', '@', '<', '>', '!', '#', '[', ']', '{', '}', '(', ')', '-', '$', '*', '"', '|','^','\\','.','?','_',','];
            Random r = new();
            int out_length = 20;
            int padding_required = out_length - input.Length;
            int input_start_index = r.Next(0, padding_required);
            string output = "";

            for (int i = 0; i < out_length; i++)
            {
                if (i < input_start_index || i > input_start_index + input.Length)
                {
                    output += chars[r.Next(0, chars.Length)];
                }
                else if (i >= input_start_index && i < input_start_index + input.Length)
                {
                    output += input[i - input_start_index];
                }
            }
            return output;
        }

        #region Iscubscriber implementations
        public void OnEventHandler(SelectionMadeEvent e)
        {
            int score = _codeBreaker.CompareResult(e.Value, out bool result);
            HeaderLine3 = SetLineValue(_codeBreaker.GetRemainingAttempts());
            if (_codeBreaker.GetRemainingAttempts() == 1)
            {
                HeaderLine2 = "!!! WARNING: LOCKOUT IMMINENT !!!";
            }
            if (result)
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = "hit" });
            }
            else
            {
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"{e.Value}" });
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"Entry denied" });
                _eventAggregator.Publish(new UpdateOutputEvent() { NewLine = $"{score}/{e.Value.Length} correct." });
            }
        }

        public void OnEventHandler(UpdateOutputEvent e)
        {
            Console_lines.Add(">" + e.NewLine);
        }
        #endregion
    }
}
