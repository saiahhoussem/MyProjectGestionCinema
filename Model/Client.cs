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
    }
}
