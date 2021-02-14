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
using System.Windows.Shapes;

namespace TheSimpleGame2.Presentation
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : Window
    {
        GameViewModel _gameViewModel;
        public GameView(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            InitializeComponent();
        }

        private void GameBoard_Click(object sender, RoutedEventArgs e)
        {
            Button boardPositionButton = sender as Button;
            int row = int.Parse(boardPositionButton.Tag.ToString().Substring(0, 1));
            int column = int.Parse(boardPositionButton.Tag.ToString().Substring(1, 1));

            _gameViewModel.PlayerMove(row, column);
        }

        private void WindowButton_Click(object sender, RoutedEventArgs e)
        {
            Button windowButton = sender as Button;

            switch (windowButton.Name)
            {
                case "NewGame":
                case "ResetGame":
                    _gameViewModel.GameCommand(windowButton.Name);
                    break;

                case "QuitSave":
                case "Quit":
                    Close();
                    _gameViewModel.GameCommand(windowButton.Name);
                    break;
            }
        }

        private void Button_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            //Button helpButton = sender as Button;

            Help helpWindow = new Help();
            helpWindow.ShowDialog();
        }
    }
}
