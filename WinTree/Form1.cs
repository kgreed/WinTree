using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.System;
using Microsoft.Toolkit.Forms.UI.XamlHost;
using Microsoft.Toolkit.Win32.UI.XamlHost;

namespace WinTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string str = "WinTreeWUP://";

            Uri uri = new Uri(str);

            //  var success = await Windows.System.Launcher.LaunchUriAsync(uri);
            var success = await Launcher.LaunchUriAsync(uri);
        }
        private void UseHelperMethod()
        {
            WindowsXamlHost myHostControl = new WindowsXamlHost();

            // Use helper method to create a UWP control instance.
            Windows.UI.Xaml.Controls.Button myButton =
                UWPTypeFactory.CreateXamlContentByType("Windows.UI.Xaml.Controls.Button")
                    as Windows.UI.Xaml.Controls.Button;

            // Initialize UWP control.
            myButton.Name = "button1";
            myButton.Width = 75;
            myButton.Height = 40;
            myButton.TabIndex = 0;
            myButton.Content = "button1";
            myButton.Click += MyButton_Click;

            // initialize the Windows XAML host control.
            myHostControl.Name = "myWindowsXamlHostControl";

            // Associate the Windows XAML host control with the UWP control.
            // For Windows Forms applications, you might use this.Controls.Add(myHostControl);
            myHostControl.Child = myButton;

            // Make the UWP control appear in the UI.
         //   this.MyStackPanel.Children.Add(myHostControl);
        }

        private void MyButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MessageBox.Show("My Button Worked");
        }
    }
}
