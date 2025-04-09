//***************************************************************************************
//  + Nom du fichier: Projection.cs
//  + Nom de la classe: Projection
//  + Description du rôle du fichier: Cette classe représente les projections des films.
//  + Auteur: Houssem Saiah
//  + Créer le: 2025-04-08
//***************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaires;

namespace MyProjectGestionCinema.Model
{
    public class Projection
    {
        public enum ProjectionType
        {
            Standard,
            _3D,
            IMAX,
            _4DX
        }

        private const int PRIX_PLACE_MIN = 10;

        private DateTime m_dteDateProjection;
        private string m_strNomSalleProjection;
        private ProjectionType m_leTypeProjection;
        private int m_iNbrPlaces;
        private int m_iNbrReservations;

        /// <summary>
        /// Constructeur de la classe Projection qui permet d'initialiser les attributs à l'aide des paramètres reçus.
        /// </summary>
        /// <param name="leTypeProjection"></param>
        /// <param name="nomSalleProjection"></param>
        /// <param name="dateProjection"></param>
        public Projection(ProjectionType leTypeProjection, string nomSalleProjection, DateTime dateProjection)
        {
            m_leTypeProjection = leTypeProjection;
            m_strNomSalleProjection = nomSalleProjection;
            m_dteDateProjection = dateProjection;

            // Générer un nombre aléatoire de places entre 10 et 100
            m_iNbrPlaces = Aleatoire.GenererNombre(91) + 10;

            // Initialiser les réservations à 0
            m_iNbrReservations = 0;
        }

        /// <summary>
        /// Accesseur en lecture et en écriture au type de projection.
        /// </summary>
        public ProjectionType TypeProjection
        {
            get
            {
                return m_leTypeProjection;
            }
            set
            {
                m_leTypeProjection = value;
            }
        }

        /// <summary>
        /// Accesseur en lecture et en ecriture pour la date de la projection.
        /// </summary>
        public DateTime DateProjection
        {
            get
            {
                return m_dteDateProjection;
            }
            set
            {
                m_dteDateProjection = value;
            }
        }

        /// <summary>
        /// Accesseur en lecture et en ecriture pour le nom de la salle de projection.
        /// </summary>
        public string NomSalle
        {
            get
            {
                return m_strNomSalleProjection;
            }
            set
            {
                m_strNomSalleProjection = value;
            }
        }

        /// <summary>
        /// Calcule le prix d'un billet d'une projection en fonction du type de la projection.
        /// </summary>
        /// <param name="leTypeProjection">Le type de projection</param>
        /// <returns>Retounrne le prix de la projection.</returns>
        public decimal PrixProjection( ProjectionType leTypeProjection)
        {
            decimal prixProjection = 0;

            switch(leTypeProjection)
            {
                case ProjectionType._3D:
                    prixProjection = PRIX_PLACE_MIN + PRIX_PLACE_MIN * 0.10m ;
                    break;

                case ProjectionType.IMAX:
                    prixProjection = PRIX_PLACE_MIN + PRIX_PLACE_MIN * 0.05m;
                    break;

                case ProjectionType._4DX:
                    prixProjection = PRIX_PLACE_MIN + PRIX_PLACE_MIN * 0.15m;
                    break;

                default:
                    prixProjection = PRIX_PLACE_MIN;
                    break;

            }
            return prixProjection;
        }

        /// <summary>
        /// Accesseur qui permet de voir le nombre de places non réservées.
        /// </summary>
        public int NbrPlacesDisponibles
        {
            get { return m_iNbrPlaces - m_iNbrReservations; }
        }

        /// <summary>
        /// Réserve un nombre donné de places. Si aucune valeur n'est fournie, une seule place est réservée.
        /// </summary>
        /// <param name="nbrPlacesDonne">Nombre de places à réserver (défaut = 1)</param>
        /// <exception cref="InvalidOperationException">
        /// Lancée si le nombre est ≤ 0 ou s'il n'y a pas assez de places disponibles.
        /// </exception>
        public void ReserverPlaces(int nbrPlacesDonne = 1)
        {
            if (nbrPlacesDonne <= 0)
            {
                throw new InvalidOperationException("Nombre de places doit être supérieur à zéro.");
            }

            if (nbrPlacesDonne > NbrPlacesDisponibles)
            {
                throw new InvalidOperationException("Nombre de places insuffisant pour cette réservation.");
            }

            m_iNbrReservations += nbrPlacesDonne;
        }

        /// <summary>
        /// Libère un nombre donné de places réservées.
        /// </summary>
        /// <param name="nbrPlacesDonne">Nombre de places à libérer</param>
        /// <exception cref="InvalidOperationException">
        /// Lancée si le nombre est ≤ 0 ou s'il dépasse le nombre de réservations.
        /// </exception>
        public void LibererPlaces(int nbrPlacesDonne)
        {
            if (nbrPlacesDonne <= 0)
            {
                throw new InvalidOperationException("Nombre de places doit être supérieur à zéro.");
            }

            if (m_iNbrReservations < nbrPlacesDonne)
            {
                throw new InvalidOperationException("Nombre de places réservées insuffisant pour cette annulation.");
            }

            m_iNbrReservations -= nbrPlacesDonne;
        }

        /// <summary>
        /// Redéfinit la méthode ToString pour afficher un résumé de la projection.
        /// </summary>
        /// <returns>Chaîne représentant la projection.</returns>
        public override string ToString()
        {
            return $"Projection {m_leTypeProjection} du {m_dteDateProjection.ToShortDateString()} à la salle {m_strNomSalleProjection}";
        }

        /// <summary>
        /// Compare deux objets Projection pour l'égalité en utilisant l'opérateur '=='.
        /// Vérifie si les deux références sont identiques, si l'un des objets est nul,
        /// puis compare les champs 'NomSalle', 'DateProjection' et 'TypeProjection'.
        /// </summary>
        /// <param name="p1">Le premier objet Projection à comparer.</param>
        /// <param name="p2">Le deuxième objet Projection à comparer.</param>
        /// <returns>Vrai si les deux objets Projection sont égaux, sinon faux.</returns>
        public static bool operator ==(Projection p1, Projection p2)
        {
            if (ReferenceEquals(p1, p2)) return true;

            if ((object)p1 == null || (object)p2 == null) return false;

            return p1.NomSalle == p2.NomSalle && p1.DateProjection == p2.DateProjection && p1.TypeProjection == p2.TypeProjection;
        }

        /// <summary>
        /// Compare deux objets Projection pour l'inégalité en utilisant l'opérateur '!='.
        /// Retourne la négation de la comparaison '=='.
        /// </summary>
        /// <param name="p1">Le premier objet Projection à comparer.</param>
        /// <param name="p2">Le deuxième objet Projection à comparer.</param>
        /// <returns>Vrai si les deux objets Projection ne sont pas égaux, sinon faux.</returns>
        public static bool operator !=(Projection p1, Projection p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Vérifie si l'objet donné est égal à l'objet Projection actuel.
        /// Retourne vrai si l'objet est une Projection et que les champs 'NomSalle',
        /// 'DateProjection' et 'TypeProjection' sont identiques à ceux de l'objet actuel.
        /// </summary>
        /// <param name="obj">L'objet à comparer avec l'objet Projection actuel.</param>
        /// <returns>Vrai si l'objet est une Projection et égal à l'objet actuel, sinon faux.</returns>
        public override bool Equals(object obj)
        {
            return obj is Projection uneProjection && this == uneProjection;
        }


    }
}
