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

namespace WQAS
{
    /// <summary>
    /// Interaction logic for Assess.xaml
    /// </summary>
    public partial class Read : UserControl
    {
        public Read()
        {
            InitializeComponent();
        }
        #region Attributes

        Arduino _arduino = new Arduino();
        private bool connectionState;
        string measuredValue;

        #endregion Attributes

        private void btnReadTemperature_Click(object sender, RoutedEventArgs e)
        {

            _arduino.Connection_Open();
            _arduino.Write("1");
            _arduino.Read();
            measuredValue = _arduino.ReadValue;
            this.txtTemperature.Text = _arduino.ReadValue;
            this.txtMeasuredValue.Text = measuredValue + " °";
            _arduino.Connection_Close();

            
        }

        private void btnReadTurbidity_Click(object sender, RoutedEventArgs e)
        {
            _arduino.Connection_Open();
            _arduino.Write("2");
            _arduino.Read();
            measuredValue = _arduino.ReadValue;
            this.txtTurbidity.Text = _arduino.ReadValue;
            this.txtMeasuredValue.Text = measuredValue + " NTU";
            _arduino.Connection_Close();         
        }

        private void btnReadPh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReadEC_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
