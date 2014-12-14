using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Maria_Kart__Game_Player_.Entities;
using Maria_Kart__Game_Player_.Records;

namespace Maria_Kart__Game_Player_
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private ObservableCollection<PlayerRecord> PlayersCollection { get; set; }

        public PlayerRecord PlayerSelected { get; set; }

        public PlayerWindow()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        public new void Show()
        {
            base.ShowDialog();
        }

        private void InitializeCustomComponent()
        {
            PlayersCollection = new ObservableCollection<PlayerRecord>();
            DataGridBestPlayer.ItemsSource = PlayersCollection;
            LoadData();
        }

        private void LoadData()
        {
            PlayersCollection.Clear();

            try
            {
                MariaKartEntities entities = DataModelUtils.InstanceEntities();

                foreach (PlayerEntity player in entities.PlayerEntities)
                {
                    PlayersCollection.Add(new PlayerRecord(player));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error to access the database.", "Error");
            }
        }

        private void ButtonAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer addPlayer = new AddPlayer();
            addPlayer.Owner = this;
            addPlayer.ShowDialog();

            LoadData();
        }

        private void ButtonEditPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBestPlayer.SelectedItem != null)
            {
                AddPlayer addPlayer = new AddPlayer((PlayerRecord)DataGridBestPlayer.SelectedItem);
                addPlayer.Owner = this;
                addPlayer.ShowDialog();

                LoadData();
            }
            else
            {
                MessageBox.Show("Select a player.");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSelectPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridBestPlayer.SelectedItem != null)
            {
                PlayerSelected = (PlayerRecord) DataGridBestPlayer.SelectedItem;
                Close();
            }
            else
            {
                MessageBox.Show("Select a player.");
            }
        }
    }
}
