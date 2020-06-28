using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField()]
    float speed;

    private Rigidbody2D rb;
    private Vector2 movement;
    bool lookingRight = true;

    public GameObject bubblePrefab;
    public Transform spawnLocation;
    bool canShoot = true;
    float timeBeforeReload = 0.3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
        {
            Debug.LogError("RB 2D missing from player");
        }
    }

    private void Update()
    {
        Vector2 directions = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement = directions.normalized * speed;

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            GameObject bubble = Instantiate(bubblePrefab, spawnLocation.position, Quaternion.identity);
            bubble.GetComponent<Bubble>().direction = new Vector2(lookingRight ? 1 : -1, 0);
            StartCoroutine(Timer(timeBeforeReload));
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        if (movement.x < 0 && lookingRight || movement.x > 0 && !lookingRight)
        {
            lookingRight = !lookingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }

}
