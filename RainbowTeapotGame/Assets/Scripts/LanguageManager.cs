using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{

    public enum language {English, Spanish}
    private language mLang;

    public enum word {Name, EnterName, Login, Training, Multiplayer, Credits, Configuration, Music, Sound, Language,
        ChooseRider,Start, TryingToJoin,  LeaveGame, StartGame, Ready, GameStarts, Player
    }
    private word mWord;


    string[,] names = new string[2, 18] {

        {"Name", "Enter player's name", "Login", "Training", "Multiplayer", "Credits", "Configuration", "Music" , "Sound", "Language",
        "Choose your rider", "Start", "Trying to join room...",  "Leave game", "Start game", "Ready?","Game starts in", "Player"}, //Eng
        {"Nombre", "Introduce el nombre", "Iniciar sesión", "Entrenamiento", "Multijugador", "CrÉditos", "Configuración", "Música", "Sonido",
        "Idioma", "Elige a tu corredor", "Empezar", "Intentando entrar en la sala...",  "Abandonar partida", "Empezar partida", "¿Preparado?", "El juego comienza en" , "Jugador"} //Spa

    };


    public string getText(int i, int j) {        

        return names[i, j];
    }

   
    
}
