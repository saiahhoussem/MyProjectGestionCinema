﻿//***************************************************************************************
//  + Nom du fichier: Client.cs
//  + Nom de la classe: Client
//  + Description du rôle du fichier: Cette classe représente les abonnés au cinéma.
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
    public class Client
    {
        private string m_strNom;
        private string m_strAdresse;
        private string m_strTelephone;
        private List<TypeProjection> m_lesTypesProjection = new List<TypeProjection>();

        /// <summary>
        ///  Constructeur de la classe Client. Permet d'initialiser un client avec les informations fournies.
        /// </summary>
        /// <param name="strNom">Nom du client.</param>
        /// <param name="strAdresse">Adresse du client.</param>
        /// <param name="strTelephone">Numéro de téléphone du client.</param>
        /// <param name="lesTypesProjections">Liste des types de projections que le client préfère</param>
        /// <exception cref="ArgumentException">
        /// Est levée si: - le nom contient moins de trois caractères
        ///               - l'adresse est vide
        ///               - le numéro de téléphone est invalide
        /// </exception>
        public Client(string strNom, string strAdresse, string strTelephone, List<TypeProjection> lesTypesProjections)
        {
            if(strNom.Length < 3)
            {
                throw new ArgumentException("Le nom complet du client ne peut contenir moins de trois caractères.");
            }
            m_strNom = strNom;

            if(string.IsNullOrEmpty(strAdresse))
            {
                throw new ArgumentException("L'adresse est vide.");
            }
            m_strAdresse = strAdresse;

            //à modifier aprés avoir compléter la méthode Telephone
            m_strTelephone = strTelephone;

            m_lesTypesProjection = lesTypesProjections;
        }
    }
}
