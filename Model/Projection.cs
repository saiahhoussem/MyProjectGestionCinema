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

namespace MyProjectGestionCinema.Model
{
    public class Projection
    {
        private enum TypeProjection
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

    }
}
