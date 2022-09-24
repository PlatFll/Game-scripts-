using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePanelController : MonoBehaviour
{

    public Animator panelAnim;
    public Animator gameInfoAnim;
    private EndGameManager endGameManager; //self added


    public void OK()
    {
        if(panelAnim != null && gameInfoAnim != null)
        {
            panelAnim.SetBool("Out",true);
            gameInfoAnim.SetBool("Out",true);
            endGameManager.startGame = true; //self added
            StartCoroutine(GameStartCo());
        }
    }

    public void GameOver()
    {
        panelAnim.SetBool("Out", false);
        panelAnim.SetBool("Game Over", true);
    }

    void Start()
    {
        endGameManager = FindObjectOfType<EndGameManager>(); //self added
    }

    IEnumerator GameStartCo()
    {
        yield return new WaitForSeconds(1f);
        The_Board board = FindObjectOfType<The_Board>();
        board.currentState = GameState.move;
    }

}
