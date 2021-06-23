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

namespace ToDoList08
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            foreach (UkolClass item in UkolClass.ukoly)
            {
                seznamListBox.Items.Add(NovyLabel(item.cinnost, item.datum, item.splneno));
                
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UkolClass ukol = new UkolClass();
            ukol.cinnost = cinnostTextBox.Text;
            ukol.info = infoTextBox.Text;
            if (cinnostTextBox.Text != "" && infoTextBox.Text !="")
            {
                try
                {
                    ukol.datum = datumDatePicker.SelectedDate.Value;
                    if (UkolClass.ukoly.Add(ukol))
                    {
                        seznamListBox.Items.Add(NovyLabel(ukol.cinnost, ukol.datum, ukol.splneno));
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Musíš zadat datum.");
                }
            }
            else
            {
                MessageBox.Show("Zadej všechny hodnoty.");
            }
            
           
            //ukoly.Add(ukol);
            
        }
        private Label NovyLabel(string cinnost, DateTime datum, bool splneno)
        {
            string x = "";
            if(splneno == true)
            {
                x = "Splněno";
            }
            else
            {
                x = "Nesplněno";
            }
            Label label = new Label();
            label.Content = cinnost + " " + datum.Day+"."+datum.Month+ "." + datum.Year + " " + x;
            label.Height = 30;
            label.Width = 230;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Top;
            if (datum < DateTime.Now)
            {
                label.Background = Brushes.Red;
            }
            return label;
        }
        private void OdstranitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] x = seznamListBox.SelectedItem.ToString().Split(' ');
                foreach (UkolClass item in UkolClass.ukoly)
                {
                    if (item.cinnost == x[1])
                    {
                        UkolClass.ukoly.Remove(item);
                        seznamListBox.Items.Remove(seznamListBox.SelectedItem);
                        break;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nenakliknutá žádná položka.");
            }
             
        }
        private void UpravitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] x = seznamListBox.SelectedItem.ToString().Split(' ');
                foreach (UkolClass item in UkolClass.ukoly)
                {
                    if (item.cinnost == x[1])
                    {
                        EditWindow window = new EditWindow(item.cinnost, item.info, item.datum);
                        window.Show();
                        Close();
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nenalezeny žádné položky.");
            }
            
            
            
        }
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] x = seznamListBox.SelectedItem.ToString().Split(' ');
                foreach (UkolClass item in UkolClass.ukoly)
                {
                    if (item.cinnost == x[1])
                    {
                        MessageBox.Show(item.info);
                        break;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nenakliknutá žádná položka.");
            }
           
        }

        private void UlozitButton_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter soubor = new StreamWriter("soubor.txt");
            foreach (UkolClass item in UkolClass.ukoly)
            {
                soubor.WriteLine(item.cinnost + " " + item.datum + " " + item.info + " " + item.splneno);
            }
            soubor.Close();
        }

        private void NacistButton_Click(object sender, RoutedEventArgs e)
        {
            
            StreamReader soubor = new StreamReader("soubor.txt");
            
            while (!soubor.EndOfStream)
            {
                UkolClass ukol = new UkolClass();
                string[] x = soubor.ReadLine().Split(' ');
                ukol.cinnost = x[0];
                ukol.datum = DateTime.Parse(x[1]);
                ukol.info = x[3];
                if (x[4] == "False")
                {
                    ukol.splneno = false;
                }
                else
                {
                    ukol.splneno = true;
                }
                UkolClass.ukoly.Add(ukol);
            }
            string xx = "";
            seznamListBox.Items.Clear();
            foreach (UkolClass item in UkolClass.ukoly)
            {
                seznamListBox.Items.Add(NovyLabel(item.cinnost, item.datum, item.splneno));
                xx += item.cinnost+" ";
            }
            soubor.Close();
        }
    }
}
