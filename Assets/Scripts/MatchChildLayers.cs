using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchChildLayers : MonoBehaviour
{
    int layerToMatch;

    private void Start()
    {
        layerToMatch = gameObject.layer;

        DepthSearch(gameObject);
    }

    void DepthSearch(GameObject currentObj)
    {
        currentObj.layer = layerToMatch;

        var children = GetChildren(currentObj);

        foreach(var child in children)
        {
            if (child.gameObject == currentObj)
                continue;

            DepthSearch(child.gameObject);
        }
    }

    Transform[] GetChildren(GameObject parent)
    {
        return parent.GetComponentsInChildren<Transform>();
    }
}
