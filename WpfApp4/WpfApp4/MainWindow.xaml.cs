using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.Class;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context _context = new Context();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Students= (from s in _context.Students select s).ToList();
            combo.ItemsSource = Students;
            combo.DisplayMemberPath = "Name";
            combo.SelectedValuePath = "Id";
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (combo.SelectedItem is Students Students)
            {
                id.Content= (Students.Id).ToString();
                Name.Text=Students.Name;
                Grade.Text=(Students.Grade).ToString();
                Age.Text=(Students.Age).ToString();
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Id= int.Parse((id.Content).ToString());
            var update=(from s in _context.Students where s.Id==Id select  s).FirstOrDefault()  ;
           update.Name=Name.Text;
            update.Age=int.Parse((Age.Text).ToString());
            update.Grade=int.Parse((Grade.Text).ToString());
            
            _context.Students.Update(update);
            _context.SaveChanges();
            combo.ItemsSource = "";
            Name.Clear();
            Grade.Clear();
            Age.Clear();
            id.Content = "";
            
        }

    

  


        //private void Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    string name = Name.Text;
        //    int age = int.Parse(Age.Text);
        //    int grade = int.Parse(Grade.Text);
        //    // Condidition
        //    if (age < 10 || grade<2)
        //    {
        //        MessageBox.Show("Can't ADD This student sorry");
        //        return;
        //    }

        //    Students mo = new Students()
        //    {
        //        Name = name,
        //        Age = age,
        //        Grade = grade,
        //    };

        //    _context.Students.Add(mo);
        //    _context.SaveChanges();
        //    Name.Clear();
        //    Age.Clear();
        //    Grade.Clear();
        //    MessageBox.Show("Add Student");
        //    var Display=from x in _context.Students select x;
        //    foreach(var x in Display)

        //    {
        //        List.Items.Add(x.Name+" "+x.Id+" "+ x.Grade);
        //    }

        //}

        //private void Btn2_Click(object sender, RoutedEventArgs e)
        //{
        //    var Display = from x in _context.Students select x;
        //    foreach (var x in Display)

        //    {
        //        List.Items.Add(x.Name + " " + x.Age + " " + x.Grade);
        //    }
        //}


    }
}