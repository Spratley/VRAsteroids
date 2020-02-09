using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NetworkManager : MonoBehaviour
{
    private float m_time = 0.0f;
    public float sendInterval = 30.0f;

    public string ip;

    public List<WatchedObject> watchedObjects = new List<WatchedObject>();

    const string DLL_NAME = "NETWORKING";

    [DllImport(DLL_NAME)]
    public static extern bool StartupWinsock();

    [DllImport(DLL_NAME)]
    public static extern void SetupHints();

    [DllImport(DLL_NAME)]
    public static extern void ConnectTo(string ip);

    [DllImport(DLL_NAME)]
    public static extern void CreateSocket();

    [DllImport(DLL_NAME)]
    public static extern bool SendFloat(float flt);

    [DllImport(DLL_NAME)]
    public static extern bool SendInt(float it);

    [DllImport(DLL_NAME)]
    public static extern bool SendString(string str);

    [DllImport(DLL_NAME)]
    public static extern bool ShutdownWinsock();



    private void OnDestroy()
    {
        //Cleanup
        ShutdownWinsock();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartupWinsock();
        SetupHints();
        ConnectTo(ip);
        CreateSocket();
    }

    // Update is called once per frame
    void Update()
    {
        SendData();
    }

    void SendData()
    {
        m_time += Time.deltaTime;
        if (m_time >= sendInterval)
        {
            for (int i = 0; i < watchedObjects.Count; i++)
            {
                watchedObjects[i].SendPosition();
            }
            m_time = 0.0f;
        }
    }
}
