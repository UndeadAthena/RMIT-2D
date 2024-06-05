using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Transform player;

    // Update is called once per frame
    void Update()
    {
        //if player is left of enemy, scale = 1
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //if player is left of enemy, scale = 1
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
