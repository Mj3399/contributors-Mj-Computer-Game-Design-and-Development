using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;



public class protag : MonoBehaviour
{
    public ScoreKeeper s;

    public static PlayState ball = PlayState.play;
    public CircleCollider2D rb;
    public AudioSource aws;
    public AudioClip audioClip;
    public enum PlayState { play, fail }
    private void Start()
    {
        rb = GetComponent<CircleCollider2D>();

        aws = GetComponent<AudioSource>();
        if (aws == null)
        {
            aws = gameObject.AddComponent<AudioSource>();
        }
        audioClip = Resources.Load<AudioClip>("[EXTREMELY LOUD INCORRECT BUZZER]");
        s = GameObject.FindObjectOfType<ScoreKeeper>();
        ball = PlayState.fail;
        rb.enabled = false;
    }
    private void Update()
    {

        
        if (ball == PlayState.fail)
        {
           
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
            if (Input.GetMouseButtonDown(0))
            {
                rb.enabled = true;

                ball = PlayState.play;

            }
        }
    }
    private void OnBecameInvisible()
    {
        ball = PlayState.fail;
        rb.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.collider.name == "hole")
        {
            rb.enabled = false;
            aws.PlayOneShot(audioClip);
            ball = PlayState.fail;
            
            s.AddToScore(-2);

        }
        
        
    }
    }
