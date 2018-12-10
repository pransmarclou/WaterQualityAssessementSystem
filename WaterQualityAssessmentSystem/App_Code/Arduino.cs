using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Data;
using System.Windows;

namespace WQAS
{
    class Arduino
    {
        #region Attributes
        private static SerialPort _serialPort;
        private string portName = "COM3";
        private int baudRate = 9600; //default "9600"
        private char[] trimChar = { 'r', '\\' };

        private string status;
        private bool hasError; // True = with error; False = no error
        private string readValue;
        #endregion

        #region Properties

        public bool HasError
        {
            get { return this.hasError; }
            set { this.hasError = value; }
        }

        public string Status
        {
            get {   return status; }
            set { status = value; }
        }

        public string ReadValue
        {
            get { return readValue; }
            set { readValue = value; }
        }
        #endregion

        #region Constructors

        public Arduino()
        {
            //OpenClose();
        }

        #endregion

        #region Methods

        //Open Serial Port Connection for Arduino
        public void Connection_Open()
        {
            try
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = portName;
                _serialPort.BaudRate = baudRate;
                _serialPort.Open();

                this.HasError = false;
                MessageBox.Show("Successfully Connected to Arduino!", "Arduino Connection", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                this.HasError = true;
                MessageBox.Show("Unable to Connect to Arduino!\nError: " + ex.Message, "Arduino Connection", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }

        //Close Serial Port Connection
        public void Connection_Close()
        {
            try
            {
                if (_serialPort != null)
                {
                    if (_serialPort.IsOpen == true)
                    {
                        _serialPort.Close();
                    }
                    _serialPort.Dispose();

                    _serialPort = null;
                }

                this.HasError = false;
                MessageBox.Show("Disconnected to Arduino!", "Arduino Connection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                this.HasError = true;
                MessageBox.Show("Unable to Disconnect to Arduino!\nError: " + ex.Message, "Arduino Connection", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
           
        }

        //Serial Write
        public void Write(string values)
        {
            try
            {
                //Check if there is a connection to Serial Port
                if (_serialPort.IsOpen == true)
                {
                    //Check if values is empty
                    if (string.IsNullOrWhiteSpace(values))
                    {
                        throw new Exception("No values to be written.");
                    }

                    //Write the Serial Value
                    _serialPort.Write(values);                  

                    this.HasError = false;
                    MessageBox.Show("Successfully Written!", "Arduino Write", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new Exception("The system is not connected to Arduino. Pls reconnect immediately.");
                }
            }
            catch (Exception ex)
            {
                this.HasError = true;
                MessageBox.Show("Unable to Write!\nError: " + ex.Message, "Arduino Write", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
           
        }

        //Serial Read
        public void Read()
        {
            string myString;

            try
            {
                 myString = _serialPort.ReadLine();
                //Check if there is a connection to Serial Port
                if (_serialPort.IsOpen == true)
                {


                    //Read the Serial Value
                    //ReadValue = _serialPort.ReadExisting();            
                    ReadValue = myString.Remove(myString.Length - 1);

                    //ReadValue = _serialPort.ReadLine().Replace('/', '\0');
                    //ReadValue = _serialPort.ReadLine().ToString();

                    this.HasError = false;
                    MessageBox.Show("Successfully Read!", "Arduino Read", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new Exception("The system is not connected to Arduino. Pls reconnect immediately.");
                }
            }
            catch (Exception ex)
            {
                this.HasError = true;
                MessageBox.Show("Unable to Write!\nError: " + ex.Message, "Arduino Write", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }

        }
        public void OpenClose()
        {
            Connection_Open();
            Connection_Close();
        }

        //Set-up the port of Arduino Automatically
        //private string AutodetectArduinoPort()
        //{
        //    ManagementScope connectionScope = new ManagementScope();
        //    SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
        //    ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

        //    try
        //    {
        //        foreach (ManagementObject item in searcher.Get())
        //        {
        //            string desc = item["Description"].ToString();
        //            string deviceId = item["DeviceID"].ToString();

        //            if (desc.Contains("Arduino"))
        //            {
        //                return deviceId;
        //            }
        //        }
        //    }
        //    catch (ManagementException e)
        //    {
        //        /* Do Nothing */
        //    }

        //    return null;
        //}
        #endregion
    }
}
