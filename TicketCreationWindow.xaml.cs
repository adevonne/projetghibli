using System;
using System.Data.SQLite;
using System.Windows;

namespace ProjetGhibliTicketApp
{
    public partial class TicketCreationWindow : Window
    {
        private long _currentUserId;
        private string _currentUsername;
        private string dbPath = "Data Source=C:/Users/Jessica/DataGripProjects/projetGhibli/identifier.sqlite";

        public TicketCreationWindow(long userId, string username)
        {
            InitializeComponent();
            _currentUserId = userId;
            _currentUsername = username;

            // Génère une date du jour et l'affiche
            DateCreationTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            // Génère un numéro de ticket plus court en combinant la date et l'heure
            NomTicketTextBox.Text = GenerateTicketNumber();
        }

        // Fonction pour générer un numéro de ticket court basé sur la date et l'heure
        private string GenerateTicketNumber()
        {
            // Génère un nombre aléatoire entre 1000 et 9999 pour avoir toujours 4 chiffres
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000); // Génère un nombre entre 1000 et 9999

            // Utilise un préfixe pour rendre le numéro de ticket plus explicite
            return randomNumber.ToString(); // Retourne le numéro de ticket avec le préfixe
        }


        private void SubmitTicket(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();

                    string insertQuery = @"
                    INSERT INTO ticket (
                        nom_ticket, demande, date_creation, categorie, service,
                        id_utilisateur, statut, priorite, technicien, nom_utilisateur
                    )
                    VALUES (
                        @nom_ticket, @demande, @date_creation, @categorie, @service,
                        @id_utilisateur, @statut, @priorite, @technicien, @nom_utilisateur
                    );";

                    using (var cmd = new SQLiteCommand(insertQuery, connection))
                    {
                        // Ajoute le numéro de ticket généré
                        cmd.Parameters.AddWithValue("@nom_ticket", NomTicketTextBox.Text);
                        cmd.Parameters.AddWithValue("@demande", DescriptionTextBox.Text);
                        cmd.Parameters.AddWithValue("@date_creation", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@categorie", CategorieComboBox.Text);
                        cmd.Parameters.AddWithValue("@service", ServiceComboBox.Text);
                        cmd.Parameters.AddWithValue("@id_utilisateur", _currentUserId);
                        cmd.Parameters.AddWithValue("@statut", "Nouveau"); // statut par défaut
                        cmd.Parameters.AddWithValue("@priorite", "Moyenne"); // priorité par défaut
                        cmd.Parameters.AddWithValue("@technicien", ""); // technicien vide au départ
                        cmd.Parameters.AddWithValue("@nom_utilisateur", _currentUsername);

                        // Exécute la requête
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ticket créé avec succès !");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement du ticket : {ex.Message}");
            }
        }
    }
}
