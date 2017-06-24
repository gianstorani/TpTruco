using System;
using System.Collections.Generic;
using System.Text;
using static TpTruco.Entidades.Mazo;

namespace TpTruco.Entidades
{

    public class Cartas
    { 
        public bool Dispobile { get; set; }
        public string Codigo { get; set; }
        public int ValorTruco { get; set; }
        public int ValorEnvido { get; set; }
        public Palos Palo { get; set; }

        public Cartas(string codigo, int valor, int valorenvido, Palos palo)
        {
            this.Dispobile = true;
            this.Codigo = codigo;
            this.ValorTruco = valor;
            this.ValorEnvido = valorenvido;
            this.Palo = palo;
        }
    
    }
}
