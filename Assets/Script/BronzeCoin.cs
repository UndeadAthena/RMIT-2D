using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeCoin : MonoBehaviour
{
    [SerializeField]
    Score scoreScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scoreScript.addScoreBronze();

            Destroy(this.gameObject);
        }
    }
}
