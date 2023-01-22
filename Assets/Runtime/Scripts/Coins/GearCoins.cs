using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GearCoins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().UpdateGears();
            this.GetComponent<SpriteRenderer>().DOFade(0, 0.2f);
            Destroy(this.gameObject, 1);
        }
    }
}
