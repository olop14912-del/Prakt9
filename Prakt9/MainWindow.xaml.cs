using System;
using System.Collections.Generic;
using System.Windows;

namespace Prakt9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Проверка наличия числа в интервале [a; b]
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаём обобщённую коллекцию целых чисел
                List<int> numbers = new List<int>();

                // Разделяем введённую строку на отдельные числа
                string[] parts = txtNumbers.Text.Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                // Добавляем числа в коллекцию
                foreach (string part in parts)
                {
                    numbers.Add(Convert.ToInt32(part));
                }

                // Получаем границы интервала
                int a = Convert.ToInt32(txtA.Text);
                int b = Convert.ToInt32(txtB.Text);

                // Проверяем правильность интервала
                if (a > b)
                {
                    MessageBox.Show("Число a должно быть меньше или равно b.");
                    return;
                }

                bool found = false;
                int foundNumber = 0;

                // Перебираем все элементы коллекции
                foreach (int number in numbers)
                {
                    // Проверяем попадание в интервал [a; b]
                    if (number >= a && number <= b)
                    {
                        found = true;
                        foundNumber = number;
                        break;
                    }
                }

                if (found)
                {
                    txtResult.Text =
                        $"Элемент найден: {foundNumber} входит в интервал [{a}; {b}]";
                }
                else
                {
                    txtResult.Text =
                        $"В интервале [{a}; {b}] элементов нет";
                }
            }
            catch
            {
                MessageBox.Show(
                    "Введите целые числа через пробел.",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Разработчик: Клейменов Никита\n\n" +
                "Практическая работа №9\n" +
                "Коллекции. Обобщённые типы.\n\n" +
                "Задание: проверить, имеется ли в одномерном массиве " +
                "хотя бы один элемент, попадающий в интервал [a; b].",
                "О программе");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}