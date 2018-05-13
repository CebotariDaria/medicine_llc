using RmoMed.AppLogic.Interfaces;
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
using RmoMed.App.AppInterface;
using RmoMed.App.BaseClass;
using RmoMed.App.Helper;

namespace RmoMed.App
{
    public partial class Main : Window
    {
        private readonly IMainInterface _mainInterfaceAL;

        public Main()
        {
            var applicationLogic = new AppLogic.ApplicationLogic();
            _mainInterfaceAL = applicationLogic.GetMainInterfaceAL();

            InitializeComponent();
            InitViewBoard();
        }

        private void InitViewBoard()
        {
            PAuth.OnNameSend += PAuth_onNameSend;
        }

        private void PAuth_onNameSend(string name)
        {
            var status = _mainInterfaceAL.ValidateUser(name);
            if (status)
            {
                MainAction.Visibility = Visibility.Collapsed;
                GameGrid.Visibility = Visibility.Visible;
            }

        }

        private Storyboard _storyboard = new Storyboard();
        const bool ToLeft = false;
        const bool ToRight = true;
        void ScreenSelector(FrameworkElement currentElement, FrameworkElement toNextElement, bool side)
        {
            _storyboard?.Begin(this, true);
            var ticknessLeft = new Thickness(Width, 0, -Width, 0);
            var ticknessRight = new Thickness(-Width, 0, Width, 0);
            var ticknessClient = new Thickness(0, 0, 0, 0);

            var timeSpanStarting = TimeSpan.FromSeconds(0);
            var timeSpanStopping = TimeSpan.FromSeconds(0.5);

            var keyTimeStarting = KeyTime.FromTimeSpan(timeSpanStarting);
            var keyTimeStopping = KeyTime.FromTimeSpan(timeSpanStopping);

            toNextElement.Margin = side ? ticknessRight : ticknessLeft;
            toNextElement.Visibility = Visibility.Visible;

            var storyboardTemp = new Storyboard();

            var currentThicknessAnimationUsingKeyFrames = new ThicknessAnimationUsingKeyFrames { BeginTime = timeSpanStarting };

            Storyboard.SetTargetName(currentThicknessAnimationUsingKeyFrames, currentElement.Name);
            Storyboard.SetTargetProperty(currentThicknessAnimationUsingKeyFrames, new PropertyPath("(FrameworkElement.Margin)"));
            currentThicknessAnimationUsingKeyFrames.KeyFrames.Add(new SplineThicknessKeyFrame(ticknessClient, keyTimeStarting));
            currentThicknessAnimationUsingKeyFrames.KeyFrames.Add(new SplineThicknessKeyFrame(side ? ticknessLeft : ticknessRight, keyTimeStopping));

            storyboardTemp.Children.Add(currentThicknessAnimationUsingKeyFrames);

            var nextThicknessAnimationUsingKeyFrames = new ThicknessAnimationUsingKeyFrames { BeginTime = timeSpanStarting };

            Storyboard.SetTargetName(nextThicknessAnimationUsingKeyFrames, toNextElement.Name);
            Storyboard.SetTargetProperty(nextThicknessAnimationUsingKeyFrames, new PropertyPath("(FrameworkElement.Margin)"));
            nextThicknessAnimationUsingKeyFrames.KeyFrames.Add(new SplineThicknessKeyFrame(side ? ticknessRight : ticknessLeft, keyTimeStarting));
            nextThicknessAnimationUsingKeyFrames.KeyFrames.Add(new SplineThicknessKeyFrame(ticknessClient, keyTimeStopping));

            storyboardTemp.Children.Add(nextThicknessAnimationUsingKeyFrames);

            storyboardTemp.Completed += (EventHandler)delegate
            {
                currentElement.Visibility = Visibility.Hidden;
                _storyboard = null;
            };

            _storyboard = storyboardTemp;
            BeginStoryboard(storyboardTemp);
        }
        //butoane Regulile exersarii
        private void Layer_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GamesRules, GameGrid, false);
        }

        private void label2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GameGrid, GamesRules, true);
        }
        //butoane Statistica
        private void label3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GameGrid, GamesStatistics, true);

        }
        private void Layer_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GamesStatistics, GameGrid, false);
        }
        //butoane Ajutor
        private void label4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GameGrid, GamesHelp, true);
            GamesHelp.Visibility=Visibility.Visible;
        }
        private void Layer_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GamesHelp, GameGrid, false);
            GamesHelp.Visibility = Visibility.Hidden;
        }

        //butoane Exerseaza
        private void label1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pm = new PestisoriField();
            pm.Closed += Pm_Closed;
            pm.Show();
        }

        private void Pm_Closed(object sender, EventArgs e)
        {
            lbScore.Content = Globals.TotalScore.ToString("D4");
            ScreenSelector(GameGrid, GamesInterfaces, true);
            GamesInterfaces.Visibility = Visibility.Visible;
        }

        private void Layer_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ScreenSelector(GamesInterfaces, GameGrid, false);
            GamesInterfaces.Visibility = Visibility.Hidden;
        }

        private void btPestisori_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }   
}
