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

namespace Structs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    struct User
    {
        public string name;
        public int age;
        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
    public partial class MainWindow : Window
    {
        private User[] users;
        private int CountUser;
        private int i=0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i == 0)
            {
                try
                {
                    int count = int.Parse(Count.Text);
                    CountUser = count;
                    users = new User[count];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (i <CountUser)
            {
                UserWindow userWindow = new UserWindow();
                if (userWindow.ShowDialog() == true)
                {
                    
                    string name = userWindow.UserName;
                    int age = userWindow.UserAge;
                    User user = new User(name, age);
                    users[i] = user;
                    List.Items.Add(user.name + " " + user.age);
                    i++;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double s = 0;
            for(int i=0;i<users.Length;i++)
            {
                s += users[i].age;
            }
            double avg = s / users.Length;
            List.Items.Add("Средний возраст:" + avg);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<users.Length-1;i++)
            {
                for(int j=i;j<users.Length;j++)
                {
                    if(users[i].age>users[j].age)
                    {
                        User temp = users[i];
                        users[i] = users[j];
                        users[j] = temp;
                    }
                }
            }
            List.Items.Clear();
            foreach(User i in users)
            {
                List.Items.Add(i.name+" "+i.age);
            }
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedIndex != -1)
            {
                User user = users[List.SelectedIndex];
                Name.Text = user.name;
                Age.Text = user.age.ToString();
            }
        }
    }
}
