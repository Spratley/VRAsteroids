using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WatchedObject : MonoBehaviour
{
    public bool m_owned = false;

    public bool m_updatePos = false;
    public bool m_updateRot = false;
    public bool m_updateVel = false;

    public string m_objectID = "00";
    public string m_finalObjectID;

    float m_sendTimer = 0.0f;
    public static float m_sendInterval = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        //example object id
        //0101
        //Object 1 from client 1
    }

    private string PackageVector(Vector3 vec, string packetType)
    {
        string temp = packetType + GameManager.m_thisPlayer.id.ToString() +
                ';' + m_finalObjectID + ';' + vec.x.ToString() + ';' +
                    vec.y.ToString() + ';' + vec.z.ToString();

        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.m_multiplayer)
        {
            if (m_owned)
            {
                m_finalObjectID = "0" + GameManager.m_thisPlayer.id + m_objectID;
            }
            else
            {
                m_finalObjectID = "0" + GameManager.m_otherPlayers[0].id + m_objectID;
            }


            m_sendTimer += Time.deltaTime;

            if (m_sendTimer > m_sendInterval)
            {
                if (m_updatePos)
                {
                    Vector3 pos = gameObject.transform.position;
                    //p;userID;objectID;posX;posy;posZ
                    GameManager.m_networkingManager.SendPacketToServer(PackageVector(pos, "p;"));
                }

                if (m_updateRot)
                {
                    Vector3 rot = gameObject.transform.rotation.eulerAngles;
                    //p;userID;objectID;posX;posy;posZ
                    GameManager.m_networkingManager.SendPacketToServer(PackageVector(rot, "r;"));
                }

                if (m_updateVel)
                {
                    Vector3 vel = gameObject.GetComponent<Rigidbody>().velocity;
                    //p;userID;objectID;posX;posy;posZ
                    GameManager.m_networkingManager.SendPacketToServer(PackageVector(vel, "v;"));
                }

                m_sendTimer = 0.0f;
            }

            if (Input.GetKey(KeyCode.Alpha1))
            {
                m_sendInterval += (2.0f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                m_sendInterval -= (2.0f * Time.deltaTime);
                if (m_sendInterval < 0.0f)
                {
                    m_sendInterval = 0.0f;
                }
            }
        }
    }
}
