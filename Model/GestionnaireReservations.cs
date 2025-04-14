/*
 ***************************************************************************************
 *Nom du fichier: GestionnaireReservations.cs
 *Nom de la classe:GestionnaireReservations
 *Description du rôle du fichier: Ce fichier contient la classe qui gère les réservations et permet de calculer certaines statistiques pour la gestion du cinéma.
 *Auteur: Ibtissam Boukdir - Houssem Saiah
 ***************************************************************************************
 */

using System;
using System.Collections.Generic;
using MyProjectGestionCinema.Model;

namespace MyProjectGestionCinema.Model
{
    public class GestionnaireReservations
    {
        private List<Reservation> m_lesReservations;

        public GestionnaireReservations()
        {
            m_lesReservations = new List<Reservation>();
        }

        public void AjouterReservation(Reservation uneReservation)
        {
            bool existe = false;
            int i = 0;
            while (i < m_lesReservations.Count && !existe)
            {
                existe = (uneReservation == m_lesReservations[i]);
                i++;
            }

            if (existe)
            {
                throw new InvalidOperationException("La réservation " + uneReservation + " existe pour ce client et cette projection.");
            }

            uneReservation.Projection.ReserverPlaces(uneReservation.NbrPlaces);
            m_lesReservations.Add(uneReservation);
        }

        public void AnnulerReservation(Client unClient, Projection uneProjection)
        {
            Reservation reservationTrouvee = null;
            int i = 0;

            while (i < m_lesReservations.Count && reservationTrouvee == null)
            {
                if (m_lesReservations[i].Client == unClient && m_lesReservations[i].Projection == uneProjection)
                {
                    reservationTrouvee = m_lesReservations[i];
                }
                i++;
            }

            if (reservationTrouvee == null)
            {
                throw new InvalidOperationException("Aucune réservation n'a été faite par " + unClient.Nom + " pour : " + uneProjection);
            }

            reservationTrouvee.Projection.LibererPlaces(reservationTrouvee.NbrPlaces);
            m_lesReservations.Remove(reservationTrouvee);
        }


        public List<StatistiquesSalle> BilanMensuel(int iNumeroDuMois)
        {
            List<StatistiquesSalle> listeStatistiquesSalles = new List<StatistiquesSalle>();

            if (iNumeroDuMois < 1 || iNumeroDuMois > 12)
            {
                throw new InvalidOperationException("Le mois doit être un entier entre 1 et 12");
            }

            int anneeCourant = DateTime.Now.Year;

            foreach (Reservation reservation in m_lesReservations)
            {
                if ((iNumeroDuMois == reservation.Projection.DateProjection.Month) &&
                    (anneeCourant == reservation.Projection.DateProjection.Year))
                {
                    bool salleExiste = false;
                    int i = 0;
                    while (i < listeStatistiquesSalles.Count && !salleExiste)
                    {
                        if (listeStatistiquesSalles[i].strNomSalle== reservation.Projection.NomSalle)
                        {
                            listeStatistiquesSalles[i].montantReservations += reservation.MontantReservation;
                            salleExiste = true;
                        }
                        i++;
                    }

                    if (!salleExiste)
                    {
                        StatistiquesSalle uneSalle;
                        
                    }

                }
            }

            return listeStatistiquesSalles;
        }

        public string ClientDeLAnnee()
        {
            int anneeCourante = DateTime.Now.Year;
            Client clientDeLannee = null;
            decimal montantMax = 0;

            List<Client> clients = new List<Client>();

            foreach (Reservation reservation in m_lesReservations)
            {
                if (reservation.Projection.DateProjection.Year == anneeCourante &&
                    reservation.Projection.DateProjection.Date <= DateTime.Now.Date)
                {
                    Client client = reservation.Client;
                    bool clientExiste = false;
                    int i = 0;
                    while (i < clients.Count && !clientExiste)
                    {
                        clientExiste = clients[i] == client;
                        i++;
                    }
                    if (!clientExiste)
                    {
                        clients.Add(client);
                    }
                }
            }

            for (int i = 0; i < clients.Count; i++)
            {
                decimal total = 0;
                for (int j = 0; j < m_lesReservations.Count; j++)
                {
                    if (m_lesReservations[j].Client == clients[i] &&
                        m_lesReservations[j].Projection.DateProjection.Year == anneeCourante &&
                        m_lesReservations[j].Projection.DateProjection.Date <= DateTime.Now.Date)
                    {
                        total += m_lesReservations[j].MontantReservation;
                    }
                }

                if (total > montantMax)
                {
                    montantMax = total;
                    clientDeLannee = clients[i];
                }
            }

            if (clientDeLannee == null)
            {
                return "Aucun client n'a effectué de réservation pour l'année en cours.";
            }

            return string.Format("{0}: {1:C}", clientDeLannee, montantMax);
        }

        public bool PossedeUneReservationPour(Client client)
        {
            bool trouve = false;
            int index = 0;

            while (!trouve && index < m_lesReservations.Count)
            {
                trouve = (client == m_lesReservations[index].Client);
                index++;
            }

            return trouve;
        }

        public bool PossedeUneReservationPour(Projection projection)
        {
            bool trouve = false;
            int index = 0;

            while (!trouve && index < m_lesReservations.Count)
            {
                trouve = (projection == m_lesReservations[index].Projection);
                index++;
            }

            return trouve;
        }
    }
}
