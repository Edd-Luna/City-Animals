using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private string input;

    public void StorePlayerName(string inputName)
    {
        Debug.Log(inputName);
        MenuManager.Instance.playerName = inputName;
    }

}
