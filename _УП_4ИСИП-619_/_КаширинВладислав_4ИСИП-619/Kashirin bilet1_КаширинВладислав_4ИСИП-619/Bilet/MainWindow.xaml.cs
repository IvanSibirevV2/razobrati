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

namespace Bilet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int sum = 0, i = 0; // объявляем переменные
        public string str;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) // если число то добавляем, если текст ничего не происходит 
        {
            str = txtBox.Text;//нет события
            if (txtBox.Text[i] == '1') sum += 1;
            if (txtBox.Text[i] == '2') sum += 2;
            if (txtBox.Text[i] == '3') sum += 3;
            if (txtBox.Text[i] == '4') sum += 4;
            if (txtBox.Text[i] == '5') sum += 5;
            if (txtBox.Text[i] == '6') sum += 6;
            if (txtBox.Text[i] == '7') sum += 7;
            if (txtBox.Text[i] == '8') sum += 8;
            if (txtBox.Text[i] == '9') sum += 9;
            i++; //увеличиваем число
            lbl.Content = sum.ToString(); // ввывод в лайбел 
        }
    }
}
