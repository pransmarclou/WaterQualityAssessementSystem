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
using System.Configuration;
using System.Data.SqlClient;

namespace WQAS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Methods
        public MainWindow()
        {
            
            InitializeComponent();

            InitializeUserControl();          
        }

        public void InitializeButtons()
        {
                this.btnHome.IsEnabled = true;
                this.btnSample.IsEnabled = true;
                this.btnAssess.IsEnabled = true;
                this.btnRead.IsEnabled = true;
                this.btnReadReport.IsEnabled = true;
  
        }

        private void InitializeUserControl()
        {


            if (Global.ControlState == "Home")
            {
                this.lstDockLeft.SelectedIndex = 0;
                cntControl.Content = new Home();
                this.MenuToggleButton.Visibility = Visibility.Visible;

                this.btnHome.IsEnabled = false;
                this.btnSample.IsEnabled = true;
                this.btnAssess.IsEnabled = true;
                this.btnRead.IsEnabled = true;
                this.btnReadReport.IsEnabled = true;

                this.txbTitle.Text = "Home";
            }
            else if (Global.ControlState == "Read")
            {
                cntControl.Content = new Read();
                this.txbTitle.Text = "Read";
                this.MenuToggleButton.Visibility = Visibility.Hidden;

                this.btnHome.IsEnabled = false;
                this.btnSample.IsEnabled = false;
                this.btnAssess.IsEnabled = false;
                this.btnRead.IsEnabled = false;
                this.btnReadReport.IsEnabled = false;
            }
        }
        #endregion

        #region Buttons
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            InitializeButtons();
            this.lstDockLeft.SelectedIndex = 0;
            cntControl.Content = new Home();
            this.btnHome.IsEnabled = false;
            this.txbTitle.Text = "Home";
        }

        private void btnSample_Click(object sender, RoutedEventArgs e)
        {
            InitializeButtons();
            cntControl.Content = new Sample();
            this.lstDockLeft.SelectedIndex = 1;
            this.btnSample.IsEnabled = false;
            this.txbTitle.Text = "Sample";
        }
        private void btnAssess_Click(object sender, RoutedEventArgs e)
        {
            InitializeButtons();
            cntControl.Content = new Assess();
            this.lstDockLeft.SelectedIndex = 2;
            this.btnAssess.IsEnabled = false;
            this.txbTitle.Text = "Assess Watter";
        }
      
        

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            InitializeButtons();
            cntControl.Content = new Read();
            this.lstDockLeft.SelectedIndex = 3;
            this.btnRead.IsEnabled = false;
            this.txbTitle.Text = "Measure Physicochemical Parameters of Water";
        }
        private void btnReadReport_Click(object sender, RoutedEventArgs e)
        {
            InitializeButtons();
            //cntControl.Content = new SalesReport();
            this.lstDockLeft.SelectedIndex = 4;
            this.btnReadReport.IsEnabled = false;
            this.txbTitle.Text = "Sales Report";
        }



        #endregion

    }
}
