using System;
using System.Windows;

namespace _122_Chzhen
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(InputX.Text);
                double y = double.Parse(InputY.Text);
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

                ResultBox.Text = d.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputY.Clear();
            ResultBox.Clear();
        }
    }
}