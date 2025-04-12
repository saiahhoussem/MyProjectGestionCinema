using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectGestionCinema.Model
{
    public struct StatistiquesSalle
    {
        public string NomSalle { get; set; }
        public decimal MontantMensuel { get; set; }

        public StatistiquesSalle(string nomSalle, decimal montantMensuel)
        {
            NomSalle = nomSalle;
            MontantMensuel = montantMensuel;
        }

        public override string ToString()
        {
            return $"{NomSalle} : {MontantMensuel}$";
        }
    }

}
