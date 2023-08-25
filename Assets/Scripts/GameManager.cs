using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,
    Pause,
    End
}

public class GameManager : MonoBehaviour
{
    private LevelManager _levelManager;

    public GameState currentGameState;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _levelManager = GetComponent<LevelManager>();
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
        currentGameState = GameState.Pause;
    }


    public void StartGame()
    {
        currentGameState = GameState.Start;
        _levelManager.StartLevel();
    }

    public void StartNextGame()
    {
        currentGameState = GameState.Start;
        _levelManager.StartNextLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextGame();
        }
    }


    public void EndGame()
    {
        _levelManager.EndLevel();
        _uiManager.EndGame();
        currentGameState = GameState.End;
        print("Level tamamlandı");
    }
}