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
    /// Interaction logic for Thermo.xaml
    /// </summary>
    public partial class Thermo : Window
    {
        DateTime start, end;
        Double lat, longi;
        List<String> elegidos = new List<String>();


        public Thermo(DateTime start, DateTime end, Double lat, Double longi)
        {
            InitializeComponent();
            this.start = start;
            this.end = end;
            this.lat = lat;
            this.longi = longi;
        }

        private void toModelo(object sender, RoutedEventArgs e)
        {

        }

        private void cmbComponentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void toAdelante(object sender, RoutedEventArgs e)
        {
          
        }

        private void toAtras(object sender, RoutedEventArgs e)
        {
            resultsWindow f = new resultsWindow( start, end, lat, longi);
            f.Show();
            Close();

        }

        private void toConSel(object sender, RoutedEventArgs e)
        { 
            try {
                string selected = cmbMarca.SelectedItems[0].ToString().Substring(37);

                cmbComponentes.Items.Clear();
                cmbSeleccionado.Items.Clear();

                cmbSeleccionado.Items.Add(selected);
                cmbSeleccionado.Items.Add("---------------------------------------------------------------------");

                if (selected.Equals("EMMETI"))
                {
                    cmbComponentes.Items.Add("Controlador de diferencial de temperatura");
                    cmbComponentes.Items.Add("Kit de proteccion de sobretension para sensor de colector");
                    cmbComponentes.Items.Add("Sensores de temperatura");
                    cmbComponentes.Items.Add("Check de circulacion solar GSN1v 38");
                    cmbComponentes.Items.Add("Colector solar Acrobaleno SXT");

                    cmbSeleccionado.Items.Add("Controlador de diferencial de temperatura");
                    cmbSeleccionado.Items.Add("Kit de proteccion de sobretension para sensor de colector");
                    cmbSeleccionado.Items.Add("Sensores de temperatura");
                    cmbSeleccionado.Items.Add("Check de circulacion solar GSN1v 38");
                    cmbSeleccionado.Items.Add("Colector solar Acrobaleno SXT");

                    elegidos.Add("Controlador de diferencial de temperatura");
                    elegidos.Add("Kit de proteccion de sobretension para sensor de colector");
                    elegidos.Add("Sensores de temperatura");
                    elegidos.Add("Check de circulacion solar GSN1v 38");
                    elegidos.Add("Colector solar Acrobaleno SXT");
                }
                if (selected.Equals("VALLIANT"))
                { 
                    cmbComponentes.Items.Add("autoTHERM Solar flat plate collectors");
                    cmbComponentes.Items.Add("autoTHERM exclusive vacuum tube collector");
                    cmbComponentes.Items.Add("solar pump");
                    cmbComponentes.Items.Add("auroSTOR solar cylinders");
                    cmbComponentes.Items.Add("auroFLOW plus drainback systems");
                    cmbComponentes.Items.Add("solar controls");

                    cmbSeleccionado.Items.Add("autoTHERM Solar flat plate collectors");
                    cmbSeleccionado.Items.Add("autoTHERM exclusive vacuum tube collector");
                    cmbSeleccionado.Items.Add("solar pump");
                    cmbSeleccionado.Items.Add("auroSTOR solar cylinders");
                    cmbSeleccionado.Items.Add("auroFLOW plus drainback systems");
                    cmbSeleccionado.Items.Add("solar controls");

                    elegidos.Add("autoTHERM Solar flat plate collectors");
                    elegidos.Add("autoTHERM exclusive vacuum tube collector");
                    elegidos.Add("solar pump");
                    elegidos.Add("auroSTOR solar cylinders");
                    elegidos.Add("auroFLOW plus drainback systems");
                    elegidos.Add("solar controls");
                }
                if (selected.Equals("DAIKIN"))
                {
                    cmbComponentes.Items.Add("Solar panels");
                    cmbComponentes.Items.Add("Roof fixings");
                    cmbComponentes.Items.Add("Mounting rails and solar connection kit");
                    cmbComponentes.Items.Add("Solar controller");
                    cmbComponentes.Items.Add("Solar pump station");
                    cmbComponentes.Items.Add("Solar flow sensor (pressurised only)");
                    cmbComponentes.Items.Add("Solar fluid (pressurised only)");
                    cmbComponentes.Items.Add("Roof flashing (drainback only)");

                    cmbSeleccionado.Items.Add("Solar panels");
                    cmbSeleccionado.Items.Add("Roof fixings");
                    cmbSeleccionado.Items.Add("Mounting rails and solar connection kit");
                    cmbSeleccionado.Items.Add("Solar controller");
                    cmbSeleccionado.Items.Add("Solar pump station");
                    cmbSeleccionado.Items.Add("Solar flow sensor (pressurised only)");
                    cmbSeleccionado.Items.Add("Solar fluid (pressurised only)");
                    cmbSeleccionado.Items.Add("Roof flashing (drainback only)");

                    elegidos.Add("Solar panels");
                    elegidos.Add("Roof fixings");
                    elegidos.Add("Mounting rails and solar connection kit");
                    elegidos.Add("Solar controller");
                    elegidos.Add("Solar pump station");
                    elegidos.Add("Solar flow sensor (pressurised only)");
                    elegidos.Add("Solar fluid (pressurised only)");
                    elegidos.Add("Roof flashing (drainback only)");
                }
                if (selected.Equals("Waxman Renewables"))
                {
                    cmbComponentes.Items.Add("Solar controller level 3");
                    cmbComponentes.Items.Add("AG pump group OSSI Type 2");
                    cmbComponentes.Items.Add("AMK Toll Box");
                    cmbComponentes.Items.Add("Tycofor");
                    cmbComponentes.Items.Add("Stainless Light");

                    cmbSeleccionado.Items.Add("Solar controller level 3");
                    cmbSeleccionado.Items.Add("AG pump group OSSI Type 2");
                    cmbSeleccionado.Items.Add("AMK Toll Box");
                    cmbSeleccionado.Items.Add("Tycofor");
                    cmbSeleccionado.Items.Add("Stainless Light");

                    elegidos.Add("Solar controller level 3");
                    elegidos.Add("AG pump group OSSI Type 2");
                    elegidos.Add("AMK Toll Box");
                    elegidos.Add("Tycofor");
                    elegidos.Add("Stainless Light");
                }
                if (selected.Equals("Dimplex Renewables"))
                {
                    cmbComponentes.Items.Add("Collector");
                    cmbComponentes.Items.Add("Heat transfer system");
                    cmbComponentes.Items.Add("SCxn Solar Unvented cylinders");
                    cmbComponentes.Items.Add("Pump station");
                    cmbComponentes.Items.Add("control unit");
                    cmbComponentes.Items.Add("over volt box");
                    cmbComponentes.Items.Add("expansion vessel and fixing kit");
                    cmbComponentes.Items.Add("Controller");
                    cmbComponentes.Items.Add("Flush and fill pump");
                    cmbComponentes.Items.Add("Air separator");
                    cmbComponentes.Items.Add("Feed though tile");
                    cmbComponentes.Items.Add("Termostatic mixing valve");
                    cmbComponentes.Items.Add("Flow meter");
                    cmbComponentes.Items.Add("Hydraulic kit for integration with head pumps SOLHPHYPK");

                    cmbSeleccionado.Items.Add("Collector");
                    cmbSeleccionado.Items.Add("Heat transfer system");
                    cmbSeleccionado.Items.Add("SCxn Solar Unvented cylinders");
                    cmbSeleccionado.Items.Add("Pump station");
                    cmbSeleccionado.Items.Add("control unit");
                    cmbSeleccionado.Items.Add("over volt box");
                    cmbSeleccionado.Items.Add("expansion vessel and fixing kit");
                    cmbSeleccionado.Items.Add("Controller");
                    cmbSeleccionado.Items.Add("Flush and fill pump");
                    cmbSeleccionado.Items.Add("Air separator");
                    cmbSeleccionado.Items.Add("Feed though tile");
                    cmbSeleccionado.Items.Add("Termostatic mixing valve");
                    cmbSeleccionado.Items.Add("Flow meter");
                    cmbSeleccionado.Items.Add("Hydraulic kit for integration with head pumps SOLHPHYPK");

                    elegidos.Add("Collector");
                    elegidos.Add("Heat transfer system");
                    elegidos.Add("SCxn Solar Unvented cylinders");
                    elegidos.Add("Pump station");
                    elegidos.Add("control unit");
                    elegidos.Add("over volt box");
                    elegidos.Add("expansion vessel and fixing kit");
                    elegidos.Add("Controller");
                    elegidos.Add("Flush and fill pump");
                    elegidos.Add("Air separator");
                    elegidos.Add("Feed though tile");
                    elegidos.Add("Termostatic mixing valve");
                    elegidos.Add("Flow meter");
                    elegidos.Add("Hydraulic kit for integration with head pumps SOLHPHYPK");
                }
                if (selected.Equals("Oventrop"))
                {
                    cmbComponentes.Items.Add("Tube Collector OKP - 10 / 20");
                    cmbComponentes.Items.Add("Flat plate collector OKF - CK22");
                    cmbComponentes.Items.Add("Stations Regusol-130");
                    cmbComponentes.Items.Add("Stations Regusol-180");
                    cmbComponentes.Items.Add("Station Regusol X-uno with exchanger ");
                    cmbComponentes.Items.Add("Station Regusol X-Duo with exchanger ");
                    cmbComponentes.Items.Add("Regumaq X-30-B/XZ-30-B Stations for heating of potable water");
                    cmbComponentes.Items.Add("Regumaq XK Cascade control set for heating of potable water Control concepts");
                    cmbComponentes.Items.Add("Regtronic Controllers for solar and heating techniques");
                    cmbComponentes.Items.Add("Regucor WHS Energy storage centre Hydrocor Storage Cylinders ");
                    cmbComponentes.Items.Add("Solar Diaphragm expansion tanks, in-line tanks Pipes and fittings");
                    cmbComponentes.Items.Add("Further products for thermal solar energy");


                    cmbSeleccionado.Items.Add("Tube Collector OKP - 10 / 20");
                    cmbSeleccionado.Items.Add("Flat plate collector OKF - CK22");
                    cmbSeleccionado.Items.Add("Stations Regusol-130");
                    cmbSeleccionado.Items.Add("Stations Regusol-180");
                    cmbSeleccionado.Items.Add("Station Regusol X-uno with exchanger ");
                    cmbSeleccionado.Items.Add("Station Regusol X-Duo with exchanger ");
                    cmbSeleccionado.Items.Add("Regumaq X-30-B/XZ-30-B Stations for heating of potable water");
                    cmbSeleccionado.Items.Add("Regumaq XK Cascade control set for heating of potable water Control concepts");
                    cmbSeleccionado.Items.Add("Regtronic Controllers for solar and heating techniques");
                    cmbSeleccionado.Items.Add("Regucor WHS Energy storage centre Hydrocor Storage Cylinders ");
                    cmbSeleccionado.Items.Add("Solar Diaphragm expansion tanks, in-line tanks Pipes and fittings");
                    cmbSeleccionado.Items.Add("Further products for thermal solar energy");

                    elegidos.Add("Tube Collector OKP - 10 / 20");
                    elegidos.Add("Flat plate collector OKF - CK22");
                    elegidos.Add("Stations Regusol-130");
                    elegidos.Add("Stations Regusol-180");
                    elegidos.Add("Station Regusol X-uno with exchanger ");
                    elegidos.Add("Station Regusol X-Duo with exchanger ");
                    elegidos.Add("Regumaq X-30-B/XZ-30-B Stations for heating of potable water");
                    elegidos.Add("Regumaq XK Cascade control set for heating of potable water Control concepts");
                    elegidos.Add("Regtronic Controllers for solar and heating techniques");
                    elegidos.Add("Regucor WHS Energy storage centre Hydrocor Storage Cylinders ");
                    elegidos.Add("Solar Diaphragm expansion tanks, in-line tanks Pipes and fittings");
                    elegidos.Add("Further products for thermal solar energy");
                }
                if (selected.Equals("NU-HEAT"))
                {

                    cmbComponentes.Items.Add("Solar expansion vessel");
                    cmbComponentes.Items.Add("Solar pump station");
                    cmbComponentes.Items.Add("Solar safety valve discharge vessel ");
                    cmbComponentes.Items.Add("Solar drain-off");
                    cmbComponentes.Items.Add("Pre insulated flexible stainless steel pipe");
                    cmbComponentes.Items.Add("Cylinder Thermostat and timelock ");


                    cmbSeleccionado.Items.Add("Solar expansion vessel");
                    cmbSeleccionado.Items.Add("Solar pump station");
                    cmbSeleccionado.Items.Add("Solar safety valve discharge vessel ");
                    cmbSeleccionado.Items.Add("Solar drain-off");
                    cmbSeleccionado.Items.Add("Pre insulated flexible stainless steel pipe");
                    cmbSeleccionado.Items.Add("Cylinder Thermostat and timelock ");

                    elegidos.Add("Solar expansion vessel");
                    elegidos.Add("Solar pump station");
                    elegidos.Add("Solar safety valve discharge vessel ");
                    elegidos.Add("Solar drain-off");
                    elegidos.Add("Pre insulated flexible stainless steel pipe");
                    elegidos.Add("Cylinder Thermostat and timelock ");
                }
            }
            catch (ArgumentOutOfRangeException ex) {

                MessageBox.Show("Se tiene que seleccionar una opción");

            }

        }
    }
}
