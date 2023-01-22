using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WallController : MonoBehaviour
{
    [SerializeField] public float speed = 400;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        rb.velocity = Vector2.left * speed * Time.deltaTime;
    }
}
