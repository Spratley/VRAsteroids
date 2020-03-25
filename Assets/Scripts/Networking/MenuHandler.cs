using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Button singlePlayerBut;
    public Button multiplayerJoinBut;
    public Button multiplayerHostBut;
    public InputField usernameInput;
    public InputField ipInput;
    public Text waitingText;

    public void SinglePlayer()
    {
        //Set up singleplayer
        GameManager.m_instance.LoadSingleplayer();
    }

    public void MultiplayerHost()
    {
        //Set up hosting
        GameManager.m_networkingManager.StartServer();
        bool clientStat = GameManager.m_networkingManager.StartClient();

        if (clientStat)
        {
            GameManager.m_multiplayer = true;

            singlePlayerBut.interactable = false;
            multiplayerJoinBut.interactable = false;
            multiplayerHostBut.interactable = false;
            usernameInput.interactable = false;
            ipInput.interactable = false;
            waitingText.gameObject.SetActive(true);
            waitingText.text = "Waiting for other players...";
        }

        //StartCoroutine(WaitInLobby());
    }

    public void MultiplayerJoin()
    {
        //Create client
        bool clientStat = GameManager.m_networkingManager.StartClient();

        if (clientStat)
        {
            GameManager.m_multiplayer = true;

            singlePlayerBut.interactable = false;
            multiplayerJoinBut.interactable = false;
            multiplayerHostBut.interactable = false;
            usernameInput.interactable = false;
            ipInput.interactable = false;
            waitingText.gameObject.SetActive(true);
            waitingText.text = "Joining other players";

        }

        //StartCoroutine(WaitInLobby());
    }

    public void Quit()
    {
        //Quit game
        Application.Quit();
    }
}
