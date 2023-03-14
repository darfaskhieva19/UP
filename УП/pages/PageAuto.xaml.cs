﻿using System;
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

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        Users users;
        DispatcherTimer timer = new DispatcherTimer();
        int time = 10;
        string code;
        string str = String.Empty;

        public PageAuto()
        {
            InitializeComponent();
            tbNumber.Focus();
        }
       
        private void btnOtm_Click(object sender, RoutedEventArgs e) //кнопка отмены
        {
            tbNumber.Text = "";
            tbpass.Password = "";
            tbCode.Text = "";
            tbpass.IsEnabled = false;
            tbCode.IsEnabled = false;
        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if(tbCode.Text == code)
            {
                timer.Stop();
                tbTime.Text = "";
                MessageBox.Show($"Вы успешно авторизовались! Ваша роль - {users.Roles.Role}");
            }
            else
            {
                timer.Stop();
                tbTime.Text = "";
                MessageBox.Show("Неверный код!");
                tbCode.Text = "";
                btnUpCode.IsEnabled = false;
                btnEnter.IsEnabled = false;
                tbCode.IsEnabled = false;
            }
        }
        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Users user = DataBase.Base.Users.FirstOrDefault(z => z.Number == tbNumber.Text);
                if (user != null)
                {
                    tbpass.IsEnabled = true;
                    tbpass.Focus();
                }
                else
                {
                    tbpass.IsEnabled = false;
                    MessageBox.Show("Нет такого номера!");
                }
            }
        }
        private void tbpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int pp = tbpass.Password.GetHashCode();
                Users users = DataBase.Base.Users.FirstOrDefault(z => z.Password == pp);
                if (users != null)
                {
                    tbCode.IsEnabled = true;
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Tick += new EventHandler(Timer_Tick);
                    Time();
                }
                else
                {
                    MessageBox.Show("Введенный пароль неверный!");
                }
            }
        }

        public void Time() //запуск таймера и генерация
        {
            string kod = GenerateCode();
            MessageBox.Show(kod + "\nЗапомните пожалуйста код", "Код");
            tbCode.Focus();
            time = 10;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tbTime.Text = "Осталось " + time + " секунд";
            if (time == 0)
            {
                timer.Stop();
                tbTime.Text = "";
                MessageBox.Show("Вы не успели ввести код.Сгенирируйте код заново!");
                tbCode.Text = "";
                btnUpCode.IsEnabled = true;
                btnEnter.IsEnabled = false;
                tbCode.IsEnabled = false;
            }           
        }

        private void tbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e) //запрет на символы
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void btnUpCode_Click(object sender, RoutedEventArgs e)
        {
            Time();
            btnUpCode.IsEnabled = false;
            tbCode.IsEnabled = true;
        }

        public string GenerateCode()
        {
            string str = string.Empty;
            code = "";
            Random rnd = new Random();
            string sym = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";      
            string sps = "!#$()*+,-./;<=>?@[]^_{|/}";
            for (int i = 0; str.Length < 8; i++)
            {
                str += sym[rnd.Next(sym.Length)];                
            }
            return str;
        }

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnEnter.IsEnabled = true;
        }

        private void tbCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tbCode.Text == code)
                {
                    timer.Stop();
                    tbTime.Text = "";
                    MessageBox.Show($"Вы успешно авторизовались! Ваша роль - {users.Roles.Role}");
                }
                else
                {
                    timer.Stop();
                    tbTime.Text = "";
                    MessageBox.Show("Неверный код!");
                    tbCode.Text = "";
                    btnUpCode.IsEnabled = false;
                    btnEnter.IsEnabled = false;
                    tbCode.IsEnabled = false;
                }
            }
        }
    }
}
