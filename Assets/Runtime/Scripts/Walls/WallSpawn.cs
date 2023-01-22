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

    private void Start()
    {
        GameObject firstWallTop = Instantiate(wall, new Vector3(0, 4.5f, 0), new Quaternion(0,0,0,0));
        GameObject firstWallBottom = Instantiate(wall, new Vector3(0, -4.5f, 0), new Quaternion(0, 0, 0, 0));

        spawnedTopPosition.Add(firstWallTop);
        spawnedBottomPosition.Add(firstWallBottom);
    }
    private void Update()
    {
        if (spawnedTopPosition[^1].transform.position.x < 20f)
        {
            GameObject wallTopInstance = Instantiate(wall, new Vector3(spawnedTopPosition[^1].transform.position.x + 17.8f, spawnedTopPosition[^1].transform.position.y, spawnedTopPosition[^1].transform.position.z), new Quaternion(0, 0, 0, 0));
            GameObject wallBottomInstance = Instantiate(wall, new Vector3(spawnedBottomPosition[^1].transform.position.x + 17.8f, spawnedBottomPosition[^1].transform.position.y, spawnedBottomPosition[^1].transform.position.z), new Quaternion(0, 0, 0, 0));
            spawnedTopPosition.Add(wallTopInstance);
            spawnedBottomPosition.Add(wallBottomInstance);
        }
        if (spawnedTopPosition.Count > 4)
        {
            GameObject.Destroy(spawnedTopPosition[0]);
            GameObject.Destroy(spawnedBottomPosition[0]);
        }
    }
}
