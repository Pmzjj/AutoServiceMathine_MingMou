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
using System.Windows.Threading;

namespace AutoServiceMathine
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        DispatcherTimer Timer = new DispatcherTimer();
        int s = DateTime.Now.Second;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ScaneTime();

            MouseDown += delegate { Click(sender, e); };

            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            s += 1;
            if (s == 60)
            {
                ScaneTime();
                s = 0;
            }
        }

        private void ScaneTime()
        {
            textBox.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            string time = DateTime.Now.DayOfWeek.ToString();

            switch (time)
            {
                case "Monday":
                    time = "星期一";
                    break;
                case "Tuesday":
                    time = "星期二";
                    break;
                case "Wednesday":
                    time = "星期三";
                    break;
                case "Thursday":
                    time = "星期四";
                    break;
                case "Friday":
                    time = "星期五";
                    break;
                case "Saturday":
                    time = "星期六";
                    break;
                default:
                    time = "星期天";
                    break;
            }
            textBox1.Text = time;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Point p = Mouse.GetPosition(this);
            double x = p.X;
            double y = p.Y;

            MessageBox.Show(x.ToString(), y.ToString());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 过夜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ReadIDCard();
        }
        /// <summary>
        /// 订单入住
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ReadIDCard();

            QueryOrder();
        }
        /// <summary>
        /// 钟点房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ReadIDCard();
        }
        /// <summary>
        /// 续房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ReadIDCard();
        }
        /// <summary>
        /// 证件补录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ReadIDCard();
        }
        /// <summary>
        /// 退房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ReadIDCard();
        }
        /// <summary>
        /// 读取身份证
        /// </summary>
        private void ReadIDCard()
        {
            Window1 w = new Window1();
            w.ShowDialog();
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        private void QueryOrder()
        {
            Window2 w = new Window2();
            w.ShowDialog();
        }
    }
}
