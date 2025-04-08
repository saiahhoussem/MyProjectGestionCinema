using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitaires
{
    public static class Aleatoire
    {
        // Attribut permettant la génération de nombres aléatoires.
        private static Random g_rndGenerateur = new Random();

        /// <summary>
        /// Génère un nombre entier aléatoire en fonction des paramètres reçus

        /// ///  <param name="iBorneSuperieure">
        /// Représente la valeur maximale désirée.
        /// </param>
        /// <returns>
        /// Retourne un nombre positif entre 0 et la borne supérieure inclusivement
        /// </returns>
        public static int GenererNombre(int iBorneSuperieure)
        {

            return g_rndGenerateur.Next(iBorneSuperieure + 1);
        }
    }
}
