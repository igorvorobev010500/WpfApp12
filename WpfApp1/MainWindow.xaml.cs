using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string history(string text_b)
        {
            string path = @"C:\Users\Игорь\Desktop\c#\fff\WpfApp1\WpfApp1\history.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync(text_b);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line =  reader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        bool check_popularpas(string text_b)
        {
            string[] pop_pas = { "12345678", "qwertyui", "password123" };
            if (pop_pas.Contains(text_b)) { return true; } return false;
        }
        bool check_repeat (string text_b) /*поиск повторяющихся комбинаций символов*/
        {
            if(!Regex.IsMatch(text_b, @"(.)\1{1}")) {  return false; } return true;
        }
        bool check_difP(string text_b) /*используем регулярные выражения для поиска определённых символов в строке*/
        {
            if(!Regex.IsMatch(text_b, @"^[a-zA-Z]+$")) {  return false; } return true;
        }
        bool check_str(string text_b) /*проверка строки на обратное повторение*/
        {
            char[] stringArray = text_b.ToCharArray();
            Array.Reverse(stringArray);
            string revers = new string(stringArray);
            if (revers != text_b)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        bool check_simbol (string text_b) /*проверка на символы и тд*/
        {
            char[] simbols = "!@#$%^&*()|{}<>?".ToCharArray();
            char[] alphabet = "qwertyuiopasdfghjklzxcvbnmQWRTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            bool simbol = false;
            for (int i = 0; i < text_b.Length; i++)
            {
                if (text_b.Contains(alphabet[i]) | text_b.Contains(simbols[i]))
                {
                    simbol = true;
                }
            }
            return simbol;
        }
        string check(string text_b) /*проверка всей инфы*/
        {
            int val = 100;
            check_popularpas(text_b);
            check_str(text_b);
            check_simbol(text_b);
            check_difP(text_b);
            check_repeat(text_b);
            if (check_repeat(text_b)) { val -= 10; } else { val += 10; }
            if (check_difP(text_b)) { val -= 10; } else { val += 10; }
            if (check_simbol(text_b)) { val -= 20; } else { val += 20; }
            if (check_str(text_b)) { val -= 40; } else { val += 20; }
            if (check_popularpas(text_b)) { val = 0; } else { val += 30; }
            if (val > 100)
            {
                val = 100;
            }else if (val < 0)
            {
                val = 0;
            }

            return val.ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            String text_b = input.Text.Replace(" ", "");
            if(text_b.Length < 8 || text_b.Length > 16) {
                MessageBox.Show("Пароль должен быть от 8 до 16 символов");
            }
            else
            {
                check(text_b);
                history(text_b);
                input.Text = check(text_b);
            }
        }
    }
}
