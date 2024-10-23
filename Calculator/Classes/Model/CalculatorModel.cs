using Calculator.Classes.ViewModel;
using System;

namespace Calculator.Classes.Model
{
    public class CalculatorModel
    {
        public double PerformOperation(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "×":
                    return num1 * num2;
                case "÷":
                    if (num2 == 0) throw new DivideByZeroException("Нельзя делить на 0");
                    return num1 / num2;
                default:
                    throw new InvalidOperationException("Ошибка");
            }
        }

        public double PerformOperation(double num1, string operation)
        {
            switch (operation)
            {
                case "sqrt": // Извлечение квадратного корня
                    if (num1 < 0) throw new InvalidOperationException("Невозможно найти корень отрицательного числа");
                    return Math.Sqrt(num1);
                case "^2": // Возведение в степень
                    return Math.Pow(num1, 2);
                case "1/x": // дробь
                    return 1 / num1;
                case "+/-": 
                    return num1 * -1;
                default:
                    throw new InvalidOperationException("Ошибка");
            }
        }
    }
}
