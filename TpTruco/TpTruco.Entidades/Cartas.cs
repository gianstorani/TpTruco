using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{

    public class Cartas
    { 
        public bool Dispobile { get; set; }
        public string Codigo { get; set; }
        public int Valor { get; set; }

        public Cartas(string codigo, int valor)
        {
            this.Dispobile = true;
            this.Codigo = codigo;
            this.Valor = valor;
        }
    
    }
}
