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

namespace RmoMed.App.AppInterface
{
    /// <summary>
    /// Interaction logic for PAuth.xaml
    /// </summary>
    public partial class PAuth : Page
    {
        public PAuth()
        {
            InitializeComponent();
        }

        public delegate void SendName(string name);
        public static event SendName OnNameSend;

        private void btLogIn_Click(object sender, RoutedEventArgs e)
        {
            var name = tbAuthId.Text;
            OnNameSend?.Invoke(name);
        }
    }
}
