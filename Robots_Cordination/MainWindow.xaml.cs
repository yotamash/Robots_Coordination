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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Robots_Cordination
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string numberOfRobotsS = "";
        string keySizeS = "";
        int keySize;
        int numberOfRobots;
        Satellite satellite;
        public MainWindow()
        {
            InitializeComponent();
            ProgressBar progbar = new ProgressBar();
            progbar.IsIndeterminate = false;
            progbar.Orientation = Orientation.Horizontal;
            progbar.Width = 150;
            progbar.Height = 15;
            Duration duration = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation doubleanimation = new DoubleAnimation(100.0, duration);
            progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }

        private void NumberOfRobots_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null)
            {
                numberOfRobotsS = textBox.Text;
            }
        }

        private void KeySize_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null)
            {
                keySizeS = textBox.Text;
            }
        }

        private void Run_OnClick(object sender, RoutedEventArgs e)
        {
            var res = Int32.TryParse(numberOfRobotsS, out numberOfRobots);
            if (res == false || numberOfRobots <= 0)
            {
                throw new Exception("Wrong Number Of Robots");
            }
            res = Int32.TryParse(keySizeS, out keySize);
            if (res == false || keySize <= 0)
            {
                throw new Exception("Wrong Key Size");
            }

            satellite = new Satellite(numberOfRobots, keySize);
            // Old Method
            satellite.CalculateKeyOldMethod();
            satellite.UpdateNumOperationOld(OldTotalTime);
            satellite.UpdateNumBitsFoundOld(OldBitsFound);

            // New Method
            satellite.CalculateKeyNewMethod();
            satellite.UpdateNumOperationNew(NewTotalTime);
            satellite.UpdateNumBitsFoundNew(NewBitsFound);

        }

        private void OldTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KeyFound_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NewTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void New_KeyFound_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
