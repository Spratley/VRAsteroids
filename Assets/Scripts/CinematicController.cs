using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CinematicController : MonoBehaviour
{
    public VideoPlayer m_cinematic;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.m_instance != null)
        {
            //Checks if time passed is greater than the cinematic length
            if (Time.timeSinceLevelLoad >= m_cinematic.clip.length)
            {
                GameManager.m_instance.LoadGame();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.m_instance.LoadGame();
            }
        }
        else
        {
            Debug.Log("You didn't launch from the persistent scene.");
        }
    }
}
