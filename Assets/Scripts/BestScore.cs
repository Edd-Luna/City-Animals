using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        MenuManager.Instance.LoadBestScore();

        if (MenuManager.Instance != null)
        {
            if (MenuManager.Instance.bestScore != 0)
            {
                bestScoreText.text = "Best Score: " + MenuManager.Instance.bestScore + " Player: " + MenuManager.Instance.bestScoreName;
            }
            else
            {
                bestScoreText.text = MenuManager.Instance.playerName + " set your score";
            }
        }
        else
        {
            bestScoreText.text = "Set your score";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
