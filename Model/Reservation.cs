//***************************************************************************************
//  + Nom du fichier: Reservation.cs
//  + Nom de la classe: Reservation
//  + Description du rôle du fichier: Cette classe représente les reservations des clients à des films.
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
    public class Reservation
    {

        private Client m_leClient;
        private Projection m_laProjectionAssociee;
        private int m_iNbrPlaces;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Reservation"/> avec les informations du client, 
        /// de la projection et du nombre de places souhaitées.
        /// </summary>
        /// <param name="leClient">Le client qui effectue la réservation.</param>
        /// <param name="laProjection">La projection à laquelle le client souhaite assister.</param>
        /// <param name="nbrPlaces">Le nombre de places à réserver (entre 1 et 10).</param>
        /// <exception cref="ArgumentNullException">
        /// Levée si le client ou la projection est null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Levée si le nombre de places est inférieur à 1 ou supérieur à 10.
        /// </exception
        public Reservation( Client leClient, Projection laProjection, int nbrPlaces ) 
        { 
            if (leClient == null)
            {
                throw new ArgumentNullException("Une réservation doit être associée à un client non null.");
            }
            m_leClient = leClient;

            if (laProjection == null)
            {
                throw new ArgumentNullException("Une projection doit être associée à une projection non null.");
            }
            m_laProjectionAssociee = laProjection;

            //à modifier
            m_iNbrPlaces = nbrPlaces;

        }

        /// <summary>
        /// Obtient le client associé à cette réservation.
        /// </summary>
        public Client Client
        {
            get
            {
                return m_leClient;
            }
        }

       



    }
}
