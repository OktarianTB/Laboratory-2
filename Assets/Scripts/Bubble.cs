using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    float speed = 4f;
    public Vector2 direction;
    private Rigidbody2D rb;
    private GameManager manager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
        {
            Debug.LogError("RB 2D missing from bubble prefab");
        }

        manager = FindObjectOfType<GameManager>();
        if (!manager)
        {
            Debug.LogError("Can't find game manager");
        }

        direction.x *= Random.Range(0.6f, 1f);
        direction.y += Random.Range(-0.6f, 0.6f);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Monster>())
        {
            Destroy(collision.gameObject);
            print("Killed monster");
            manager.LoadNextRound();
            Destroy(gameObject);
        }
    }
}
