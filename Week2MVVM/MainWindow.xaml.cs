using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week2MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Global variable so that the invoice text can be passed from calculation to export functions*/
        public string msg;

        public MainWindow()
        {
            InitializeComponent();

            /*Make export button invisible until a calculation is performed*/
            btnExport.Visibility = Visibility.Hidden;

        }       

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            decimal nBan, nApp, nOra, totBan, totApp, totOra, subTotal, delivFee, grandTotal;

            /*Check for valid input*/
            if (decimal.TryParse(qtyBan.Text, out nBan) &&
                (decimal.TryParse(qtyApp.Text, out nApp)) &&
                (decimal.TryParse(qtyOra.Text, out nOra)) &&
                nBan >= 0 && nApp >= 0 && nOra >= 0)
            {
                /*Calculate unit costs, subtotal, delivery, and grand total*/
                totBan = nBan * 0.19m;
                totApp = nApp * 2.40m;
                totOra = nOra * 3.99m;
                subTotal = totBan + totApp + totOra;
                
                if (subTotal < 25)
                {
                    delivFee = 10;
                }

                else
                {
                    delivFee = 0;
                }

                grandTotal = subTotal + delivFee;

                /*Populate labels and invoice message string*/
                subtotalBan.Content = "$" + totBan.ToString($"F{2}");
                subtotalApp.Content = "$" + totApp.ToString($"F{2}");
                subtotalOra.Content = "$" + totOra.ToString($"F{2}");
                lblSubtotalNum.Content = "$" + subTotal.ToString($"F{2}");
                lblDelivFeeNum.Content = "$" + delivFee.ToString($"F{2}");
                lblGrandTotalNum.Content = "$" + grandTotal.ToString($"F{2}");

                msg = "Joe's Fruit Stand @@          Price(kg)   Quantity   Cost ";

                if (totBan != 0)
                {
                    msg = string.Concat(msg, "@Bananas    $0.19         " + nBan + "      $" + totBan.ToString($"F{2}"));
                }

                if (totApp != 0)
                {
                    msg = string.Concat(msg, "@Apples     $2.40         " + nApp + "        $" + totApp.ToString($"F{2}"));
                }

                if (totOra != 0)
                {
                    msg = string.Concat(msg, "@Oranges    $3.77         " + nOra + "      $" + totOra.ToString($"F{2}"));
                }

                msg = string.Concat(msg, "@@                                     Subtotal $" + subTotal.ToString($"F{2}") +
                    "@                                     Delivery Fee $" + delivFee.ToString($"F{2}") +
                    "@@                                     Grand Total $" + grandTotal.ToString($"F{2}"));

                msg = msg.Replace("@", Environment.NewLine);

                /*Make export button visible*/
                btnExport.Visibility = Visibility.Visible;
            }

            /*Error pop up for invalid input*/
            else
            {
                MessageBox.Show("Please enter positive values");
            }


        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            {
                // Configure save file dialog box
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Invoice"; // Default file name
                dlg.DefaultExt = ".txt"; // Default file extension
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document, append the message text from the calculate function
                    string filename = dlg.FileName;
                    File.AppendAllText(filename, msg);
                }
            }
        }
    }
}
