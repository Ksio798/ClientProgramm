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

namespace Client
{  
    public partial class MainWindow : Window
    {
        MainController mainControler;
        public MainWindow()
        {
            InitializeComponent();
            mainControler = new MainController();
            button3.Click += mainControler.OnButtonPush;                 
        }
       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mainControler.SetHostByName(text.Text);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mainControler.ClearHost();
            text.Text = "";
        }
    }
}
