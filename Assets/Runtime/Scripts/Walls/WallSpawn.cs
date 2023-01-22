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
        firstWallTop = GameObject.Instantiate(wall, new Vector3(0, 4.5f, 0), new Quaternion(0,0,0,0));
        firstWallBottom = GameObject.Instantiate(wall, new Vector3(0, -4.5f, 0), new Quaternion(0, 0, 0, 0));

        spawnedTopPosition.Add(firstWallTop);
        spawnedBottomPosition.Add(firstWallBottom);
    }
    private void Update()
    {
    }
}
