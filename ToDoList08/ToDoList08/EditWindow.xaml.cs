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

namespace ToDoList08
{
    /// <summary>
    /// Interakční logika pro EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        string cinnostx;
        string infox;
        DateTime datumx;
        public EditWindow(string cinnost, string info, DateTime datum)
        {
            InitializeComponent();
            cinnostTextBox.Text = cinnost;
            infoTextBox.Text = info;
            datumDatePicker.SelectedDate = datum;
            cinnostx = cinnost;
            infox = info;
            datumx = datum;
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cinnostTextBox.Text!="" && infoTextBox.Text !="")
            {
                foreach (UkolClass item in UkolClass.ukoly)
                {
                    if (item.cinnost == cinnostx)
                    {
                        item.cinnost = cinnostTextBox.Text;
                        item.info = infoTextBox.Text;
                        if (splnenoCheckBox.IsChecked == true)
                        {
                            item.splneno = true;
                        }
                        else
                        {
                            item.splneno = false;
                        }
                        try
                        {
                            item.datum = datumDatePicker.SelectedDate.Value;
                            MainWindow window = new MainWindow();
                            window.Show();
                            Close();
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Musíš zadat datum.");
                        }
                        

                    }
                }
                
            }
            else
            {
                MessageBox.Show("Musíš zadat všechny hodnoty.");
            }
            
        }
    }
}
