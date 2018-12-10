using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Media;

namespace WQAS
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Home
    {
        #region Methods
        public Home()
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
        private void GitHubButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Process.Start(ConfigurationManager.AppSettings["GitHub"]);
        }

        private void TwitterButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Process.Start("https://twitter.com/pransmarclou");
        }

        private void ChatButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Process.Start("https://gitter.im/ButchersBoy/MaterialDesignInXamlToolkit");
        }

        private void EmailButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Process.Start("mailto://WQAS@gmail.com");
        }

        private void DonateButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Process.Start("https://pledgie.com/campaigns/31029");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Global.ControlState = "Read";

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();


        }

        #endregion

    }
}