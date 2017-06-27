using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Ronda
    {
        //Hacer constructor, poner las props en false
        public Ronda(int repartidor)
        {
            this.Turno = repartidor;
            this.PrimeroQueJugo = repartidor;
            this.PuntosTruco = 1;
            this.Ganador = false;
            this.Truco = false;
            this.Retruco = false;
            this.Vale4 = false;
            this.Envido = false;
            this.EnvidoEnvido = false;
            this.RealEnvido = false;
            this.FaltaEnvido = false;
            this.Manos = 1;
            this.CartasEnMesa = new Cartas[3, 4] { {null,null,null,null}, { null, null, null, null }, { null, null, null, null } };


        }


        public bool Truco { get; set; }
        public bool Retruco { get; set; }
        public bool Vale4 { get; set; }
        public bool Envido { get; set; }
        public bool EnvidoEnvido { get; set; }
        public bool RealEnvido { get; set; }
        public bool FaltaEnvido { get; set; }
        public int Turno { get; set; }
        public int PrimeroQueJugo { get; set; }//Guarda el primer jugador en jugar, cuando vuelva a el cambia de mano
        public int PuntosTruco { get; set; }
        public int Manos { get; set; }
        public Cartas[,] CartasEnMesa { get; set; }
        public Equipo GanadorR1 { get; set; }
        public Equipo GanadorR2 { get; set; }
        public Equipo GanadorR3 { get; set; }
        public bool Ganador { get; set; }
        
        public void AumentarTurno()
        {
            this.Turno = this.Turno + 1;
            if (this.Turno>4)
            {
                this.Turno = 1;
            }

            //if (this.Turno == this.PrimeroQueJugo)
            //{
            //    this.Manos++;
            //}
        }

        public int GanadorMano(int mano)
        {
            int posicion = 0;
            int valor = 0;
            bool primero = true;

            for (int i = 0; i < 4; i++)
            {
                if (primero == true)
                {
                    primero = false;
                    posicion = i + 1; //Ya devuelve el numero de jugador
                    valor = this.CartasEnMesa[mano, i].ValorTruco;
                }

                if (this.CartasEnMesa[mano,i].ValorTruco > valor)
                {
                    valor = this.CartasEnMesa[mano, i].ValorTruco;
                    posicion = i + 1;
                }
            }
            return posicion;
        }

    }

    public class Mano
    {
        public Cartas CartaJ1 { get; set; }
        public Cartas CartaJ2 { get; set; }
        public Cartas CartaJ3 { get; set; }
        public Cartas CartaJ4 { get; set; }

   
        public String GanadorRonda(Cartas J1, Cartas J2, Cartas J3, Cartas J4)
        {
            if (J1.ValorTruco > J2.ValorTruco && J1.ValorTruco > J4.ValorTruco || J3.ValorTruco > J2.ValorTruco && J3.ValorTruco > J4.ValorTruco)
            {
                return "E1";
            }
            else
            {
                return "E2";
            }
        }

    }
}
