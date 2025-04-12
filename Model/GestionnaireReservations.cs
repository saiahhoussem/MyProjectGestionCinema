//***************************************************************************************
//  + Nom du fichier: GestionnaireReservations.cs
//  + Nom de la classe: GestionnaireReservations
//  + Description du rôle du fichier: Cette classe contient les réservations et permet
//    de calculer certaines statistiques nécessaires pour la gestion du cinéma.
//  + Auteur: Houssem Saiah
//  + Créer le: 2025-04-08
//***************************************************************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectGestionCinema.Model
{
    public class GestionnaireReservations
    {

        private List<Reservation> m_lesReservations;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="GestionnaireReservations"/> 
        /// avec une liste vide de réservations.
        /// </summary>
        public GestionnaireReservations()
        {
            m_lesReservations = new List<Reservation>();
        }

        /// <summary>
        /// Ajoute une réservation si elle n'existe pas déjà pour le même client et la même projection.
        /// Met également à jour le nombre de places réservées dans la projection associée.
        /// </summary>
        /// <param name="reservation">La réservation à ajouter.</param>
        /// <exception cref="InvalidOperationException">
        /// Lancée si une réservation existe déjà pour ce client et cette projection.
        /// </exception>
        public void AjouterReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation), "La réservation ne peut pas être nulle.");
            }

            foreach (Reservation r in m_lesReservations)
            {
                if (r == reservation)
                {
                    throw new InvalidOperationException($"La réservation {reservation} existe pour ce client et cette projection.");
                }
            }

            // Réserver les places dans la projection
            reservation.Projection.ReserverPlaces(reservation.NbrPlaces);

            // Ajouter la réservation à la liste
            m_lesReservations.Add(reservation);
        }




    }
}
