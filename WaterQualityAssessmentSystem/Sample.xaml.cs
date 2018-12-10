using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WQAS
{
    /// <summary>
    /// Interaction logic for Sample.xaml
    /// </summary>
    public partial class Sample
    {
        #region Attributes

        Arduino _arduino = new Arduino();

        private byte btnState = 0;
        private bool connectionState;
      

        #endregion Attributes

        #region Methods

        public Sample()
        {
            InitializeComponent();
          
        }

        private void InitializeMaterialDesign()
        {
            // Create dummy objects to force the MaterialDesign assemblies to be loaded
            // from this assembly, which causes the MaterialDesign assemblies to be searched
            // relative to this assembly's path. Otherwise, the MaterialDesign assemblies
            // are searched relative to Eclipse's path, so they're not found.
            var card = new Card();
            var hue = new Hue("Dummy", Colors.Black, Colors.White);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
            if (regex.IsMatch(e.Text))
                SystemSounds.Beep.Play();
        }

        #endregion

        #region Buttons

        private void btnSample_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connectionState == true)
                {
                    if (btnState == 0)
                    {
                        _arduino.Write("1");
                        txtLEDStatus.Text = "LED is now ON";
                        //Thread.Sleep(10000);
                        _arduino.Read();
                        this.txtTemp.Text = _arduino.ReadValue;
                        btnState = 1;
                    }
                    else if (btnState == 1)
                    {
                        _arduino.Write("0");
                        txtLEDStatus.Text = "LED is now OFF";                       
                        btnState = 0;
                    }
                }
                else
                {
                    throw new Exception("Connect the Arduino to the System first.");
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void btnOpenConnection_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (connectionState != true)
                {
                    _arduino.Connection_Open();

                    if (_arduino.HasError == false)
                    {
                        this.connectionState = true;
                    }
                }
                
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Connection Error: ", "Sample", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }

        private void btnCloseConnection_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (connectionState == true)
                {
                    _arduino.Connection_Close();

                     if (_arduino.HasError == false)
                     {
                          this.connectionState = false;                          
                     }
                }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        #endregion Buttons


    }
}