using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] public GameObject wallFather;
    [SerializeField] public GameObject wallTopPrefab;
    [SerializeField] public GameObject wallBottomPrefab;
    [SerializeField] public List<GameObject> scenarioVariationsTop;
    [SerializeField] public List<GameObject> scenarioVariationsBottom;

    public List<GameObject> spawnedTopPosition;
    public List<GameObject> spawnedBottomPosition;

    private float heightWalls = 4.5f;
    private float widthWalls = 17.8f;

    private void Start()
    {
        GameObject firstWallTop = Instantiate(wallTopPrefab, new Vector3(0, heightWalls, 0), new Quaternion(0,0,0,0));
        GameObject firstWallBottom = Instantiate(wallBottomPrefab, new Vector3(0, -heightWalls, 0), new Quaternion(0, 0, 0, 0));

        firstWallTop.transform.SetParent(wallFather.transform);
        firstWallBottom.transform.SetParent(wallFather.transform);

        spawnedTopPosition.Add(firstWallTop);
        spawnedBottomPosition.Add(firstWallBottom);

    }
    public void SpawnScenario()
    {
        int index = Random.Range(0, scenarioVariationsTop.Count);

        Vector3 transformLastWall = new Vector3(spawnedTopPosition[^1].transform.position.x, heightWalls, 0);

        GameObject wallTopInstance = Instantiate(scenarioVariationsTop[index], new Vector3(transformLastWall.x + widthWalls, transformLastWall.y, transformLastWall.z), new Quaternion(0, 0, 180, 0));
        GameObject wallBottomInstance = Instantiate(scenarioVariationsBottom[index], new Vector3(transformLastWall.x + widthWalls, -transformLastWall.y, transformLastWall.z), new Quaternion(0, 0, 0, 0));

        wallTopInstance.transform.SetParent(wallFather.transform);
        wallBottomInstance.transform.SetParent(wallFather.transform);

        spawnedTopPosition.Add(wallTopInstance);
        spawnedBottomPosition.Add(wallBottomInstance);

        Debug.Log("SpanScenario");
        Debug.Log(index);

    }
    private void Update()
    {
        if (spawnedTopPosition[^1].transform.position.x < 20f)
        {
            SpawnScenario();
        }
        if (spawnedTopPosition.Count > 4)
        {
            GameObject firstWallTop = spawnedTopPosition[0];
            GameObject firstWallBottom = spawnedBottomPosition[0];
            GameObject.Destroy(firstWallTop);
            GameObject.Destroy(firstWallBottom);
            
            spawnedTopPosition.Remove(firstWallTop);
            spawnedBottomPosition.Remove(firstWallBottom);
        }
    }
}