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

        public PageAuto()
        {
            InitializeComponent();
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
            
        }
        private void tbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (DataBase.Base.Employees.FirstOrDefault(z => z.Number == tbNumber.Text) != null)
                {
                    employee = DataBase.Base.Employees.FirstOrDefault(z => z.Number == tbNumber.Text);
                    tbpass.IsEnabled = true;
                    tbpass.Focus();
                }
                else
                {
                    MessageBox.Show("Нет такого номера!");
                }
            }
        }
        private void tbpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (employee.Password == tbpass.Password.GetHashCode())
                {                    
                    tbCode.IsEnabled = true;
                    timer.Interval = new TimeSpan(0, 0, 10);
                    timer.Tick += new EventHandler(Timer_Tick);
                    tbCode.Focus();                    
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }

            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tbTime.Text = "Осталось " + time.ToString() + " секунд";
            if (time == 0)
            {
                timer.Stop();
                tbTime.Text = "";
                MessageBox.Show("Вы не успели ввести код.Сгенирируйте заново");
                tbCode.Text = "";
                btnUpCode.IsEnabled = true;
            }
            tbCode.IsEnabled = false;
            btnEnter.IsEnabled = false;
        }

        private void tbNumber_PreviewTextInput(object sender, TextCompositionEventArgs e) //запрет на символы
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void tbCode_PreviewTextInput(object sender, TextCompositionEventArgs e) //запрет на символы
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }
        }

        private void btnUpCode_Click(object sender, RoutedEventArgs e)
        {
            //Random rnd = new Random();
            //int count = rnd.Next(10000, 50000);
            //string str = "";
            //string sym = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //string sp = "!#$()*+,-./;<=>?@[]^_{|}";
            //for(int i=0; str.Length < 8; i++)
            //{
            //    str += sym[rnd.Next(sym.Length)] + sp[rnd.Next(sp.Length)];
            //}
            //MessageBox.Show(str + "\nЗапомните пожалуйста код", "Код");

        }
    }
}
