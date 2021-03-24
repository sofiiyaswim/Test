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

using sueta.Properties;
using sueta;
using Microsoft.Win32;
using System.IO;

namespace sueta
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SearchCombo.ItemsSource = comboList;
            SearchCombo.SelectedIndex = 0;
        }

        List<string> comboList = new List<string> { "Linear", "KMP", "BM" };

        private string OpenUri { get; set; }
        private string SaveUri { get; set; }
        private string Text { get; set; }

        private void OpenButt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files .txt|*.txt";

            if (fileDialog.ShowDialog() == true)
            {
                this.OpenUri = fileDialog.FileName;

                using (StreamReader sr = File.OpenText(this.OpenUri))
                {
                    this.Text = sr.ReadToEnd();
                    InfomationTextBlock.Text = this.Text;
                }
            }
        }



        private void SaveButt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files .txt|*.txt";

            if (fileDialog.ShowDialog() == true)
            {
                this.SaveUri = fileDialog.FileName;

                using (StreamWriter sw = File.CreateText(this.SaveUri))
                {
                    int index = -1;
                    if (SearchCombo.SelectedIndex == 0)
                    {
                        index = Search.LinearSearch(SubStringTextBox.Text, this.Text);
                        MessageBox.Show((string)SearchCombo.SelectedItem);
                    }
                    else if(SearchCombo.SelectedIndex == 1)
                    {
                        index = Search.KMPSearch(SubStringTextBox.Text, this.Text);
                        MessageBox.Show("KMP");
                    }
                    else if(SearchCombo.SelectedIndex == 2)
                    {
                        index = Search.BMSearch(SubStringTextBox.Text, this.Text);
                        MessageBox.Show("BM");
                    }
                    sw.WriteLine(index);
                }
            }
        }
    }
}
