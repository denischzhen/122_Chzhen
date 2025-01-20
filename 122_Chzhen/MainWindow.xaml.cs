using System;
using System.Windows;

namespace _122_Chzhen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += Window_Closing;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double x, y;

            // Проверка на валидность ввода
            if (!double.TryParse(InputX.Text, out x) || !double.TryParse(InputY.Text, out y))
            {
                ResultBox.Text = "Ошибка: некорректный ввод";
                return;
            }

            double f_x = 0;

            // Выбор функции
            if (FuncSh.IsChecked == true)
            {
                f_x = Math.Sinh(x);
            }
            else if (FuncX2.IsChecked == true)
            {
                f_x = Math.Pow(x, 2);
            }
            else if (FuncExp.IsChecked == true)
            {
                f_x = Math.Exp(x);
            }

            // Вычисление d
            double d;
            if (x > y)
            {
                d = Math.Pow(f_x - y, 3) + Math.Atan(f_x);
            }
            else if (x < y)
            {
                d = Math.Pow(y - f_x, 3) + Math.Atan(f_x);
            }
            else
            {
                d = Math.Pow(y + f_x, 3) + 0.5;
            }

            // Обновление текстового поля с результатом
            ResultBox.Text = d.ToString("F2");
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputY.Clear();
            ResultBox.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Уверены, что хотите выйти из приложения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No) 
            {
                e.Cancel = true;
            }
        }
    }
}