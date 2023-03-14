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

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        Employees employee;
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
                MessageBox.Show($"Вы успешно авторизовались! Ваша роль - {employee.Roles.Role}");
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
                Employees employees = DataBase.Base.Employees.FirstOrDefault(z => z.Number == tbNumber.Text);
                if (employees != null)
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
                Employees employees = DataBase.Base.Employees.FirstOrDefault(z => z.Password == pp);
                if (employee != null)
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

        public void Time()
        {
            string code = GenerateCode();
            MessageBox.Show(code);
            tbCode.Focus();
            time = 10;
            timer.Start();
            tbTime.Text = "10 секунд";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tbTime.Text = "Осталось " + time.ToString() + " секунд";
            if (time == 0)
            {
                timer.Stop();
                tbTime.Text = "";
                MessageBox.Show("Вы не успели ввести код.Сгенирируйте код заново!");
                tbCode.Text = "";
                btnUpCode.IsEnabled = true;
                tbCode.IsEnabled = false;
                btnEnter.IsEnabled = false;
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
            btnUpCode.IsEnabled = false;
            tbCode.IsEnabled = true;
            Time();
        }

        public string GenerateCode()
        {
            code = "";
            str = string.Empty;
            Random rnd = new Random();
            string sym = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$()*+,-./;<=>?@[]^_{|}";           
            for(int i = 0; i < 8; i++)
            {
                str += sym[rnd.Next(sym.Length)];
            }
            return str;
            MessageBox.Show(str + "\nЗапомните пожалуйста код", "Код");
        }
    }
}
