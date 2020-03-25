using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class MeteorRushGameManager : MonoBehaviour
{
    public ShipComponents m_player1;
    public ShipComponents m_player2;

    private void Awake()
    {
        if (!GameManager.m_multiplayer)
        {
            m_player2.gameObject.SetActive(false);
        }
        else
        {
            if (GameManager.m_player2) 
            {
                m_player1.m_shipInterior.SetActive(false);
                m_player2.m_shipInterior.SetActive(true);
            }
        }
    }
}
