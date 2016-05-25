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

namespace Radiation_project
{
    /// <summary>
    /// Interaction logic for resultsWindow.xaml
    /// </summary>
    public partial class resultsWindow : Window
    {
        DateTime start, end;
        Double lat, longi;

        public resultsWindow(DateTime start, DateTime end, Double lat, Double longi)
        {
            InitializeComponent();
            doCalculations(start, end, lat, longi);

            this.start = start;
            this.end = end;
            this.lat = lat;
            this.longi = longi;

        }
        public void doCalculations(DateTime start, DateTime end, Double lat, Double longi)
        {
            Double latitude = lat, longitude = longi;
            double H0 = 0.00;
            DateTime aux;
            if (start > end)
            {
                aux = end;
                end = start;
                start = aux;
            }
            double days = (end - start).TotalDays;
            latitudeLabel.Content = latitude;
            longitudeLabel.Content = longitude;
            daysLabel.Content = days;
            int yearsDiff = end.Year - start.Year;
            if (yearsDiff == 0)
            {
                aux = new DateTime(start.Year, 1, 1);
                int daysInBetween = (int)(start - aux).TotalDays;
                int remainingDays = (int)(end - start).TotalDays;
                remainingDays = remainingDays + daysInBetween;
                double ws = 0.00;
                double oz = 0.00;
                for (int day = daysInBetween; day <= remainingDays; day++)
                {
                    double sConstant = 23.45 * Math.Sin((360.0 * ((284.0 + day) / 365.0)));
                    double tanSconstant = Math.Tan(sConstant);
                    double tanLatitude = -Math.Tan(latitude);
                    double tanAngleTimesTanS = tanLatitude * tanSconstant;
                    ws = Math.Acos(tanAngleTimesTanS); //degrees
                    oz = (Math.Cos(latitude) * Math.Cos(sConstant) * Math.Sin(ws)) + (((Math.PI * ws) / 180) * Math.Sin(latitude) * Math.Sin(sConstant));
                    double radiationConstant = 0.333828427;
                    double x = 44567 / Math.PI;
                    double y = Math.Cos(360 * (day / 365));
                    double z = (1 + 0.033 * Math.Cos(360 * (day / 365)));
                    double a = ((x * (1 + 0.033 * y * oz)) / 1000000) * radiationConstant;
                    if (a > 0.00)
                    {
                        H0 = H0 + a;
                    }
                }
                wsLabel.Content = ws.ToString();
                ozLabel.Content = oz.ToString();
                h0Label.Content = H0.ToString();
            }
            else if (yearsDiff > 0)
            {

                double sConstant, tanSconstant, tanLatitude, tanAngleTimesTanS, ws = 0.00, oz = 0.00, radiationConstant = 0.333828427, x, y, z, a;
                for (int year = 0; year < yearsDiff; year++)
                {
                    if (year == yearsDiff)
                    {
                        aux = new DateTime(start.Year, 1, 1);
                        for (int dayCount = (int)(end - aux).TotalDays; dayCount < 366; dayCount++)
                        {
                            sConstant = 23.45 * Math.Sin((360.0 * ((284.0 + dayCount) / 365.0)));
                            tanSconstant = Math.Tan(sConstant);
                            tanLatitude = -Math.Tan(latitude);
                            tanAngleTimesTanS = tanLatitude * tanSconstant;
                            ws = Math.Acos(tanAngleTimesTanS); //degrees
                            oz = (Math.Cos(latitude) * Math.Cos(sConstant) * Math.Sin(ws)) + (((Math.PI * ws) / 180) * Math.Sin(latitude) * Math.Sin(sConstant));
                            x = 44567 / Math.PI;
                            y = Math.Cos(360 * (dayCount / 365));
                            z = (1 + 0.033 * Math.Cos(360 * (dayCount / 365)));
                            a = ((x * (1 + 0.033 * y * oz)) / 1000000) * radiationConstant;
                            if (a > 0.00)
                            {
                                H0 = H0 + a;
                            }
                        }
                    }
                    else
                    {
                        aux = new DateTime(start.Year, 1, 1);
                        DateTime endDays = new DateTime(start.Year + year, 12, 31);
                        for (int dayCount = (int)(endDays - aux).TotalDays; dayCount < 366; dayCount++)
                        {
                            sConstant = 23.45 * Math.Sin((360.0 * ((284.0 + dayCount) / 365.0)));
                            tanSconstant = Math.Tan(sConstant);
                            tanLatitude = -Math.Tan(latitude);
                            tanAngleTimesTanS = tanLatitude * tanSconstant;
                            ws = Math.Acos(tanAngleTimesTanS); //degrees
                            oz = (Math.Cos(latitude) * Math.Cos(sConstant) * Math.Sin(ws)) + (((Math.PI * ws) / 180) * Math.Sin(latitude) * Math.Sin(sConstant));
                            x = 44567 / Math.PI;
                            y = Math.Cos(360 * (dayCount / 365));
                            z = (1 + 0.033 * Math.Cos(360 * (dayCount / 365)));
                            a = ((x * (1 + 0.033 * y * oz)) / 1000000) * radiationConstant;
                            if (a > 0.00)
                            {
                                H0 = H0 + a;
                            }
                        }
                    }
                }
                wsLabel.Content = ws.ToString();
                ozLabel.Content = oz.ToString();
                h0Label.Content = H0.ToString();
            }

        }

        private void toFoto(object sender, RoutedEventArgs e)
        {

            FotoVoltaico f = new FotoVoltaico(start, end, lat, longi);
            f.Show();
            Close();

        }

        private void toMain(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Thermo f = new Thermo(start, end, lat, longi);
            f.Show();
            Close();
        }
    }
}
