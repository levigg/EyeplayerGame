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

using EyeXFramework;
using Tobii.EyeX.Framework;
using System.Windows.Threading;
using EyeXFramework.Wpf;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;

namespace EyePlayerGame
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string state = "chooseGame";

        double screenHeight = SystemParameters.PrimaryScreenHeight;
        double screenWidth = SystemParameters.PrimaryScreenWidth;

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;


        DispatcherTimer dt;
        public readonly WpfEyeXHost eHost = new WpfEyeXHost();

        public MainWindow()
        {
            InitializeComponent();

            eHost.Start();

            dt = new DispatcherTimer();
            dt.Tick += PlayEyeGame;
            dt.Interval = new TimeSpan(1000 * 250);
            dt.Start();
            
            StartEyeTrack();
        }

        public void StartEyeTrack()
        {
            GazePointDataStream gpda = eHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            gpda.Next += new EventHandler<GazePointEventArgs>(GetPos);
        }

        List<Point> posList = new List<Point>();

        private void GetPos(object sender, GazePointEventArgs e)
        {
            if (e.X > 0 && e.Y > 0)
            {
                Point eyePoint = new Point(e.X, e.Y);
                posList.Add(eyePoint);
            }
        }

        double smoothPosX = 0;
        double smoothPosY = 0;
        double newSmoothPosX;
        double newSmoothPosY;
        double posListAllX;
        double posListAllY;

        private void Smooth()
        {
            Console.WriteLine(posList.Count);

            for (int i = 0; i < posList.Count; i++)
            {
                //Console.WriteLine(posList[i].X + ", " + posList[i].Y);
                posListAllX += posList[i].X;
                posListAllY += posList[i].Y;
            }
            //Console.WriteLine(posX + ", "+ posY);

            newSmoothPosX = posListAllX / posList.Count;
            newSmoothPosY = posListAllY / posList.Count;

            if (((newSmoothPosX - smoothPosX) > 30 || (smoothPosX - newSmoothPosX) > 30) && ((newSmoothPosY - smoothPosY) > 30 || (smoothPosY - newSmoothPosY) > 30))
            {
                smoothPosX = newSmoothPosX;
                smoothPosY = newSmoothPosY;
            }
            Console.WriteLine(newSmoothPosX + ", " + newSmoothPosY);
            posListAllX = 0;
            posListAllY = 0;
            posList.Clear();

        }

        DateTime clickAvoidTime;
        Boolean clickAvoidTimeStore = false;
        Boolean eyeControl = true;

        private void PlayEyeGame(object sender, EventArgs e)
        {
            if (state == "playEyeGame")
            {
                Smooth();
                if (eyeControl == true)
                    SetCursorPos((int)smoothPosX, (int)smoothPosY);

                if (clickAvoidTimeStore == false)
                {
                    clickAvoidTime = DateTime.Now;
                    clickAvoidTimeStore = true;
                }


                if ((DateTime.Now - clickAvoidTime).TotalSeconds > 5)
                {
                    SetCursorPos(1, 1);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
                    Thread.Sleep(10);
                    mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
                    //SetCursorPos((int)screenWidth/2, (int)screenHeight/2);
                    clickAvoidTimeStore = false;
                }
            }

            //DataClasses1DataContext DB = new DataClasses1DataContext("data");

            ////讀取表格  
            //Console.WriteLine("讀取表格");
            //var Result = from p in DB.data select p;
            //Console.WriteLine("uid\tname\tage");
            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item.uid + "\t" + item.name + "\t" + item.agr);
            //}

            ////讀取指定資料  
            //Console.WriteLine("讀取指定資料 #1");
            //var selectone = from p in DB.tbl_users where p.uid == 3 select p.name;
            //foreach (var item in selectone)
            //{
            //    Console.WriteLine("uid 3 user name is " + item);
            //}

            ////another way  
            //Console.WriteLine("讀取指定資料 #2");
            //tbl_user t_user = DB.tbl_users.Single(p => p.uid == 3);
            //Console.WriteLine("uid 3 user name is " + t_user.name);

            //Console.ReadLine();
        }

        private void KeyFunctions(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (state == "chooseGame") this.Close();
                if (state == "playEyeGame")
                {
                    state = "chooseGame";
                    GameList.Visibility = Visibility.Visible;

                    Process[] chromeInstances = Process.GetProcessesByName("chrome");
                    foreach (Process p in chromeInstances)
                    {
                        p.CloseMainWindow();
                    }
                }
            }

            if (e.Key == Key.Enter)
            {
                eyeControl = true;
            }

        }

        private void Image01_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://tobii-dynavox-christmas-games.com/sensory-game/sensory-game.html#1");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            avoidClick.Visibility = Visibility.Visible;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image02_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://koalastothemax.com/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image03_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://tobii-dynavox-christmas-games.com/catchme/catchme.html#1");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image04_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://www.jacksonpollock.org/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image05_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://img0.liveinternet.ru/images/attach/c/5/3970/3970473_sprite198.swf");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image06_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://www.owlieboo.com/games-for-toddlers/games-for-toddlers-nocturnal/games-for-toddlers.php");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image07_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://www.staggeringbeauty.com/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image08_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://flashcanvas.net/examples/www.chiptune.com/starfield/starfield.html");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image09_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://weavesilk.com/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image10_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://open.adaptedstudio.com/html5/many-lines/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image11_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            //System.Diagnostics.Process.Start("https://musiclab.chromeexperiments.com/Melody-Maker");

            eyeControl = false;
            Process.Start(@"C:\Program Files\Sensory Software\Look to Learn\LookToLearn.exe");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
            
        }
        private void Image12_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("https://musiclab.chromeexperiments.com/Harmonics");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image13_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://www.barcinski-jeanjean.com/entries/line3d/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image14_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://slither.io/");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image15_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("https://musiclab.chromeexperiments.com/Strings");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }
        private void Image16_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            state = "playEyeGame";
            System.Diagnostics.Process.Start("http://tobii-dynavox-christmas-games.com/memory-game/memory-game.html#1");
            Thread.Sleep(1000);
            GameList.Visibility = Visibility.Hidden;
            SetCursorPos(1, 1);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 1, 1, 0, 0);
            Thread.Sleep(10);
            mouse_event(MOUSEEVENTF_LEFTUP, 1, 1, 0, 0);
        }


    }
}
