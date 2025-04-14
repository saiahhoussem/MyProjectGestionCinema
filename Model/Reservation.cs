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

            NbrPlaces = nbrPlaces;
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

        /// <summary>
        /// Obtient la projection associée à cette réservation.
        /// </summary>
        public Projection Projection
        {
            get
            {
                return m_laProjectionAssociee;
            }
        }

        /// <summary>
        /// Obtient ou définit le nombre de places réservées.
        /// La valeur doit être comprise entre 1 et 10 inclus.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Levée si la valeur est inférieure à 1 ou supérieure à 10.
        /// </exception>
        public int NbrPlaces
        {
            get { return m_iNbrPlaces; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Le nombre de places réservées doit être compris entre 1 et 10.");
                }
                m_iNbrPlaces = value;
            }
        }

        /// <summary>
        /// Obtient le montant total de la réservation, calculé en fonction du nombre de places réservées 
        /// et du prix de la projection associée à la réservation.
        /// </summary>
        /// <returns>Le montant total de la réservation.</returns>
        public decimal MontantReservation
        {
            get
            {
                return NbrPlaces * m_laProjectionAssociee.PrixProjection;
            }
        }

        /// <summary>
        /// Redéfinit la méthode ToString pour fournir une représentation textuelle de la réservation.
        /// Retourne une chaîne qui indique le nombre de places réservées, le nom du client, 
        /// la projection associée, et le montant total de la réservation.
        /// </summary>
        /// <returns>Une chaîne de caractères représentant la réservation.</returns>
        public override string ToString()
        {
            return string.Format("{0} places réservées par {1} pour {2} : {3}$.", NbrPlaces, Client.Nom, Projection, MontantReservation);
        }

        /// <summary>
        /// Compare deux objets Reservation pour l'égalité en utilisant l'opérateur '=='.
        /// Vérifie si les deux références sont identiques, si l'un des objets est nul,
        /// puis compare les champs 'Client', 'Projection' et 'NbrPlaces'.
        /// </summary>
        /// <param name="r1">Le premier objet Reservation à comparer.</param>
        /// <param name="r2">Le deuxième objet Reservation à comparer.</param>
        /// <returns>Vrai si les deux objets Reservation sont égaux, sinon faux.</returns>
        public static bool operator ==(Reservation r1, Reservation r2)
        {
            // Si les deux objets sont la même référence ou les deux sont nuls
            if (ReferenceEquals(r1, r2)) return true;

            // Si l'un des objets est nul et l'autre non
            if ((object)r1 == null || (object)r2 == null) return false;

            // Comparer les champs essentiels pour l'égalité
            return r1.Client == r2.Client && r1.Projection == r2.Projection;
        }

        /// <summary>
        /// Compare deux objets Reservation pour l'inégalité en utilisant l'opérateur '!='.
        /// Retourne la négation de la comparaison '=='.
        /// </summary>
        /// <param name="r1">Le premier objet Reservation à comparer.</param>
        /// <param name="r2">Le deuxième objet Reservation à comparer.</param>
        /// <returns>Vrai si les deux objets Reservation ne sont pas égaux, sinon faux.</returns>
        public static bool operator !=(Reservation r1, Reservation r2)
        {
            return !(r1 == r2); // Appel à l'opérateur '==' pour simplifier l'inversion de l'égalité
        }

        /// <summary>
        /// Vérifie si l'objet donné est égal à l'objet Reservation actuel.
        /// Retourne vrai si l'objet est une Reservation et que les champs 'Client', 
        /// 'Projection' et 'NbrPlaces' sont identiques à ceux de l'objet actuel.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'objet Reservation actuel.</param>
        /// <returns>Vrai si l'objet est une Reservation et égal à l'objet actuel, sinon faux.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj is Reservation uneReservation && this == uneReservation;
        }


        /// <summary>
        /// Redéfinit la méthode <see cref="GetHashCode"/> pour générer un code de hachage basé sur les propriétés 
        /// essentielles de la réservation, à savoir le client, la projection et le nombre de places réservées.
        /// Cette méthode garantit que deux objets de type <see cref="Reservation"/> ayant les mêmes valeurs 
        /// pour ces propriétés auront le même code de hachage.
        /// </summary>
        /// <returns>Un code de hachage pour l'objet <see cref="Reservation"/> basé sur ses propriétés essentielles.</returns>

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
