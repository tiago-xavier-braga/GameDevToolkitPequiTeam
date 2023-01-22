using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour
{
    [SerializeField] public GameObject backgroundFather;
    [SerializeField] public GameObject backgroundPrefab;
    [SerializeField] public List<GameObject> backgroundList;

    [SerializeField] public float widthWalls = 17.8f;

    private void SpawnBackground()
    {
        Vector3 transformLastBackground = new Vector3(backgroundList[^1].transform.position.x, 0, 0);
        GameObject backgroundInstance = Instantiate(backgroundPrefab, new Vector3(transformLastBackground.x + widthWalls, transformLastBackground.y, transformLastBackground.z), new Quaternion(0, 0, 0, 0));
        backgroundInstance.transform.SetParent(backgroundFather.transform);
        backgroundList.Add(backgroundInstance);
    }
    private void Update()
    {
        if (backgroundList[^1].transform.position.x < 20f)
        {
            SpawnBackground();
        }
        if (backgroundList.Count > 4)
        {
            GameObject firstBackground = backgroundList[0];
            GameObject.Destroy(firstBackground);

            backgroundList.Remove(firstBackground);
        }
    }
}
