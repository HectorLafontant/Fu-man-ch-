using System;
using System.Collections.Generic;

int players = 0;
bool isPlayerUp = true;
int up = 0;
int down = 0;

Console.WriteLine("\nBienvenido a FU-MAN-CHU.");

bool isValidPlayerNumber = false;
do
{
    Console.Write("\nDigite el numero de jugadores (minimo 3): ");

    // string playerInput = Console.ReadLine();
    // players = int.Parse(playerInput);
    while(!int.TryParse(Console.ReadLine(), out players))
    {
        Console.WriteLine("El valor ingresado no es valido.");
        Console.Write("Digite el numero de jugadores (minimo 3): ");
    }

    if (players < 3){
        Console.WriteLine("Numero de jugadores invalido.");
    }else{
        isValidPlayerNumber = true;
    }
} while (isValidPlayerNumber == false);

players -= 1;

bool disqualified = false;
do
{
    SetPlayerPosition();

    Random rnd = new Random();
    up = rnd.Next(players);
    down = players - up;

    if (isPlayerUp == true){
        up += 1;
    } else {
        down += 1;
    }
    Console.WriteLine("\nResultados: ");
    Console.WriteLine("Numero de jugadores con la palma hacia ARRIBA: " + up);
    Console.WriteLine("Numero de jugadores con la palma hacia ABAJO: " + down);

    Console.WriteLine("");

    disqualified = IsThePlayerDisqualified();
    if(disqualified == true){
        Console.WriteLine("Perdiste, eres parte de la minoria. Estas descalificado.\n");
    }else{
        if (isPlayerUp == true){
            Console.WriteLine("¡Ganaste! Se descalificaron {0} jugadores", down);
            players -= down;
        } else{
            Console.WriteLine("¡Ganaste! Se descalificaron {0} jugadores", up);
            players -= up;
        }
        if (players == 1){
            Console.WriteLine("\n¡Fin del juego! Solo quedan dos jugadores.\n");
            break;
        }
        Console.WriteLine("\nComienza una nueva ronda con {0} jugadores", players + 1);
    }
} while (disqualified == false);

void SetPlayerPosition(){

    bool isValidOption = true;
    int option = 0;
    do {

        Console.WriteLine("\n[1] Mostrar la mano con la palma hacia ARRIBA.");
        Console.WriteLine("[2] Mostrar la mano con la palma hacia ABAJO.");
        Console.Write("Seleccione una opcion: ");

        while(!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("El valor ingresado no es valido.");
            Console.WriteLine("\n[1] Mostrar la mano con la palma hacia ARRIBA.");
            Console.WriteLine("[2] Mostrar la mano con la palma hacia ABAJO.");
            Console.Write("Seleccione una opcion: ");
        }
        Console.WriteLine("");

        switch (option)
        {
            case 1:
                Console.WriteLine("Muestras la mano con la palma hacia ARRIBA.");
                isPlayerUp = true;
                isValidOption = true;
                break;
            case 2:
                Console.WriteLine("Muestras la mano con la palma hacia ABAJO.");
                isPlayerUp = false;
                isValidOption = true;
                break;
            default:
                Console.WriteLine("Opcion inexistente.");
                isValidOption = false;
                break;
        }
    } while (isValidOption == false);
}

bool IsThePlayerDisqualified() {
    return ((up < down) && (isPlayerUp == true)) || ((down < up) && (isPlayerUp == false));
}