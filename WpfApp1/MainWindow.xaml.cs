using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
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
string path = "text_file/TextFile1.txt";
using (FileStream fstream = File.OpenRead(path))
{
    byte[] buffer = new byte[fstream.Length];
    await fstream.ReadAsync(buffer, 0, buffer.Length);
    string textFromFile = Encoding.Default.GetString(buffer);
    char delimiter = ',';
    string[] stringArray = textFromFile.Split(delimiter);
}

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        string check(string text_b, string stringArray)
        {
            char[] alphabet = "qwertyuiopasdfghjklzxcvbnmQWRTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
            char[] simbols = "!@#$%^&*()|{}<>?".ToCharArray();
            int value = 100;
            bool check_simbol = false;
            for ( int i = 0; i < text_b.Length; i++ )
            {
                if(text_b.Contains(alphabet[i]) | text_b.Contains(simbols[i]))
                {
                    value += 10;
                    check_simbol = true;
                }
                else
                {
                    value -= 10;
                }
            }
            if (check_simbol) { value += 20; }
            return value.ToString();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            String text_b = input.Text;
            if(text_b.Length < 8 && text_b.Length > 16) {
                MessageBox.Show("Пароль должен быть от 8 до 16 символов");
            }
            else
            {
                //check(text_b, stringArray);
                //input.Text = check(text_b);
            }
        }
    }
}
