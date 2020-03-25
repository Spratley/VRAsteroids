using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Boundry : MonoBehaviour
{
    public bool update;
    public Vector3 limit;

    public GameObject cornerPrefab;
    public List<GameObject> corners = new List<GameObject>();

    public GameObject bottom, top;
    public GameObject left, right;
    public GameObject front, back;

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            bottom.transform.position = new Vector3(0.0f, -limit.y, 0.0f);
            top.transform.position = new Vector3(0.0f, +limit.y, 0.0f);
            left.transform.position = new Vector3(-limit.x, 0.0f, 0.0f);
            right.transform.position = new Vector3(+limit.x, 0.0f, 0.0f);
            front.transform.position = new Vector3(0.0f, 0.0f, -limit.z);
            back.transform.position = new Vector3(0.0f, 0.0f, +limit.z);

            bottom.transform.localScale = new Vector3(limit.x * 2.0f, limit.y * 0.1f, limit.z * 2.0f);
            top.transform.localScale = new Vector3(limit.x * 2.0f, limit.y * 0.1f, limit.z * 2.0f);
            left.transform.localScale = new Vector3(limit.x * 0.1f, limit.y * 2.0f, limit.z * 2.0f);
            right.transform.localScale = new Vector3(limit.x * 0.1f, limit.y * 2.0f, limit.z * 2.0f);
            front.transform.localScale = new Vector3(limit.x * 2.0f, limit.y * 2.0f, limit.z * 0.1f);
            back.transform.localScale = new Vector3(limit.x * 2.0f, limit.y * 2.0f, limit.z * 0.1f);

            if (corners.Count > 0 && corners[0] != null)
            {
                corners[0].transform.position = new Vector3(-limit.x, -limit.y, -limit.z);
                corners[1].transform.position = new Vector3(-limit.x, -limit.y, +limit.z);
                corners[2].transform.position = new Vector3(-limit.x, +limit.y, -limit.z);
                corners[3].transform.position = new Vector3(-limit.x, +limit.y, +limit.z);
                corners[4].transform.position = new Vector3(+limit.x, -limit.y, -limit.z);
                corners[5].transform.position = new Vector3(+limit.x, -limit.y, +limit.z);
                corners[6].transform.position = new Vector3(+limit.x, +limit.y, -limit.z);
                corners[7].transform.position = new Vector3(+limit.x, +limit.y, +limit.z);

                corners[0].transform.rotation = Quaternion.Euler(+90.0f, 0.0f, 0.0f);
                corners[1].transform.rotation = Quaternion.identity;
                corners[2].transform.rotation = Quaternion.Euler(-90.0f, 0.0f, -90.0f);
                corners[3].transform.rotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
                corners[4].transform.rotation = Quaternion.Euler(+90.0f, 0.0f, +90.0f);
                corners[5].transform.rotation = Quaternion.Euler(0.0f, +90.0f, 0.0f);
                corners[6].transform.rotation = Quaternion.Euler(0.0f, 180.0f, -90.0f);
                corners[7].transform.rotation = Quaternion.Euler(-90.0f, +90.0f, 0.0f);
            }
            update = false;
        }
    }

    [ContextMenu("Spawn Corners")]
    public void SpawnCorners()
    {
        corners.Clear();
        corners.Add(Instantiate(cornerPrefab, new Vector3(-limit.x, -limit.y, -limit.z), Quaternion.identity));
        corners.Add(Instantiate(cornerPrefab, new Vector3(-limit.x, -limit.y, +limit.z), Quaternion.identity));
        corners.Add(Instantiate(cornerPrefab, new Vector3(-limit.x, +limit.y, -limit.z), Quaternion.identity));//-+-&+-+:00+&0+0
        corners.Add(Instantiate(cornerPrefab, new Vector3(-limit.x, +limit.y, +limit.z), Quaternion.identity));
        corners.Add(Instantiate(cornerPrefab, new Vector3(+limit.x, -limit.y, -limit.z), Quaternion.identity));
        corners.Add(Instantiate(cornerPrefab, new Vector3(+limit.x, -limit.y, +limit.z), Quaternion.identity));
        corners.Add(Instantiate(cornerPrefab, new Vector3(+limit.x, +limit.y, -limit.z), Quaternion.identity));//-++&++-:-00&00-
        corners.Add(Instantiate(cornerPrefab, new Vector3(+limit.x, +limit.y, +limit.z), Quaternion.identity));//--+&+++:id&++0
        foreach (var corner in corners)
            corner.transform.SetParent(this.gameObject.transform);
    }
}
