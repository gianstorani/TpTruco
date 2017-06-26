using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Mano
    {
        public bool Truco { get; set; }
        public bool Retruco { get; set; }
        public bool Vale4 { get; set; }
        public bool Envido { get; set; }
        public bool EnvidoEnvido { get; set; }
        public bool RealEnvido { get; set; }
        public bool FaltaEnvido { get; set; }
        public int Turno { get; set; }

        public void AumentarTurno()
        {
            Turno = Turno + 1;
            if (Turno>4)
            {
                Turno = 1;
            }
        }

        //public void 



        //Hacer constructor, poner las props en false

    }
}
