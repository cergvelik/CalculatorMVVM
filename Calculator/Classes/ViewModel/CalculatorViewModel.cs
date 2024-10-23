using Calculator.Classes.Command;
using Calculator.Classes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator.Classes.ViewModel
{
    public class CalculatorViewModel : Notifier
    {
        private string _display;
        private double _result;
        private string _operation;
        private bool _isNewEntry;
        private readonly CalculatorModel _calculatorModel;

        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        public ICommand NumberCommand { get; }
        public ICommand OperationCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand SingleOperationCommand { get; }

        public CalculatorViewModel()
        {
            _calculatorModel = new CalculatorModel();
            Display = "";
            NumberCommand = new RelayCommand<string>(AddNumber);
            OperationCommand = new RelayCommand<string>(SetOperation);
            CalculateCommand = new RelayCommand(Calculate);
            ClearCommand = new RelayCommand(Clear);
            SingleOperationCommand = new RelayCommand<string>(PerformSingleOperation);
        }

        private void AddNumber(string number)
        {
            if (_isNewEntry)
            {
                Display = "";
                Display = number;
                _isNewEntry = false;
            }
            else
            {
                Display += number;
            }
        }

        private void SetOperation(string operation)
        {
            if (double.TryParse(Display, out double value))
            {
                _result = value;
                _operation = operation;
                _isNewEntry = true;
                Display += "\n" + operation;
            }
        }

        private void Calculate()
        {
            if (double.TryParse(Display, out double value))
            {
                _result = _calculatorModel.PerformOperation(_result, value, _operation);
                Display = _result.ToString();
                _isNewEntry = true;
            }
        }

        private void PerformSingleOperation(string operation)
        {
            if (double.TryParse(Display, out double value))
            {
                _result = _calculatorModel.PerformOperation(value, operation);
                Display = _result.ToString();
                _isNewEntry = true;
            }
        }


        private void Clear()
        {
            Display = "";
            _isNewEntry = true;
        }

    }
}
