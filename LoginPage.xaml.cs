using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;  // nécessaire pour Page

namespace ProjetGhibliTicketApp
{
    public partial class LoginPage : Page  // <-- ici Page et pas Window
    {
        private string dbPath = "Data Source=C:/Users/Jessica/DataGripProjects/projetGhibli/identifier.sqlite";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void SubmitLogin(object sender, RoutedEventArgs e)
        {
            string nomUtilisateur = NomTextBox.Text.Trim();
            string motDePasse = MotDePassePasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(nomUtilisateur) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();

                    string query = "SELECT id_utilisateur, role FROM utilisateur WHERE nom_utilisateur = @nom AND mot_de_passe = @mot_de_passe";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nom", nomUtilisateur);
                        cmd.Parameters.AddWithValue("@mot_de_passe", motDePasse);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long userId = reader.GetInt64(0);
                                string role = reader.GetString(1);

                                AdminTicketViewWindow adminWindow = new AdminTicketViewWindow(userId, role);
                                adminWindow.Show();
                                // Comme tu es dans une Page, pour fermer la fenêtre parente :
                                Window.GetWindow(this)?.Close();
                            }
                            else
                            {
                                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion : {ex.Message}");
            }
        }
    }
}
