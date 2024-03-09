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

namespace InspiringQuotes
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
            var quotes = new Quote[]
            {
                new Quote("Tough times don’t last. Tough people do. – Robert H. Schuller", "images/1.jpg"),
                new Quote("Pain is temporary. Quitting lasts forever. – Lance Armstrong", "images/2.jpg"),
                new Quote("A problem is a chance for you to do your best. – Duke Ellington", "images/3.jpg"),
                new Quote("Motivation is what gets you started. Habit is what keeps you going. – Jim Rohn", "images/4.jpg"),
                new Quote("A little progress each day adds up to big results. – Satya Nani", "images/5.jpg"),
                new Quote("If you get tired, learn to rest, not quit. – Unknown", "images/6.jpg"),
                new Quote("Success consists of getting up just one more time than you fall. – Oliver Goldsmith", "images/7.jpg"),
                new Quote("Don’t stop until you’re proud. – Unknown", "images/8.jpg"),
                new Quote("Focus on your goal. Don’t look in any direction but ahead. – Unknown", "images/9.jpg"),
                new Quote("Courage is one step ahead of fear. – Coleman Young", "images/10.jpg"),
                new Quote("Don’t wish it were easier. Wish you were better. ― Jim Rohn", "images/11.jpg"),
                new Quote("I find that the harder I work, the more luck I seem to have. – Thomas Jefferson", "images/12.jpg"),
                new Quote("Success is the sum of small efforts repeated day-in and day-out. – Robert Collier", "images/13.jpg"),
                new Quote("We must embrace pain and burn it as fuel for our journey. – Kenji Miyazawa", "images/14.jpg"),
                new Quote("Believe you can and you’re halfway there. – Theodore Roosevelt", "images/15.jpg")
            };
            Random rng = new Random();
            int i = rng.Next(quotes.Length);
            string nameQuote = quotes[i].getQuote();
            labelQuote.Content = nameQuote;

            var bitmap = new BitmapImage(
                new Uri(quotes[i].getImage(), UriKind.Relative)
            ); // Unique resource identifier
            imageQuote.Source = bitmap;
        }

        private void btnRandon_onPressed(object sender, RoutedEventArgs e)
        {
            Random();
        }
    }
}
