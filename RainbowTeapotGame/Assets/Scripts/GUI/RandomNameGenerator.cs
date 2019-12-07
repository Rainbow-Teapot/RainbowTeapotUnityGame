using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNameGenerator : MonoBehaviour
{
    private readonly string[] userName = { "Ok", "Happy", "Dark", "Spooky", "Holy", "Wholesome", "Kawaii", "Sad",
            "Edgy", "Bad", "Rainbow", "Main", "Already", "Concurrent", "Flying", "Screaming", "Kinky", "Baka"};

    private readonly string[] userSurName = { "Boomer", "Cat", "Whale" , "Paquito", "Diego", "Pizza", "Boy", "Fofi",
            "Pipo", "Potato", "Taurus", "Sagittarius","Leo", "Bunny", "Teapot","Scorpio","Tracer", "Chapel", "Square"};

    public string GetRandomPlayerName()
    {
        return userName[Random.Range(0, userName.Length)] + "_" + userSurName[Random.Range(0, userSurName.Length)] + "_"  
            + Random.Range(0, 100);
    }
}
