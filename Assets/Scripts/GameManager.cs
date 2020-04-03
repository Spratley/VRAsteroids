using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData
{
    public string name;
    public int id;
    public int score;
}


public class GameManager : MonoBehaviour
{
    public static GameManager m_instance;

    private void Awake()
    {
        m_instance = this;

        //Loads cinematic screen
        SceneManager.LoadSceneAsync((int)SceneIndexes.CINEMATIC_SCREEN, LoadSceneMode.Additive);
    }

    private void Update()
    {
       
    }

    public void LoadGame()
    {
        //Unloads cinematic scene
        SceneManager.UnloadSceneAsync((int)SceneIndexes.CINEMATIC_SCREEN);
        //Loads the main game scene
        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_GAME, LoadSceneMode.Additive);
    }
}
