using System;
using System.IO;
using Microsoft.Win32;
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
using System.Runtime.Serialization.Formatters.Binary;

using CardLib;

namespace BankGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = game;

            ListBox_BankCards.ItemsSource = game.bankCards;
            ListBox_AvailableCards.ItemsSource = game.availableCards;


            //TextBlock_ActualDate.Text = game.Date.ToString();///////!!!!

            //Binding bd1 = new Binding();
            //bd1.Source = game;
            //bd1.Path = new PropertyPath("Date");
            //TextBlock_ActualDate.SetBinding(TextBlock.TextProperty, bd1);



            //game.addExCards();

        }
        
        private void Button_NextStep_Click(object sender, RoutedEventArgs e)
        {
            game.nextStep();
            //TextBlock_ActualDate.Text = game.Date.ToString();
        }

        private void Button_AddCardToBank_Click(object sender, RoutedEventArgs e)
        {
            Card card = (Card)ListBox_AvailableCards.SelectedItem;
            card.initialApply();
        }
    }
}
