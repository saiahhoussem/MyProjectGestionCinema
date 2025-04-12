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



    }
}
