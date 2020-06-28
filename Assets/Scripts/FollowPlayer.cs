using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        if (!player)
        {
            Debug.LogError("Player object is missing from inspector");
        }
    }

    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }

}
