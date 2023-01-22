using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] public GameObject wall;
    public List<GameObject> spawnedTopPosition;
    public List<GameObject> spawnedBottomPosition;

    public GameObject firstWallTop;
    public GameObject firstWallBottom;

    public float heightWalls = 4.5f;

    private void Start()
    {
        GameObject firstWallTop = Instantiate(wall, new Vector3(0, heightWalls, 0), new Quaternion(0,0,0,0));
        GameObject firstWallBottom = Instantiate(wall, new Vector3(0, -heightWalls, 0), new Quaternion(0, 0, 0, 0));

        spawnedTopPosition.Add(firstWallTop);
        spawnedBottomPosition.Add(firstWallBottom);
    }
    private void Update()
    {
        if (spawnedTopPosition[^1].transform.position.x < 20f)
        {
            Vector3 transformLastWall = new Vector3(spawnedTopPosition[^1].transform.position.x, heightWalls, 0);
            GameObject wallTopInstance = Instantiate(wall, new Vector3(transformLastWall.x + 17.8f, transformLastWall.y, transformLastWall.z), new Quaternion(0, 0, 0, 0));
            GameObject wallBottomInstance = Instantiate(wall, new Vector3(transformLastWall.x + 17.8f, -transformLastWall.y, transformLastWall.z), new Quaternion(0, 0, 0, 0));
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
            Debug.Log("Destroy");
        }
    }
}
