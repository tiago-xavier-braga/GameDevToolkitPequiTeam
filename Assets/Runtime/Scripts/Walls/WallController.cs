using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WallController : MonoBehaviour
{
    [SerializeField] public float speed = 400;
    [SerializeField] GameManager gameManager;
    private Rigidbody2D rb;
    private float defaultSpeed;
    
    private void Awake()
    {
        defaultSpeed = speed; 
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(gameManager.gameStarted)
        {
            speed = defaultSpeed;
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
        else
        {
            speed = 0;
        }
        
    }
}
