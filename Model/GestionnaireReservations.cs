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
            foreach (Reservation r in m_lesReservations)
            {
                if (r == reservation)
                {
                    throw new InvalidOperationException($"La réservation {reservation} existe pour ce client et cette projection.");
                }
            }
            
            reservation.Projection.ReserverPlaces(reservation.NbrPlaces);
            
            m_lesReservations.Add(reservation);
        }

        /// <summary>
        /// Annule une réservation existante pour un client et une projection donnés.
        /// Met également à jour le nombre de places réservées dans la projection associée.
        /// </summary>
        /// <param name="client">Le client ayant effectué la réservation.</param>
        /// <param name="projection">La projection réservée.</param>
        /// <exception cref="InvalidOperationException">
        /// Lancée si aucune réservation n'est trouvée pour ce client et cette projection.
        /// </exception>
        public void AnnulerReservation(Client client, Projection projection)
        {
            Reservation reservationAnnuler = null;

            foreach (Reservation reservation in m_lesReservations)
            {
                if (reservation.Client == client && reservation.Projection == projection)
                {
                    reservationAnnuler = reservation;
                    break;
                }
            }

            if (reservationAnnuler == null)
            {
                throw new InvalidOperationException($"Aucune réservation n'a été faite par {client.Nom} pour: {projection}.");
            }

            projection.LibererPlaces(reservationAnnuler.NbrPlaces);
            
            m_lesReservations.Remove(reservationAnnuler);
        }

        /// <summary>
        /// Retourne le bilan des réservations pour un mois donné.
        /// </summary>
        /// <param name="iNumeroDuMois">Le numéro du mois (1 pour janvier, 12 pour décembre).</param>
        /// <returns>Une liste d'objets StatistiquesSalle avec le montant total des réservations pour chaque salle.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Si le numéro du mois est inférieur à 1 ou supérieur à 12.
        /// </exception>
        public List<StatistiquesSalle> BilanMensuel(int iNumeroDuMois)
        {
            // Vérification que le numéro du mois est valide (entre 1 et 12).
            if (iNumeroDuMois < 1 || iNumeroDuMois > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(iNumeroDuMois), "Le mois doit être un entier entre 1 et 12.");
            }

            // Récupération de l'année en cours.
            int anneeCourante = DateTime.Now.Year;

            // Liste pour stocker les statistiques des salles pour le mois demandé.
            List<StatistiquesSalle> resultats = new List<StatistiquesSalle>();

            // Parcours de toutes les réservations existantes.
            foreach (Reservation reservation in m_lesReservations)
            {
                // Récupère la date de projection de la réservation.
                DateTime date = reservation.Projection.DateProjection;

                // Vérifie si la projection a lieu durant le mois et l'année courante.
                if (date.Month == iNumeroDuMois && date.Year == anneeCourante)
                {
                    // Récupère le nom de la salle et le montant de la réservation pour la projection.
                    string nomSalle = reservation.Projection.NomSalle;
                    decimal montant = reservation.MontantReservation;

                    // Variable pour vérifier si la salle a déjà été ajoutée à la liste des résultats.
                    bool trouve = false;

                    // Recherche si la salle existe déjà dans la liste des résultats.
                    for (int i = 0; i < resultats.Count; i++)
                    {
                        // Si la salle existe déjà dans la liste des résultats, on met à jour le montant.
                        if (resultats[i].NomSalle == nomSalle)
                        {
                            // Récupère l'objet StatistiquesSalle pour cette salle.
                            StatistiquesSalle stat = resultats[i];

                            // Ajoute le montant de la réservation au total mensuel de cette salle.
                            stat.MontantMensuel += montant;

                            // Met à jour la liste avec la nouvelle valeur du montant pour cette salle.
                            resultats[i] = stat;

                            // Marque la salle comme trouvée.
                            trouve = true;
                            break;
                        }
                    }

                    // Si la salle n'a pas encore été ajoutée à la liste des résultats, on l'ajoute maintenant.
                    if (!trouve)
                    {
                        // Ajoute une nouvelle entrée pour cette salle avec le montant de la réservation.
                        resultats.Add(new StatistiquesSalle(nomSalle, montant));
                    }
                }
            }

            // Retourne la liste des statistiques de salles pour le mois et l'année donnés.
            return resultats;
        }

        /// <summary>
        /// Retourne le client de l'année ainsi que le montant total qu'il a dépensé.
        /// Le client de l'année est celui qui a dépensé le plus d'argent pour l'année courante.
        /// </summary>
        /// <returns>Une chaîne de caractères formatée avec le nom du client et le montant dépensé.</returns>
        public string ClientDeLAnnee()
        {
            // Récupère l'année en cours.
            int anneeCourante = DateTime.Now.Year;

            // Variables pour suivre le client avec le plus grand montant dépensé.
            Client clientDeLAnnee = null;
            decimal montantDepense = 0;

            // Parcours de toutes les réservations existantes.
            foreach (Reservation reservation in m_lesReservations)
            {
                // On ignore les réservations à venir (celles dont la date de projection est dans le futur).
                if (reservation.Projection.DateProjection.Date > DateTime.Now.Date)
                {
                    continue;
                }

                // Récupère l'année de la projection de la réservation.
                int anneeProjection = reservation.Projection.DateProjection.Year;

                // Si la réservation appartient à l'année courante, on calcule les dépenses.
                if (anneeProjection == anneeCourante)
                {
                    // Si le montant de cette réservation est plus élevé que le montant maximum enregistré, on met à jour.
                    if (reservation.MontantReservation > montantDepense)
                    {
                        montantDepense = reservation.MontantReservation;
                        clientDeLAnnee = reservation.Client;
                    }
                    else if (reservation.MontantReservation == montantDepense)
                    {
                        // Si le montant est égal à celui déjà enregistré, on peut comparer les noms ou autres critères si nécessaire.
                        // Pour l'instant, on garde le premier client avec ce montant.
                        continue;
                    }
                }
            }

            // Si aucun client n'a effectué de réservation pour l'année en cours, retourner un message indiquant cela.
            if (clientDeLAnnee == null)
            {
                return "Aucun client n'a effectué de réservation pour l'année en cours.";
            }

            // Retourne le nom du client et le montant dépensé, formaté comme demandé.
            return $"{clientDeLAnnee}: {montantDepense:C}";
        }

        /// <summary>
        /// Vérifie si le client a effectué une réservation existante.
        /// </summary>
        /// <param name="client">Le client à vérifier.</param>
        /// <returns>Retourne true si le client a une réservation, sinon false.</returns>
        public bool PossedeUneReservationPour(Client client)
        {
            // Vérifie si le client est null.
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Le client ne peut pas être nul.");
            }

            // Parcours toutes les réservations et vérifie si le client a une réservation existante.
            foreach (Reservation reservation in m_lesReservations)
            {
                // Si une réservation existe pour ce client, retourner true.
                if (reservation.Client == client)
                {
                    return true;
                }
            }

            // Si aucune réservation n'a été trouvée pour ce client, retourner false.
            return false;
        }






    }
}
