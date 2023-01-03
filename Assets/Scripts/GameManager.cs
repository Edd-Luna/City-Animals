using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public int playerLifes;
    public Button reload;
    
    
    void start ()
    {
        playerScore = 0;
        playerLifes = 0;

        
    }


    public void GameOver()
    {
        Debug.Log("Player has collied with enemy, " + "Score: " + playerScore + "  Extra Lifes: " + playerLifes);
        TestBestPlayer();
        reload.gameObject.SetActive(true);
    }

    void TestBestPlayer()
    {
        if(playerScore > MenuManager.Instance.bestScore)
        {
            MenuManager.Instance.bestScore = playerScore;
            MenuManager.Instance.bestScoreName = MenuManager.Instance.playerName;

            MenuManager.Instance.SaveBestScore(MenuManager.Instance.bestScore, MenuManager.Instance.bestScoreName);
        }
        else
        {

        }
    }

    public void Reload()
    {
    SceneManager.LoadScene(0);
    playerScore = 0;
    }
}
