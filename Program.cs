//Aby zaimportować Raylib, wejdź w Terminal -> New Terminal i użyj:
//dotnet add package Raylib-cs 

using System.Numerics;
using Raylib_cs;
using Space_Invaders_starter.Utils;
using Space_Invaders_starter.Managers;

namespace Space_Invaders_starter;

class Program
{
    static void Main(string[] args)
    {
        //TODO: inicjalizacja okna gry 
        Raylib.InitWindow(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT, "Space Invaders");
        Raylib.SetTargetFPS(60);

        GameManager.Initialize();
        
        while (!Raylib.WindowShouldClose())
        {
            //TODO: Wywołanie menadzera gry 
            GameManager.Update();
            GameManager.Draw();
        }
        Raylib.CloseWindow();
      
    }
}
