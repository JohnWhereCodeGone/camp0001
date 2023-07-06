using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Action<bool> toggle;
    [SerializeField]
    public bool isPaused;
    private static GameManager instance;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pauseGame();
        }
    }
    private void pauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = 
            isPaused ? //We check this bool if it's true
            0 : // true
            1; // false
        toggle?.Invoke(isPaused);

    }
    public static void SubscribeToPause(Action<bool> _Subscribe)
    {
        Debug.Log("I subscribed" +  _Subscribe);
        toggle += _Subscribe;
    }
    public static void UnSubscribeToPause(Action<bool> _UnSubscribe)
    {
        toggle -= _UnSubscribe;
    }
}
