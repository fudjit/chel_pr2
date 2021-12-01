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
using System.IO;
using Microsoft.Win32;
using LibMas;
using Lib_5;

namespace chel_pr2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] mas;
        private void Создать_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(kolstolb.Text, out int Count) == true)
            {
                Mas.CreateArray(out mas, Count);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(nDiapoz.Text, out int nachDiapoz) == true && Int32.TryParse(kDiapoz.Text, out int konDiapoz) == true && Int32.TryParse(kolstolb.Text, out int Count) == true)
            {
                Mas.FillArray(out mas, nachDiapoz, konDiapoz, Count);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {     
                suum.Text = Convert.ToString(Practice.multiply(mas));
            }
            else MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Очистить_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Mas.ClearArray(ref mas);
                DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
            }
        }

        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            Mas.SaveArray(mas);
        }

        private void Открыть_Click(object sender, RoutedEventArgs e)
        {

            Mas.OpenArray(out mas);
            DataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Даанов Шахмар \nПрактическая работа №2\nВвести n целых чисел. Найти произведение чисел <3. Результат вывести на экран.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexColumn = e.Column.DisplayIndex;
            mas[indexColumn] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }

        private void sum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
