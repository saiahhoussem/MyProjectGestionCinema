﻿//***************************************************************************************
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
        public enum TypeProjection
        {
            Standard,
            _3D,
            IMAX,
            _4DX
        }

        private const int PRIX_PLACE_MIN = 10;

        private DateTime m_dteDateProjection;
        private string m_strNomSalleProjection;
        private TypeProjection m_leTypeProjection;
        private int m_iNbrPlaces;
        private int m_iNbrReservations;

        /// <summary>
        /// Constructeur de la classe Projection qui permet d'initialiser les attributs à l'aide des paramètres reçus.
        /// </summary>
        /// <param name="leTypeProjection"></param>
        /// <param name="nomSalleProjection"></param>
        /// <param name="dateProjection"></param>
        public Projection(TypeProjection leTypeProjection, string nomSalleProjection, DateTime dateProjection)
        {
            m_leTypeProjection = leTypeProjection;
            m_strNomSalleProjection = nomSalleProjection;
            m_dteDateProjection = dateProjection;

            // Générer un nombre aléatoire de places entre 10 et 100
            m_iNbrPlaces = Aleatoire.GenererNombre(91) + 10;

            // Initialiser les réservations à 0
            m_iNbrReservations = 0;
        }


    }
}
