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




    }
}
