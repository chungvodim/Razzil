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

namespace Razzil.StepsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.NotificationTextBox.Drop += NotificationTextBox_Drop;
            this.NotificationTextBox.DragEnter += NotificationTextBox_DragEnter;
            this.NotificationTextBox.DragOver += NotificationTextBox_DragOver;
            this.NotificationTextBox.DragLeave += NotificationTextBox_DragLeave;
        }

        void NotificationTextBox_DragLeave(object sender, DragEventArgs e)
        {
            this.NotificationTextBox.Text = "heheehe";
        }

        void NotificationTextBox_DragOver(object sender, DragEventArgs e)
        {
            this.NotificationTextBox.Text = "heheehe";
        }

        void NotificationTextBox_DragEnter(object sender, DragEventArgs e)
        {
            this.NotificationTextBox.Text = "heheehe";
        }

        void NotificationTextBox_Drop(object sender, DragEventArgs e)
        {
            this.NotificationTextBox.Text = "";
        }

    }
}
