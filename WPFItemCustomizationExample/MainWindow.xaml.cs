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

namespace WPFItemCustomizationExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //store texture image names in array so we can refer to them easily 
        private string[] images = new string[] { "scales.png", "tough-skin.png", "soft-skin.png", "fur.png" };

        //create a solid brush color that we can change depending on player selection
        SolidColorBrush color = new SolidColorBrush(); 
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Texture_Checked(object sender, RoutedEventArgs e)
        {
            // which button was clicked?
            var button = sender as RadioButton;

            //what to do with selection?
            switch(button.Content.ToString())
            {
                case "Scales":
                    Preview.Source = new BitmapImage(new Uri(images[0], UriKind.Relative));
                    Companion.Texture = "scales";
                    break;


                case "Tough Skin":
                    Preview.Source = new BitmapImage(new Uri(images[1], UriKind.Relative));
                    Companion.Texture = "tough skin";
                    break;

                case "Soft Skin":
                    Preview.Source = new BitmapImage(new Uri(images[2], UriKind.Relative));
                    Companion.Texture = "soft skin";
                    break;

                case "Fur":
                    Preview.Source = new BitmapImage(new Uri(images[3], UriKind.Relative));
                    Companion.Texture = "fur";
                    break;
            }
            UpdateSummary();
        }

        private void Color_Checked(object sender, RoutedEventArgs e)
        {
            // which button was clicked?
            var button = sender as RadioButton;

            //what to do with selection?
            switch (button.Content.ToString())
            {
                case "Beige":
                    Companion.Color = "beige";
                    color.Color = Color.FromArgb(50, 187, 161, 43);
                    ColorOverlay.Fill = color;
                    break;


                case "Green":
                    Companion.Color = "green";
                    color.Color = Color.FromArgb(50, 82, 187, 43);
                    ColorOverlay.Fill = color;
                    break;

                case "Blue":
                    Companion.Color = "blue";
                    color.Color = Color.FromArgb(50, 43, 102, 187);
                    ColorOverlay.Fill = color;
                    break;

                case "Purple":
                    Companion.Color = "purple";
                    color.Color = Color.FromArgb(50, 43, 43, 187);
                    ColorOverlay.Fill = color;
                    break;
            }
            UpdateSummary();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //temporary error message....
            MessageBox.Show("Game hasn't been built yet, but you would be playing with a companion who has " + Companion.Color + " " + Companion.Texture + " and is named " + Companion.Name + ".");
        }

        private void CustomizationExampleWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Preview.Source = new BitmapImage(new Uri(images[0], UriKind.Relative));
            color.Color = Color.FromArgb(50, 43, 43, 187);
            ColorOverlay.Fill = color;
            this.Title = "Your companion has purple scales and is named Friend.";
        }

        private void UpdateSummary()
            {
            this.Title = "Your companion has " + Companion.Color + " " + Companion.Texture + " and is named " + Companion.Name + ".";
            
        }

        private void inName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Companion.Name = inName.Text;
            UpdateSummary();
        }

    }
}
