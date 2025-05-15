using System;
using System.Data.SQLite;
using System.Windows;

namespace ProjetGhibliTicketApp
{
    public partial class TicketEditWindow : Window
    {
        private Ticket ticket;
        private string dbPath = "Data Source=C:/Users/Jessica/DataGripProjects/projetGhibli/identifier.sqlite";

        public TicketEditWindow(Ticket ticketToEdit)
        {
            InitializeComponent();
            ticket = ticketToEdit;

            // Charger les valeurs dans les ComboBox
            StatutComboBox.ItemsSource = new string[] { "En attente", "En cours", "Termine" };
            ServiceComboBox.ItemsSource = new string[] { "Support", "Reseau", "Maintenance", "Developpement" };
            TechnicienComboBox.ItemsSource = new string[] { "Technicien 1", "Technicien 2", "Technicien 3" };
            PrioriteComboBox.ItemsSource = new string[] { "Basse", "Moyenne", "Haute" };

            // Pre-remplir avec les valeurs du ticket
            StatutComboBox.SelectedItem = ticket.Statut;
            ServiceComboBox.SelectedItem = ticket.Service;
            TechnicienComboBox.SelectedItem = ticket.Technicien;
            PrioriteComboBox.SelectedItem = ticket.Priorite;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    var query = @"UPDATE ticket SET
                                    statut = @statut,
                                    service = @service,
                                    technicien = @technicien,
                                    priorite = @priorite
                                  WHERE id_ticket = @id";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@statut", StatutComboBox.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@service", ServiceComboBox.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@technicien", TechnicienComboBox.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@priorite", PrioriteComboBox.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@id", ticket.IdTicket);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ticket mis a jour.");
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message);
            }
        }
    }
}
