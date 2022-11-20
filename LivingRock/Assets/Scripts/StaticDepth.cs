using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDepth : MonoBehaviour
{
    private void Start()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.y * 0.01f);
        }

    }
}
