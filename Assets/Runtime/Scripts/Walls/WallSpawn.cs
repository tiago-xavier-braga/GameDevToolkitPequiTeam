using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] public GameObject wallFather;
    [SerializeField] public GameObject wallTopPrefab;
    [SerializeField] public GameObject wallBottomPrefab;
    public List<GameObject> spawnedTopPosition;
    public List<GameObject> spawnedBottomPosition;

    public GameObject firstWallTop;
    public GameObject firstWallBottom;

    private float heightWalls = 4.5f;
    private float widthWalls = 17.5f;

    private void Start()
    {
        GameObject firstWallTop = Instantiate(wallTopPrefab, new Vector3(0, heightWalls, 0), new Quaternion(0,0,0,0));
        GameObject firstWallBottom = Instantiate(wallBottomPrefab, new Vector3(0, -heightWalls, 0), new Quaternion(0, 0, 0, 0));

        firstWallTop.transform.SetParent(wallFather.transform);
        firstWallBottom.transform.SetParent(wallFather.transform);

        spawnedTopPosition.Add(firstWallTop);
        spawnedBottomPosition.Add(firstWallBottom);

    }
    private void Update()
    {
        if (spawnedTopPosition[^1].transform.position.x < 20f)
        {
            Vector3 transformLastWall = new Vector3(spawnedTopPosition[^1].transform.position.x, heightWalls, 0);
            GameObject wallTopInstance = Instantiate(wallTopPrefab, new Vector3(transformLastWall.x + widthWalls, transformLastWall.y, transformLastWall.z), new Quaternion(0, 0, 0, 0));
            GameObject wallBottomInstance = Instantiate(wallBottomPrefab, new Vector3(transformLastWall.x + widthWalls, -transformLastWall.y, transformLastWall.z), new Quaternion(0, 0, 0, 0));
            
            wallTopInstance.transform.SetParent(wallFather.transform);
            wallBottomInstance.transform.SetParent(wallFather.transform);

            spawnedTopPosition.Add(wallTopInstance);
            spawnedBottomPosition.Add(wallBottomInstance);
        }
        if (spawnedTopPosition.Count > 4)
        {
            firstWallTop = spawnedTopPosition[0];
            firstWallBottom = spawnedBottomPosition[0];
            GameObject.Destroy(firstWallTop);
            GameObject.Destroy(firstWallBottom);
            
            spawnedTopPosition.Remove(firstWallTop);
            spawnedBottomPosition.Remove(firstWallBottom);
        }
    }
}