//***************************************************************************************
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

        public Client(string strNom, string strAdresse, string strTelephone, List<TypeProjection> lesTypesProjections)
        {
            if(strNom.Length < 3)
            {
                throw new ArgumentException("Le nom complet du client ne peut contenir moins de trois caractères.");
            }
            m_strNom = strNom;

            if(strAdresse == "")
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
