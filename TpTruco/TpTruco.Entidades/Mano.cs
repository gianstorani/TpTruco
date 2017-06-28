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
            this.EstadoTruco = "";
            this.EstadoEnvido = "";
            this.NumeroMano = 1;
            this.CartasEnMesa = new Cartas[3, 4] { {null,null,null,null}, { null, null, null, null }, { null, null, null, null } };
            this.GanadorR1 = "";
            this.GanadorR2 = "";
            this.GanadorR3 = "";
            this.EnvidoMayor = 0;
        }

        
        public string EstadoTruco { get; set; }
        public string EstadoEnvido { get; set; }
        public int Turno { get; set; }
        public int PrimeroQueJugo { get; set; }//Guarda el primer jugador en jugar, cuando vuelva a el cambia de mano
        public int PuntosTruco { get; set; }
        public int EnvidoMayor { get; set; }
        public string IDCantador { get; set; }
        public int NumeroMano { get; set; }
        public Cartas[,] CartasEnMesa { get; set; }
        public string GanadorR1 { get; set; }
        public string GanadorR2 { get; set; }
        public string GanadorR3 { get; set; }
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
            //    this.NumeroMano++;
            //}
        }

        public int GanadorMano(int mano)
        {
            int posicion = 0;
            int valor = 0;
            bool primero = true;
            bool parda = false;

            for (int i = 0; i < 4; i++)
            {
                if (primero == true)
                {
                    primero = false;
                    posicion = i + 1; //Ya devuelve el numero de jugador
                    valor = this.CartasEnMesa[mano, i].ValorTruco;
                }
                else
                {
                    if (this.CartasEnMesa[mano, i].ValorTruco == valor)
                    {
                        parda = true;
                    }

                    if (this.CartasEnMesa[mano, i].ValorTruco > valor)
                    {
                        valor = this.CartasEnMesa[mano, i].ValorTruco;
                        posicion = i + 1;
                        parda = false;
                    }
                    
                }
            }
            if (parda == true)
            {
                return 10;
            }
            else
            {
                return posicion;
            }
        }

        public string GanadorRonda()
        {
            if (this.GanadorR1 == "E")//Parda en primera-GanadorR2
            {
                return GanadorR2;
            }

            if (this.GanadorR2 == "E")//Parda en segunda-GanadorR1
            {
                return GanadorR1;
            }

            if (this.GanadorR3 == "E") //Parda en 3era-GanadorR1
            {
                return GanadorR1;
            }

            if (this.GanadorR1 == this.GanadorR2)
            {
                return GanadorR1;
            }
            else
            {
                if (GanadorR3 != "")
                {
                    return GanadorR3;
                }
                else
                {
                    return "";
                }
            }
            

        }

        public void SumarPuntos(Equipo equipo)
        {
            equipo.Puntos += this.PuntosTruco;
        }

        //public void SumarEnvido (int equipo, string estado)
        //{
        //    if (equipo ==1)
        //    {
        //        switch (estado)
        //        {
        //            case "envido": 
                        
                
        //        break;
        //            default:
        //                break;
        //        }
                
        //    }
        //    //else
        //    {

        //    }
        //}

    }

    //public class Mano
    //{
    //    public Cartas CartaJ1 { get; set; }
    //    public Cartas CartaJ2 { get; set; }
    //    public Cartas CartaJ3 { get; set; }
    //    public Cartas CartaJ4 { get; set; }

   
    //    public String GanadorRonda(Cartas J1, Cartas J2, Cartas J3, Cartas J4)
    //    {
    //        if (J1.ValorTruco > J2.ValorTruco && J1.ValorTruco > J4.ValorTruco || J3.ValorTruco > J2.ValorTruco && J3.ValorTruco > J4.ValorTruco)
    //        {
    //            return "E1";
    //        }
    //        else
    //        {
    //            return "E2";
    //        }
    //    }

    //}
}
