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
using MySql.Data.MySqlClient;
using System.Collections;
using Microsoft.Maps.MapControl.WPF;
using System.Globalization;
using Bytescout.Spreadsheet;
using System.IO;

namespace Radiation_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string connectionString = "server=localhost; database=radiationdb; user=root; password=; Allow Zero Datetime=True; Convert Zero Datetime=True";
        public Dictionary<string, string> countyCoordinatesList = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            connectAndQueryDB();
            
        }


        public void connectAndQueryDB()
        {
            MySqlCommand cmd;
            MySqlDataReader reader;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection status OK");
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM `countiesinfo`;";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string unused = "";
                        if (!countyCoordinatesList.TryGetValue(reader["name"].ToString(), out unused))
                        {
                            countyCoordinatesList.Add(reader["name"].ToString(), reader["lat"].ToString() + "&" + reader["lng"].ToString());
                            CountyList.Items.Add(reader["name"].ToString());
                        }
                    }
                    conn.Close();
                }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
                catch (MySqlException e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
                {
                    MessageBox.Show("Conection error with the DB", "Warning", MessageBoxButton.OK);
                }

            }
        }

        public Boolean checkAllDigits(String text)
        {
            Boolean allDigits = false;
            foreach (char singleCharacter in text)
            {
                if (singleCharacter == '.' || singleCharacter == '-')
                {
                    //Console.WriteLine("ES UN PUNTO o el signo de menos");
                    continue;
                }
                else
                {
                    int val = (int)Char.GetNumericValue(singleCharacter);
                    if (val == -1)
                    {
                        //Console.WriteLine("IT'S a String");
                        allDigits = false;
                        break;
                    }
                    else
                    {
                        //Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",singleCharacter.GetType().Name, singleCharacter,val.GetType().Name, val);
                        allDigits = true;
                    }
                }
            }
            return allDigits;
        }

        private void latitudeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var brush = new BrushConverter();
            if(!String.IsNullOrEmpty(textBox.Text))
            {
                Boolean allDigits = checkAllDigits(textBox.Text);
                if (!allDigits)
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FF3333");
                }
                else
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                    if(longitudeTB != null)
                    {
                        if (!String.IsNullOrEmpty(textBox.Text) && !String.IsNullOrEmpty(longitudeTB.Text))
                        {
                            Pushpin pin = new Pushpin();
                            pin.Location = new Location(Double.Parse(textBox.Text), Double.Parse(longitudeTB.Text));
                            if(bmap!=null)
                            {
                                bmap.Children.Clear();
                                bmap.SetView(pin.Location, 5);
                                bmap.Children.Add(pin);
                            }
                        }
                    }
                }
            }
            else
            {
                textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            }
        }

        private void longitudeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var brush = new BrushConverter();
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                Boolean allDigits = checkAllDigits(textBox.Text);
                if (!allDigits)
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FF3333");
                }
                else
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                    if(latitudeTB != null)
                    {
                        if (!String.IsNullOrEmpty(textBox.Text) && !String.IsNullOrEmpty(latitudeTB.Text))
                        {
                            Pushpin pin = new Pushpin();
                            pin.Location = new Location(Double.Parse(latitudeTB.Text), Double.Parse(textBox.Text));
                            if (bmap != null)
                            {
                                bmap.Children.Clear();
                                bmap.SetView(pin.Location, 5);
                                bmap.Children.Add(pin);
                            }
                        }
                    }
                }
            }
            else
            {
                textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            }
        }

        private void CountyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ListView;
            
            foreach (KeyValuePair<string,string> countyInfo in countyCoordinatesList)
            {
                string[] splitted = countyInfo.Value.Split('&');
                //Console.WriteLine("KEY: " + countyInfo.Key + "---- lat: " + countyInfo.Value.Split('&')[0] + "-----lng: " + countyInfo.Value.Split('&')[1]);
                if(countyInfo.Key.Equals(item.SelectedItem))
                {
                    Pushpin pin = new Pushpin();
                    pin.Location = new Location(Double.Parse(splitted[0]), Double.Parse(splitted[1]));
                    bmap.Center = new Location(Double.Parse(splitted[0]), Double.Parse(splitted[1]));
                    bmap.ZoomLevel = 6;
                    latitudeTB.Text = splitted[0];
                    longitudeTB.Text = splitted[1];
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var brush = new BrushConverter();
            longitudeTB.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            latitudeTB.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            if (!startDate.SelectedDate.HasValue || !endDate.SelectedDate.HasValue)
            {
                startDate.Background = (Brush)brush.ConvertFrom("#FF3333");
                endDate.Background = (Brush)brush.ConvertFrom("#FF3333");
                MessageBox.Show("Check your Start Date and End Date", "Warning", MessageBoxButton.OK);
            }
            else
            {
                startDate.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                endDate.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                Double latitude = 0.00;
                Double longitude = 0.00;
                try
                {
                    latitude = Double.Parse(latitudeTB.Text.ToString());
                    longitude = Double.Parse(longitudeTB.Text.ToString());
                    resultsWindow window = new resultsWindow(startDate.SelectedDate.Value, endDate.SelectedDate.Value, latitude, longitude);
                    window.Show();
                    Close();
                }
                catch (Exception exc)
                {
                    longitudeTB.Background = (Brush)brush.ConvertFrom("#FF3333");
                    latitudeTB.Background = (Brush)brush.ConvertFrom("#FF3333");
                    MessageBox.Show("Check your coordinates" + exc.ToString(), "Warning", MessageBoxButton.OK);
                }
             }
        }

        private void updateDB_Click(object sender, RoutedEventArgs e)
        {
            if(CountyList.Items.Count==0)
            {
                readExcelFile();
                connectAndQueryDB();
            }
        }

        private void readExcelFile()
        {
            Spreadsheet document = new Spreadsheet();
            //path file 
            document.LoadFromFile("../../excelDB/schemaDB.xlsx");
            //name of the sheet
            Worksheet workSheet = document.Workbook.Worksheets.ByName("Sheet1");
            Dictionary<string, Dictionary<string, string> >countiesInfo = new Dictionary<string, Dictionary<String, String>>();
            Dictionary<string, string> countyInfo = new Dictionary<string, string>();
            //number of columns 
            for (int j = 2; j < 550; j++)
            {
                Cell currentCounty = workSheet.Cell("A"+j);
                Cell currentLat = workSheet.Cell("B" + j);
                Cell currentLng = workSheet.Cell("C" + j);
                Cell currentYearRange = workSheet.Cell("D" + j);
                MySqlCommand cmd;
                MySqlDataReader reader;
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        Console.WriteLine("Connection status OK "+ currentLat.ValueAsDouble);
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "INSERT INTO `countiesinfo`(`name`, `lat`, `lng`, `yearRange`) VALUES ('"+ currentCounty.ValueAsString + "','"+ currentLat.ValueAsDouble + "','"+ currentLng.ValueAsDouble + "','"+ currentYearRange.ValueAsString + "')";
                        reader = cmd.ExecuteReader();
                        Console.WriteLine(currentLng.ValueAsDouble);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DB not present "+ex.ToString());
                    }
                }
            }
            document.Close();
        }
    }
}
