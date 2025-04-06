using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp20.Pages
{
    /// <summary>
    /// Логика взаимодействия для Task1Page.xaml
    /// </summary>
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }


        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = ArrayBoxOne.Text;
                string[] items = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);

                if (items.Length != 12)
                {
                    MessageBox.Show("Введите ровно 12 целых чисел.");
                    return;
                }

                int[,] matrix = new int[3, 4];
                int index = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (!int.TryParse(items[index], out matrix[i, j]))
                        {
                            MessageBox.Show("Неверный ввод. Используйте только целые числа.");
                            return;
                        }
                        index++;
                    }
                }

                // Сортировка последней строки
                int[] lastRow = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    lastRow[j] = matrix[2, j];
                }

                Array.Sort(lastRow);

                for (int j = 0; j < 4; j++)
                {
                    matrix[2, j] = lastRow[j];
                }

                // Формирование результата
                string output = "Результат:\n";
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        output += matrix[i, j] + " ";
                    }
                    output += "\n";
                }

                ResultTextBlock.Text = output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
