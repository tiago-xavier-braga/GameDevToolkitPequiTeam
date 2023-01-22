using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InfinityRun.UI
{
    public class ObstacleColliders : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }
}


