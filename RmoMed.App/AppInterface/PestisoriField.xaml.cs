using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using RmoMed.App.AppInterface.PestisoriCm;
using RmoMed.App.Helper;
using RmoMed.AppLogic.Interfaces;

namespace RmoMed.App.AppInterface
{
    /// <summary>
    /// Interaction logic for Pestisori.xaml
    /// </summary>
    /// pestisori nivele timp timer
    public partial class PestisoriField : Window
    {
        GameLvLs lvls = new GameLvLs();
        private readonly IGameInterface _gameInterfaceAL;
        static DispatcherTimer _timer;
        static int _timeToLive = 10;
        int _countLogic = 5;
        int _countScore = 0;
        int _cicleCount = 0;
        bool _stateAction = false;

        double dWidth = -1;
        double dHeight = -1;
        Thickness pos;

        public PestisoriField()
        {
            var applicationLogic = new AppLogic.ApplicationLogic();
            _gameInterfaceAL = applicationLogic.GetGameInterfaceAL();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FrameworkElement pnlClient = this.Content as FrameworkElement;
            if (pnlClient != null)
            {
                dWidth = pnlClient.ActualWidth;
                dHeight = pnlClient.ActualHeight;
            }

            Start();
        }

        private void Start()
        {
            RunTimer();
            RunGameLogic();
        }

        private void RunTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            _timer.Start();
        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_cicleCount > 2)
            {
                Close();
            }

            var curentTime = _timeToLive--;
            if (curentTime == 0)
            {
                GmInteract.Children.Clear();
                RunGameLogic();
            }

            TimerCountDown.Dispatcher.Invoke(new Action(() =>
            {
                TimerCountDown.Content = curentTime.ToString("D2");
            }));
        }

        private void RunGameLogic()
        {
            if (_cicleCount == 0)
            {
                _timeToLive = 6;
            }

            if (_cicleCount == 1)
            {
                _timeToLive = 4;
            }

            if (_cicleCount == 2)
            {
                _timeToLive = 2;
            }

            double height;
            var width = height = GetLvl(_stateAction);
            _stateAction = false;

            lbScore.Content = _countScore.ToString("D2");

            var t1 = new PestisorT1(width, height);
            var position = _gameInterfaceAL.GetRandomPosition(165, 165, dWidth, dHeight);
            t1.Margin = position;
            findPestisor.Source = LoadBitmapFromResource(t1.lbCurentPestisor.Content.ToString());

            GmInteract.Children.Add(t1);
        }

        private void GmInteract_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _stateAction = true;
            GmInteract.Children.Clear();
            RunGameLogic();
        }

        private int GetLvl(bool state)
        {
            if (!lvls.LvL1)
            {
                if (_countLogic == 0)
                {
                    lvls.LvL1 = true;
                    lvls.LvL2 = true;

                    _countLogic = 5;
                }
                else
                {
                    if (state)
                    {
                        _countScore += 1;
                    }

                    _countLogic--;
                }


                return 165;
            }

            if (lvls.LvL2)
            {
                if (_countLogic == 0)
                {
                    lvls.LvL3 = true;
                    lvls.LvL2 = false;

                    _countLogic = 5;
                }
                else
                {
                    if (state)
                    {
                        _countScore += 3;
                    }

                    _countLogic--;
                }

                return 135;
            }

            if (lvls.LvL3)
            {
                if (_countLogic == 0)
                {
                    lvls.LvL4 = true;
                    lvls.LvL3 = false;

                    _countLogic = 5;
                }
                else
                {
                    if (state)
                    {
                        _countScore += 5;
                    }

                    _countLogic--;
                }

                return 105;
            }

            if (lvls.LvL4)
            {
                if (_countLogic == 0)
                {
                    lvls.LvL5 = true;
                    lvls.LvL4 = false;

                    _countLogic = 5;
                }
                else
                {
                    if (state)
                    {
                        _countScore += 7;
                    }

                    _countLogic--;
                }

                return 85;
            }

            if (lvls.LvL5)
            {
                if (_countLogic == 0)
                {
                    lvls.LvL1 = false;
                    lvls.LvL5 = false;

                    _countLogic = 5;
                    _cicleCount++;
                }
                else
                {
                    if (state)
                    {
                        _countScore += 10;
                    }

                    _countLogic--;
                }

                return 65;
            }

            return 0;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Globals.TotalScore = _countScore;
        }
    }
}
