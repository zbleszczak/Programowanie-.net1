using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie2
{
    public partial class MainWindow : Window
    {
        private double _lastNumber;
        private string _displayedExpression;
        private string? _selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            _selectedOperator = string.Empty;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (string.IsNullOrEmpty(_selectedOperator))
            {
                txtDisplay.Text += number;
                _displayedExpression = txtDisplay.Text;
            }
            else
            {
                txtDisplay.Text = number;
                _displayedExpression = $"{_lastNumber} {_selectedOperator} {number}";
            }

            txtExpression.Text = _displayedExpression;
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
                _displayedExpression += ".";
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _selectedOperator = button.Content.ToString();
            _lastNumber = double.Parse(txtDisplay.Text);
            _displayedExpression += $" {_selectedOperator} ";
            txtExpression.Text = _displayedExpression;
        }
        private void ClearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1);
                _displayedExpression = _displayedExpression.Remove(_displayedExpression.Length - 1);
                txtExpression.Text = _displayedExpression;
            }
            else if (!string.IsNullOrEmpty(_displayedExpression) && _displayedExpression.EndsWith(" "))
            {
                _displayedExpression = _displayedExpression.Remove(_displayedExpression.Length - 3);
                txtExpression.Text = _displayedExpression;
            }
        }
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_selectedOperator) && !string.IsNullOrEmpty(txtDisplay.Text))
            {
                double newNumber = double.Parse(txtDisplay.Text);
                double result = PerformOperation(_selectedOperator, _lastNumber, newNumber);

                string currentExpression = $"{_lastNumber} {_selectedOperator} {newNumber} = {result}";
                txtPreviousExpression.Text = currentExpression;

                _displayedExpression = result.ToString();
                txtExpression.Text = string.Empty;
                txtDisplay.Text = _displayedExpression;

                _selectedOperator = string.Empty;
                _lastNumber = result;
            }
        }
        private double PerformOperation(string operation, double a, double b)
        {
            switch (operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b != 0)
                    {
                        return a / b;
                    }
                    else
                    {
                        throw new DivideByZeroException("Nie można dzielić przez zero.");
                    }
                case "^":
                    return Math.Pow(a, b);
                case "%":
                    if (b != 0)
                    {
                        return a % b;
                    }
                    else
                    {
                        throw new DivideByZeroException("Nie można dzielić przez zero.");
                    }
                default:
                    throw new ArgumentException("Nieprawidłowy operator.");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = string.Empty;
            txtExpression.Text = string.Empty;
            _displayedExpression = string.Empty;
        }

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string functionName = button.Content.ToString();

            if (!string.IsNullOrEmpty(txtDisplay.Text))
            {
                try
                {
                    string numberString = txtDisplay.Text.Replace(',', '.');
                    double number = double.Parse(numberString, CultureInfo.InvariantCulture);
                    double result = PerformFunction(functionName, number);

                    string resultString = result.ToString(CultureInfo.InvariantCulture);
                    string currentExpression = $"{functionName}({txtDisplay.Text}) = {resultString}";
                    txtPreviousExpression.Text = currentExpression;

                    _displayedExpression = resultString;
                    txtExpression.Text = string.Empty;
                    txtDisplay.Text = _displayedExpression;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private double PerformFunction(string function, double x)
        {
            switch (function)
            {
                case "√":
                    return Math.Sqrt(x);
                case "1/x":
                    return 1 / x;
                case "x!":
                    return Factorial(x);
                case "log":
                    return Math.Log10(x);
                case "ln":
                    return Math.Log(x);
                case "ZaokDół":
                    return Math.Floor(x);
                case "Zaokr^":
                    return Math.Ceiling(x);
                default:
                    return x;
            }
        }

        private double Factorial(double x)
        {
            if (x < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            int n = (int)x;
            if (n != x)
            {
                throw new ArgumentException("Factorial is only defined for non-negative integers.");
            }

            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}