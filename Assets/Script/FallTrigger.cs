using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour
{
    [SerializeField]
    Transform Player;
    [SerializeField]
    Lives liveScript;

    private void Update()
    {
        transform.position = new Vector2(Player.position.x , -9);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //when player tag enters trigger restart scene
        if (other.tag == "Player")
        {   
            liveScript.ReduceLives();
        }
    }

}
