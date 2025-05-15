using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace ProjetGhibliTicketApp
{
    public partial class AdminTicketViewWindow : Window
    {
        private string dbPath = "Data Source=C:/Users/Jessica/DataGripProjects/projetGhibli/identifier.sqlite";
        private long currentUserId;
        private string currentUserRole;

        public ObservableCollection<Ticket> Tickets { get; set; }

        public AdminTicketViewWindow(long userId, string userRole)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserRole = userRole;
            Tickets = new ObservableCollection<Ticket>();
            TicketsDataGrid.ItemsSource = Tickets;

            LoadTickets();

            TicketsDataGrid.MouseDoubleClick += TicketsDataGrid_MouseDoubleClick;
        }

        private void LoadTickets(string searchTerm = "")
        {
            Tickets.Clear();

            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();

                    string query = @"SELECT id_ticket, nom_ticket, demande, date_creation, nom_utilisateur, 
                                            technicien, categorie, service, statut, priorite 
                                     FROM ticket";

                    if (currentUserRole != "admin")
                    {
                        query += " WHERE id_utilisateur = @userId";
                        if (!string.IsNullOrEmpty(searchTerm))
                            query += " AND (nom_ticket LIKE @search OR demande LIKE @search)";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                            query += " WHERE nom_ticket LIKE @search OR demande LIKE @search";
                    }

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        if (currentUserRole != "admin")
                            cmd.Parameters.AddWithValue("@userId", currentUserId);

                        if (!string.IsNullOrEmpty(searchTerm))
                            cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ticket ticket = new Ticket(
                                    reader.GetInt64(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    currentUserRole == "admin" ? reader.GetString(4) : "",
                                    reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetString(7),
                                    reader.GetString(8),
                                    reader.GetString(9)
                                );

                                Tickets.Add(ticket);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur chargement tickets : {ex.Message}");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnCreationTicket_Click(object sender, RoutedEventArgs e)
        {
            TicketCreationWindow ticketCreationWindow = new TicketCreationWindow(currentUserId, currentUserRole);
            ticketCreationWindow.Show();
            this.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.Trim();
            LoadTickets(searchTerm);
        }

        private void TicketsDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (currentUserRole != "admin") return;

            if (TicketsDataGrid.SelectedItem is Ticket selectedTicket)
            {
                TicketEditWindow editWindow = new TicketEditWindow(selectedTicket);
                if (editWindow.ShowDialog() == true)
                {
                    LoadTickets();
                }
            }
        }
    }
}
