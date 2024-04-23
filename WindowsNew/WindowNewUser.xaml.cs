using KursovayaMAIN.Model;
using KursovayaMAIN.ViewModel;
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
using System.Windows.Shapes;

namespace KursovayaMAIN.WindowUser
{
    /// <summary>
    /// Логика взаимодействия для WindowNewUser.xaml
    /// </summary>
    public partial class WindowNewUser : Window
    {
        public WindowNewUser()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void TbPasNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; // Отменяем ввод символа
                MessageBox.Show($"Введите последовательность из 6 цифр!");
            }
        }

        private void TbPasSeries_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show($"Введите последовательность из 4 цифр!");
            }
        }

        private void TbSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show($"Введите строковое значение!");
            }
        }

        private void TbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show($"Введите строковое значение!");
            }
        }
    }
}
