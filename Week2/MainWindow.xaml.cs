using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDoIt_Click(object sender, RoutedEventArgs e)
        {
            //lblResult.Content = tbxFirst.Text + " " + tbxSecond.Text;
            //lblResult.Content = tbxFirst.Text + tbxSecond.Text;
            /*
            try
            {
                int first = int.Parse(tbxFirst.Text);
                int second = int.Parse(tbxSecond.Text);
                int result = first + second;
                lblResult.Content = result;
            }
            catch
            {
                MessageBox.Show("Hey dummy, not a number");
            }

            int first; 
            int second;
            if(int.TryParse(tbxFirst.Text, out first) &&
               int.TryParse(tbxSecond.Text, out second))
            {
                int result = first + second;
                lblResult.Content = result;
            }
            else
                MessageBox.Show("Hey dummy, not a number");
            */

            decimal first;
            decimal second;
            if (decimal.TryParse(tbxFirst.Text, out first) &&
                decimal.TryParse(tbxSecond.Text, out second))
            {
                decimal result = first * second;
                lblResult.Content = result;
            }
            else
                MessageBox.Show("Hey dummy, not a number");
        }

        private void btnClearIt_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = string.Empty;
            tbxFirst.Text = string.Empty;
            tbxSecond.Text = string.Empty;
        }
    }
}
