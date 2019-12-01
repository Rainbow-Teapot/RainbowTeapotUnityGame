using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{

    public enum language {English, Spanish}
    private language mLang;

    public enum word {Name, EnterName, Login, Training, Multiplayer, Credits, Configuration, Music, Sound, Language,
        ChooseRider,Start, Ready,  TryingToJoin, LeaveGame, StartGame, GameStarts}
    private word mWord;


    string[,] names = new string[2, 16] {

        {"Name", "Enter player's name", "Login", "Training", "Multiplayer", "Credits", "Configuration", "Music" , "Sound", "Language",
        "Choose your rider", "Ready?", "Trying to join room...", "Leave game", "Start game", "Game starts in"}, //Eng
        {"Nombre", "Introduce el nombre", "Iniciar sesión", "Entrenamiento", "Multijugador", "Créditos", "Configuración", "Música", "Sonido",
        "Idioma", "Elige a tu corredor", "¿Preparado?", "Intentando entrar en la sala...", "Abandonar partida", "Empezar partida", "El juego comienza en" } //Spa

    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
