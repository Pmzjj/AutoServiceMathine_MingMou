using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using BasicInfo;

namespace AutoServiceMathine
{
    /// <summary>
    /// Window3.xaml 的交互逻辑
    /// </summary>
    public partial class Window3 : Window
    {
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);  //导入寻找windows窗体的方法
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);  //导入为windows窗体设置焦点的方法

        public Window3()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            flag = 0;

            BasicInfo.IdentifyMessage identify = new IdentifyMessage();
            identify.Mobile = txtPhone.Text;  //手机号码

            
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            flag = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MouseDown += delegate { Click(sender, e); };
            txtPhone.Focus();
        }

        private void Click(object sender,EventArgs e)
        {
            //foreach (UIElement u in grid.Children)
            //{ 
            //    if (u is Button)
            //    {
            //        Button bu = (u as Button);
            //        if (bu.Name.Contains("bn"))
            //        { 
                        
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 按下数字0~9后触发，根据控件名称将值输入到焦点处
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bu0_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string num = b.Name.ToString().Substring(2,1); //获取0~9的值

            WriteTxt(num);
        }
        /// <summary>
        /// 数据写入textbox中
        /// </summary>
        /// <param name="num"></param>
        private void WriteTxt(string num)
        {
            TextBox t = new TextBox();
            if (flag == 1)
                t = txtPhone;
            else if (flag == 2)
                t = txtIdentify;
            
            int i = t.SelectionStart; //获取焦点位置
            if (i != t.Text.Length && i != 0)
            {
                string qian = t.Text.Substring(0, i); //前段
                string hou = t.Text.Substring(i, t.Text.Length - i); //后段

                t.Text = qian + num + hou;
            }
            else if (i == 0)
                t.Text = num + t.Text;
            else
                t.Text += num;

            t.Focus();  //使控件获得焦点
            t.Select(i + 1, 0); //设置焦点位置
            t.ScrollToHorizontalOffset((double)i);  //回滚到焦点
        }

        int flag = 1;//焦点标记 1为手机号 2为验证码 0为其他
        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            flag = 1;
        }

        private void txtIdentify_GotFocus(object sender, RoutedEventArgs e)
        {
            flag = 2;
        }
    }
}
