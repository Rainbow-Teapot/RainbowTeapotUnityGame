﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager
{

    public enum language {English, Spanish}
    private language mLang;

    public enum word {Name, EnterName, Login, Training, Multiplayer, Credits, Configuration, Music, Sound, Language,
        ChooseRider,Start, TryingToJoin,  LeaveGame, StartGame, Ready, GameStarts, Player, ReturnMenu, MessageReady, MessageStarGame, Options, ComeBack, Brake
    }
    private word mWord;


    string[,] names = new string[2, 25] {

        {"Name", "Enter player's name", "Login", "Training", "Multiplayer", "Credits", "Configuration", "Music" , "Sound", "Language",
        "Choose your rider", "Start", "Trying to join room...",  "Leave game", "Start game", "Ready?","Game starts in", "Player", "Return to menu",
        "Press the ready button whenerver you are ready", "Press the start game button when all players are ready, dont leave anyone behind!", "Options",
            "Slide right and left to move, double tap to activate power-downs", "Come back soon", "Brake to win"}, //Eng
        {"Nombre", "Introduce el nombre", "Iniciar sesión", "Entrenamiento", "Multijugador", "CrÉditos", "Configuración", "Música", "Sonido",
        "Idioma", "Elige a tu corredor", "Empezar", "Intentando entrar en la sala...",  "Abandonar partida", "Empezar partida", "¿Preparado?",
            "El juego comienza en" , "Jugador", "Volver al menú", "Presiona el botón de preparado cuando lo estés",
            "Presiona el botón de empezar partida cuando todos los jugadores estén listos, ¡no te dejes a nadie!", "Opciones",
            "Desliza a derecha e izquierda para moverte, doble tap para activar los power-downs", "Vuelve pronto", "Frena para ganar"} //Spa

    };


    public string getText(int i, int j) {        

        return names[i, j];
    }

   
    
}
