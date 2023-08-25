using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public Button btnStart, btnNextLevel;
    public GameObject menuUI, inGameUI, endGameUI;


    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        SetBandings();
    }

    private void SetBandings()
    {
        btnStart.onClick.AddListener(() =>
        {
            _gameManager.StartGame();
            menuUI.SetActive(false);
        });
        btnNextLevel.onClick.AddListener(() =>
        {
            _gameManager.StartNextGame();
            endGameUI.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EndGame()
    {
        endGameUI.SetActive(true);
    }
}