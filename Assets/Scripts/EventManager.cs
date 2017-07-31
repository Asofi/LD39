using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void GameEvent();

    public static event GameEvent OnGameStart, OnGameOver;

    public static void GameOver() {
        if (OnGameOver != null) OnGameOver();
    }

    public static void GameStart() {
        if (OnGameStart != null) OnGameStart();
    }

}
