using System;

namespace ProjetGhibliTicketApp
{
    public class Ticket
    {
        public long IdTicket { get; set; }
        public string NomTicket { get; set; }
        public string Demande { get; set; }
        public string DateCreation { get; set; }
        public string NomUtilisateur { get; set; } // Cela correspond au nom d'utilisateur
        public string Technicien { get; set; }
        public string Categorie { get; set; }
        public string Service { get; set; }
        public string Statut { get; set; }
        public string Priorite { get; set; }

        // Constructeur pour créer un ticket
        public Ticket(long idTicket, string nomTicket, string demande, string dateCreation,
                      string nomUtilisateur, string technicien, string categorie,
                      string service, string statut, string priorite)
        {
            IdTicket = idTicket;
            NomTicket = nomTicket;
            Demande = demande;
            DateCreation = dateCreation;
            NomUtilisateur = nomUtilisateur;
            Technicien = technicien;
            Categorie = categorie;
            Service = service;
            Statut = statut;
            Priorite = priorite;
        }

        // Si tu as besoin de méthode pour manipuler les données, tu peux les ajouter ici
    }
}
