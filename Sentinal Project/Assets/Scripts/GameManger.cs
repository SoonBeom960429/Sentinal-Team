using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }
     private enum State
    {
        WaittingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waittingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;

    private void Awake()
    {
        instance = this;
        state = State.WaittingToStart; 
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaittingToStart:
                waittingToStartTimer -= Time.deltaTime;
                if (waittingToStartTimer <= 0f)
                {
                    state = State.CountdownToStart;
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer <= 0f)
                {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                waittingToStartTimer -= Time.deltaTime;
                if (waittingToStartTimer <= 0f)
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
}