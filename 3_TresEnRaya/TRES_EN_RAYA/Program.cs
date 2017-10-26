using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRES_EN_RAYA
{
    class TresEnRaya
    {
        //ATRIBUTOS//

        /// <summary>
        /// atributo tablero
        /// </summary>
        public string[,] tablero;


        /// <summary>
        /// atributo posicion
        /// </summary>
        public int posicion;
        

        //las coordenadas de la matriz//
        int[] PosicionFilas = new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        int[] PosicionColumnas = new int[] { 0, 1, 2, 0, 1, 2, 0, 1, 2 };

        //CONSTRUCTORES//

        /// <summary>
        /// constructor que inicia el array y lo pone a cero
        /// </summary>
        public TresEnRaya()
        {
            tablero = new string[3,3];
            for (int i = 0; i < tablero.GetLength(0); i++)
            {            
                for(int j=0; j<tablero.GetLength(1);j++)
                {
                    tablero[i, j] = " ";
                }               
            }
        }

        //POPIEDADES Y METODOS//

        /// <summary>
        /// metodo para saber si el movimiento es valido
        /// </summary>
        /// <param name="posicion">posicion del movimiento</param>
        /// <returns>devuelve true si se puede mover a esa posicion o false si no</returns>
        public bool MovimientoValido(int posicion)
        {
            if(tablero[PosicionFilas[posicion],PosicionColumnas[posicion]]==" ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// se rellena una casilla del primer jugador con una X
        /// </summary>
        /// <param name="posicion"></param>
        public void MueveJugador1(int posicion)
        {
           int n;
           if(MovimientoValido(posicion))
            {
                tablero[PosicionFilas[posicion], PosicionColumnas[posicion]] = "X";

            }
           else
            {
                Console.WriteLine("casilla ocupada");
                Console.WriteLine("elige otra casilla");
                n = int.Parse(Console.ReadLine());
                while(MovimientoValido(n)==false)
                {
                    Console.WriteLine("casilla ocupada");
                    Console.WriteLine("elige otra casilla");
                    n = int.Parse(Console.ReadLine());

                }
                tablero[PosicionFilas[n], PosicionColumnas[n]] = "X";
            }
        }

        /// <summary>
        /// se rellena una casilla del segundo jugador con O
        /// </summary>
        /// <param name="posicion"></param>
        public void MueveJugador2(int posicion)
        {
            int n;
            if (MovimientoValido(posicion))
            {
                tablero[PosicionFilas[posicion], PosicionColumnas[posicion]] = "O";

            }
            else
            {
                Console.WriteLine("casilla ocupada");
                Console.WriteLine("elige otra casilla");
                n = int.Parse(Console.ReadLine());
                while (MovimientoValido(n) == false)
                {
                    Console.WriteLine("casilla ocupada");
                    Console.WriteLine("elige otra casilla");
                    n = int.Parse(Console.ReadLine());
                }
                tablero[PosicionFilas[n], PosicionColumnas[n]] = "O";
            }
        }
        /// <summary>
        /// metodo que limpia el tablero para volver a jugar
        /// </summary>
        public void Iniciar()
        {
           
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(0); j++)
                {
                    tablero[i, j] = " ";
                }
            }
        }

        /// <summary>
        /// nos dice si quedan movimientos en el tablero
        /// </summary>
        /// <returns>true si hay espacios libres</returns>
        public bool QuedanMovimientos()
        {
            int i, j;
            int n = 0;

            for (i = 0; i < tablero.GetLength(0); i++)
            {
                for (j = 0; j < tablero.GetLength(1); j++)
                {
                    if (tablero[i, j] == " ")
                    {
                        n++;
                    }
                }
            }
            if(n>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// método que nos devuelve true si hay tres X en linea
        /// </summary>
        /// <returns></returns>
        public bool GanaJugador1()
        {
            int i;
            int cont = 0;
            for (i = 0; i < 3; i++)
            {

                if ((tablero[i, 0] == "X" && tablero[i, 1] == "X" && tablero[i, 2] == "X"))
                {
                    cont++;
                }

                if ((tablero[0,i] == "X" && tablero[1,i] == "X" && tablero[2,i] == "X"))
                {
                    cont++;
                }

                if ((tablero[0,0] == "X" && tablero[1,1] == "X" && tablero[2,2] == "X"))
                {
                    cont++;
                }
                if ((tablero[0, 2] == "X" && tablero[1,1] == "X" && tablero[2,0] == "X"))
                {
                    cont++;
                }            
            }
            if (cont > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// método que nos devuelve true si hay tres O en linea
        /// </summary>
        /// <returns></returns>
        public bool GanaJugador2()
        {
            int i;
            int cont = 0;
            for (i = 0; i < 3; i++)
            {

                if ((tablero[i, 0] == "O" && tablero[i, 1] == "O" && tablero[i, 2] == "O"))
                {
                    cont++;
                }

                if ((tablero[0, i] == "O" && tablero[1, i] == "O" && tablero[2, i] == "O"))
                {
                    cont++;
                }

                if ((tablero[0, 0] == "O" && tablero[1, 1] == "O" && tablero[2, 2] == "O"))
                {
                    cont++;
                }
                if ((tablero[0, 2] == "O" && tablero[1, 1] == "O" && tablero[2, 0] == "O"))
                {
                    cont++;
                }
            }
            if (cont > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// imprime el tablero en la pantalla
        /// </summary>
        public void DibujaTablero()
        {
            int i, j;
            Console.WriteLine("----------------");
            
            for (i = 0; i < tablero.GetLength(0); i++)
            {
                Console.Write("|");
                for (j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.Write(" " + tablero[i, j] + "  |");
                }
                Console.WriteLine("");
                Console.WriteLine("----------------");
                
            }

        }

        /// <summary>
        /// método para que el ordenador ponga una X de manera aleatoria
        /// </summary>
        public void MueveOrdenador1()
        {
            Random r = new Random();
            int n = r.Next(0,8);

            if(MovimientoValido(n))
            {
                tablero[PosicionFilas[n], PosicionColumnas[n]] = "X";
            }
            else
            {
                while(MovimientoValido(n)==false)
                {
                    n = r.Next(0,8);
                }
            }
            tablero[PosicionFilas[n], PosicionColumnas[n]] = "X";
        }

        /// <summary>
        /// método para que el ordenador ponga un O de manera aleatoria
        /// </summary>
        public void MueveOrdenador2()
        {
            Random r = new Random();
            int n = r.Next(0,8);

            if (MovimientoValido(n))
            {
                tablero[PosicionFilas[n], PosicionColumnas[n]] = "O";
            }
            else
            {
                while (MovimientoValido(n) == false)
                {
                    n = r.Next(0,8);
                }
            }
            tablero[PosicionFilas[n], PosicionColumnas[n]] = "O";
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int jugador1, jugador2;
            

            Console.WriteLine("escribe 0 si JUGADOR1=MAQUINA o 1 si juega una PERSONA");
            jugador1 = int.Parse(Console.ReadLine());
            Console.WriteLine("escribe 0 si JUGADOR2=MAQUINA o 1 si juega una PERSONA");
            jugador2 = int.Parse(Console.ReadLine());

           
            TresEnRaya tablero = new TresEnRaya();           
            Console.WriteLine();

            while(tablero.QuedanMovimientos() && !(tablero.GanaJugador1()) && !(tablero.GanaJugador2()))
            {
                if(jugador1==0)
                {
                    tablero.MueveOrdenador1();
                    tablero.DibujaTablero();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("turno jugador1");
                    int posicion = int.Parse(Console.ReadLine());
                    tablero.MueveJugador1(posicion);
                    tablero.DibujaTablero();
                    Console.WriteLine();
                }

                if(tablero.QuedanMovimientos() && !(tablero.GanaJugador1()) && !(tablero.GanaJugador2()))
                {
                    if (jugador2 == 0)
                    {
                        tablero.MueveOrdenador2();
                        tablero.DibujaTablero();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("turno jugador2");
                        int posicion = int.Parse(Console.ReadLine());
                        tablero.MueveJugador2(posicion);
                        tablero.DibujaTablero();
                        Console.WriteLine();
                    }
                }              
            }

            if(tablero.GanaJugador1())
            {
                Console.WriteLine("gana el jugador1");

            }
            else
            {
                if(tablero.GanaJugador2())
                {
                    Console.WriteLine("gana el jugdor2");
                }
                else
                {
                    Console.WriteLine("empate");
                }
            }

            Console.ReadKey();
        }
    }
}
