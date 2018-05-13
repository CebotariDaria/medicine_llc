using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace RmoMed.App.AppInterface.PestisoriCm
{
    /// <summary>
    /// Interaction logic for PestisorT1.xaml
    /// </summary>
    /// random pestisori micsorare
    public partial class PestisorT1 : UserControl
    {
        int _width;
        int _height;
        private readonly Random _random = new Random();
        string _curentPestisor;
        public PestisorT1(double width, double height)
        {
            _width = (int) width;
            _height = (int) height;

            InitializeComponent();
            ResizeElement();
        }

        private void ResizeElement()
        {
            var ss = CreateResizedImage(LoadBitmapFromResource(RandomImg()), _width, _height, 0);
            CurentPt.Source = ss;
            CurentPt.Width = _width;
            CurentPt.Height = _height;

            //CurentPt.Source = LoadBitmapFromResource("Image/P1.png");
        }

        private string RandomImg()
        {
            var names = new List<string> { "Image/P1.png", "Image/P2.png", "Image/P3.png", "Image/P4.png", "Image/P5.png",
                "Image/P6.png", "Image/P7.png", "Image/P8.png", "Image/P9.png", "Image/P10.png", "Image/P11.png", "Image/P12.png",
                "Image/P13.png", "Image/P14.png", "Image/P15.png", "Image/P16.png" };

            int index = _random.Next(names.Count);
            var name = names[index];
            names.RemoveAt(index);
            lbCurentPestisor.Content = name;

            return name;
        }

        private static BitmapImage LoadBitmapFromResource(string pathInApplication, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            if (pathInApplication[0] == '/')
            {
                pathInApplication = pathInApplication.Substring(1);
            }
            return new BitmapImage(new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute));
        }

        private static BitmapFrame CreateResizedImage(ImageSource source, int width, int height, int margin)
        {
            var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);

            var group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
            group.Children.Add(new ImageDrawing(source, rect));

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawDrawing(group);

            var resizedImage = new RenderTargetBitmap(
                width, height,         // Resized dimensions
                96, 96,                // Default DPI values
                PixelFormats.Default); // Default pixel format
            resizedImage.Render(drawingVisual);

            return BitmapFrame.Create(resizedImage);
        }
    }
}
