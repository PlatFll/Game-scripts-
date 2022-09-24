using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum GameType
{
    Moves,
    Time
}


[System.Serializable]
public class EndGameRequirements
{
    public GameType gameType;
    public int counterValue;
}

public class EndGameManager : MonoBehaviour
{

    public GameObject youWinPanel;
    public GameObject youLostPanel;
    public TextMeshProUGUI counter;
    public EndGameRequirements requirements;
    public int currentCounterValue;
    private float timerSeconds;
    private The_Board board;
    public bool startGame = false; //self added

    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<The_Board>();
        SetupGame();
    }

    void SetupGame()
    {

        currentCounterValue = requirements.counterValue;
        if(requirements.gameType == GameType.Time)
        {
            timerSeconds = 1;

        }
        /*else 
        {
            
        }*/
        counter.text = "" + currentCounterValue;
    }

    public void DecreaseCounterValue()
    {
        if(board.currentState != GameState.pause)
        {
            currentCounterValue--;
            counter.text = "" + currentCounterValue;
            if(currentCounterValue <= 0)
            {
                LoseGame();

            }
        }
        
        
        
    }

    public void WinGame()
    {
        youWinPanel.SetActive(true);
        board.currentState = GameState.win;
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
        FadePanelController fade = FindObjectOfType<FadePanelController>();
        fade.GameOver();
    }

    public void LoseGame()
    {
        youLostPanel.SetActive(true);
        board.currentState = GameState.lose;
        Debug.Log("You Lose!");
        currentCounterValue = 0;
        counter.text = "" + currentCounterValue;
        FadePanelController fade = FindObjectOfType<FadePanelController>();
        fade.GameOver();
    }
    // Update is called once per frame
    void Update()
    {
        if(requirements.gameType == GameType.Time && currentCounterValue > 0 && startGame)
        {
            timerSeconds -= Time.deltaTime;
            if(timerSeconds <= 0)
            {
                DecreaseCounterValue();
                timerSeconds =1;
            }
        }
    }
}
