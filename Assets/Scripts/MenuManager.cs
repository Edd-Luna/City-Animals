using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string playerName;
    public int currentScore; // new variables 

    public int bestScore;
    public string bestScoreName; // varibles saved

    private void Awake()
    {
            // start of new code
        if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadBestScore();
    }


// DATA PERSISTENCE 
    [System.Serializable]
    class SaveData
    {

    public int bestScore;
    public string bestScoreName;

    }

    public void SaveBestScore( int currentScore, string playerName)
    {
    SaveData data = new SaveData();
    data.bestScore = currentScore;
    data.bestScoreName = playerName;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        bestScore = data.bestScore;
        bestScoreName = data.bestScoreName;
    }
    }
}
