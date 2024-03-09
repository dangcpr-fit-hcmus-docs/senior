using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Windows.Shapes;

namespace EnglishVocabulary
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        int count = 0;
        int score = 0;

        List<Vocabulary> question = new List<Vocabulary> { };
        List<string> answer = new List<string>
        {
                "Book",
                "House",
                "Car",
                "Computer",
                "Phone",
                "Table",
                "Chair",
                "Door",
                "Window",
                "Actor",
                "Hairdresser",
                "Doctor",
                "Teacher",
                "Student",
                "Plumber",
        };

        public QuizWindow()
        {
            InitializeComponent();
            RandomQuestion();
            displayQuestion();
        }

        public void RandomQuestion()
        {
            List<Vocabulary> vocabs = new List<Vocabulary>
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


            for (int i = 0; i < 10; i++)
            {
                Random rng = new Random();
                int index = rng.Next(0, vocabs.Count - 1);
                question.Add(vocabs[index]);
                vocabs.RemoveAt(index);
            }

            foreach(Vocabulary item in question)
            {
                string avatar = $"{projectDirectory}{item.getImage()}";


                var bitmap = new BitmapImage(
                    new Uri(avatar, UriKind.Absolute)
                ); // Unique resource identifier
                imageQuestion.Source = bitmap;
            }

        }

        private void displayQuestion()
        {
            if (question.Count == 0) { return; }
            else
            {
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

                string avatar = $"{projectDirectory}{question[count].getImage()}";

                Random rng = new Random();
                int index = rng.Next(0, 2);
                int indexC = rng.Next(0, answer.Count);

                if (index == 0)
                {
                    Option1.Content = question[count].getVocab();
                    Option2.Content = answer[indexC];
                }
                else
                {
                    Option2.Content = question[count].getVocab();
                    Option1.Content = answer[indexC];
                }

                var bitmap = new BitmapImage(
                    new Uri(avatar, UriKind.Absolute)
                ); // Unique resource identifier
                imageQuestion.Source = bitmap;
            }
        }

        private void CheckAnswer()
        {
            if (Option1.IsChecked == true)
            {
                if (Option1.Content.ToString() == question[count].getVocab()) score++;
            }
            else
            {
                if (Option2.Content.ToString() == question[count].getVocab()) score++;
            }
        }

        private void btnNext_onPressed(object sender, RoutedEventArgs e)
        {
            CheckAnswer();
            count++;
            if (count == 10)
            {
                MessageBox.Show($"You have completed the quiz! - Score: {score}/10");
                this.Close();
            }
            else
            {
                Option1.IsChecked = false;
                Option2.IsChecked = false;

                displayQuestion();
            }
        }
    }
}
