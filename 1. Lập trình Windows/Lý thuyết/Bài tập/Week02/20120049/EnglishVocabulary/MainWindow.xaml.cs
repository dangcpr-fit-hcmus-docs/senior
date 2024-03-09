using System;
using System.Collections;
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

namespace EnglishVocabulary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random();
        }

        private void Random()
        {
            var vocabs = new Vocabulary[]
            {
                new Vocabulary("Book", "images\\1.jpg"),
                new Vocabulary("House", "images\\2.jpg"),
                new Vocabulary("Car", "images\\3.jpg"),
                new Vocabulary("Computer", "images\\4.jpg"),
                new Vocabulary("Phone", "images\\5.jpg"),
                new Vocabulary("Table", "images\\6.jpg"),
                new Vocabulary("Chair", "images\\7.jpg"),
                new Vocabulary("Door", "images\\8.jpg"),
                new Vocabulary("Window", "images\\9.jpg"),
                new Vocabulary("Actor", "images\\10.jpg"),
                new Vocabulary("Hairdresser", "images\\11.jpg"),
                new Vocabulary("Doctor", "images\\12.jpg"),
                new Vocabulary("Teacher", "images\\13.jpg"),
                new Vocabulary("Student", "images\\14.jpg"),
                new Vocabulary("Plumber", "images\\15.jpg"),
            };
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int lastIndex = baseDirectory.LastIndexOf("\\");
            string projectDirectory = baseDirectory.Substring(0, lastIndex);

            lastIndex = projectDirectory.LastIndexOf("\\");
            projectDirectory = projectDirectory.Substring(0, lastIndex);

            lastIndex = projectDirectory.LastIndexOf("\\");
            projectDirectory = projectDirectory.Substring(0, lastIndex);

            lastIndex = projectDirectory.LastIndexOf("\\");
            projectDirectory = projectDirectory.Substring(0, lastIndex);

            projectDirectory = $"{projectDirectory}\\";

            Random rng = new Random();
            int i = rng.Next(vocabs.Length);
            string avatar = $"{projectDirectory}{vocabs[i].getImage()}";


            string vocab = vocabs[i].getVocab();
            labelVocab.Content = vocab;

            var bitmap = new BitmapImage(
                new Uri(avatar, UriKind.Absolute)
            ); // Unique resource identifier
            imageVocab.Source = bitmap;
        }

        private void btnRandom_onPressed(object sender, RoutedEventArgs e)
        {
            Random();
        }

        private void btnQuiz_onPressed(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow();
            quizWindow.Show();
            this.Close();
        }
    }
}
