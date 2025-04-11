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
            if (strNom.Length < 3)
            {
                throw new ArgumentException("Le nom complet du client ne peut contenir moins de trois caractères.");
            }
            m_strNom = strNom;

            if (string.IsNullOrEmpty(strAdresse))
            {
                throw new ArgumentException("L'adresse est vide.");
            }
            m_strAdresse = strAdresse;

            //à modifier aprés avoir compléter la méthode Telephone
            m_strTelephone = strTelephone;

            m_lesTypesProjection = lesTypesProjections;
        }

        /// <summary>
        /// Accesseur (en lecture seulement) permet d'obtenir le nom du client.
        /// </summary>
        public string Nom
        {
            get
            {
                return m_strNom;
            }
        }

        /// <summary>
        /// /// <summary>
        /// Accesseur (en lecture et en écriture) permet d'obtenir l'adresse du client.
        /// </summary>
        /// </summary>
        public string Adresse
        {
            get
            {
                return m_strAdresse;
            }
            set
            {
                m_strAdresse = value;
            }
        }

        /// <summary>
        /// Propriété pour accéder et modifier le numéro de téléphone du client.
        /// Le numéro doit contenir exactement 10 chiffres et commencer par un indicatif régional valide (418 ou 581).
        /// Une exception est levée si le format est invalide.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Levée si la longueur n'est pas de 10 caractères, 
        /// si l'indicatif régional n'est pas 418 ou 581, 
        /// ou si le numéro contient des caractères non numériques.
        /// </exception>

        public string Telephone
        {
            get
            {
                return m_strTelephone;
            }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("La longueur du numéro de téléphone doit être exactement 10 chiffres.");
                }

                string codeRegion = value.Substring(0, 3);

                if (codeRegion != "418" && codeRegion != "581")
                {
                    throw new ArgumentException("Le numéro de téléphone doit être dans la région de Québec (418 ou 581).");
                }

                string numeroTelephone = value.Substring(3, 7);

                foreach (char c in numeroTelephone)
                {
                    if (!char.IsDigit(c))
                    {
                        throw new ArgumentException("Le numéro de téléphone contient un caractère invalide.");
                    }
                }

                m_strTelephone = value;
            }
        }



    }
}
