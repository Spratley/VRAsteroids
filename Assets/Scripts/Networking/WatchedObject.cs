using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchedObject : MonoBehaviour
{
    public void SendPosition()
    {
        //Send position
        NetworkManager.SendFloat(transform.position.x);
        NetworkManager.SendFloat(transform.position.y);
        NetworkManager.SendFloat(transform.position.z);
    }
}
