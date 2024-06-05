using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    float HAxis;
    Vector2 direction;
    
    [SerializeField]
    float speed = 3;
    [SerializeField]
    float jumpPower = 5;

    Rigidbody2D rb;

    [SerializeField]
    bool onGround = false;

    Animator animator;

    [SerializeField]
    AudioClip[] audioClips;
    AudioSource audioSource;

    [SerializeField]
    Transform BG;

    [SerializeField]
    Lives liveScript;
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Jump();
        Facing();
        Animation();
    }



    void Movement()
    {
        //Monitor Horizontal key presses and apply movement on player object
        HAxis = Input.GetAxis("Horizontal");
        direction = new Vector2 (HAxis, 0);
        transform.Translate (direction * Time.deltaTime * speed);
    }

    void Jump()
    {
        //if Spacebar pressed then apply velocity to rb on Y axis

        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            rb.velocity = new Vector2(0, 1) * jumpPower;

            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
    }

    void Facing()
    {
        //if player is moving left "scale = -1" & if player is moving right "scale = 1"
        if (HAxis < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            BG.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

        if (HAxis > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            BG.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
    }

    void Animation()
    {
        //if player is moving then play running animation
        animator.SetFloat("Moving",Mathf.Abs(HAxis));
        animator.SetBool("OnGround", onGround);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        //if trigger enters Object with tag "Ground", then onGround = true
        if (col.tag == "Ground")
        {
            onGround = true;
            print(onGround);
        }

        if (col.tag == "Collectables") 
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }

        if (col.tag == "Enemy") 
        {   
            liveScript.ReduceLives();
        }
    }



    private void OnTriggerExit2D(Collider2D col) {
        //if trigger exits Object with tag "Ground", then onGround = false
        if (col.tag == "Ground")
        {
            onGround = false;
            print(onGround);
        }
    }



}
