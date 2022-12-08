using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class ball : MonoBehaviour
{
    public CircleCollider2D cc;
    public Rigidbody2D rb;
    public AudioSource aws;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    public static PlayState b = PlayState.fail;
    public enum PlayState { play, fail }
    public static float xoom;
    public static int lives;
    
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        aws = GetComponent<AudioSource>();
        if (aws == null)
        {
            aws = gameObject.AddComponent<AudioSource>();
        }
        audioClip = Resources.Load<AudioClip>("[EXTREMELY LOUD INCORRECT BUZZER]");
        audioClip2 = Resources.Load<AudioClip>("bounce");
        audioClip3 = Resources.Load<AudioClip>("yeah, ok");

        transform.position = new Vector3(GameObject.Find("paddle").transform.position.x, GameObject.Find("paddle").transform.position.y + 0.42f, GameObject.Find("paddle").transform.position.z);
        
        xoom = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (b == PlayState.fail)
        {
            xoom = 200;
            rb.velocity = Vector3.zero;

            transform.position = new Vector3(GameObject.Find("paddle").transform.position.x, GameObject.Find("paddle").transform.position.y + 0.42f, GameObject.Find("paddle").transform.position.z);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {

                b = PlayState.play;
                rb.AddForce(new Vector2(0, 400));
            }
        }
        else
        {
            if(rb.velocity.y == 0)
            {
                rb.velocity = new Vector3 (rb.velocity.x, -1, 0);
            }
        }
        
        if (Input.GetKeyDown("backspace"))
        {
            b = PlayState.fail;
            lives--;
            aws.PlayOneShot(audioClip);

            if (lives == 0)
            {
                Destroy(gameObject);
            }
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "brick")
        {
            if(collision.collider.gameObject.GetComponent<brick>().getalpha() > 0)
            {
                aws.PlayOneShot(audioClip2);
            }
            else
            {
                aws.PlayOneShot(audioClip3);
            }

        }
        if (collision.collider.name == "paddle")
        {

            aws.PlayOneShot(audioClip2);

            /*
            float height = Camera.main.orthographicSize * 2.0f;
            float width = height * Screen.width / Screen.height;
            Debug.Log("Screen Height : " + height);  11.25
            Debug.Log("Screen width : " + width);  20
            */
            //random shit



            //actual important
            xoom += 2f;
            var colp = collision.GetContact(0).point;
            var cent = new Vector3(collision.collider.transform.position.x, collision.collider.transform.position.y, collision.collider.transform.position.z);
            rb.velocity = Vector2.zero;
            var d = cent.x - colp.x;
            
            d = MathF.Abs(d)+ 1;
            //Debug.Log(xoom);

            if (colp.x< cent.x)
            {
                
                
                    rb.AddForce(new Vector2(-1 * (Mathf.Abs(d * xoom)), (Mathf.Abs(d * xoom))));

                
                
            }
            else
            {
                
                    rb.AddForce(new Vector2((Mathf.Abs(d * xoom)), (Mathf.Abs(d * xoom))));
                

            }
        }




        if (collision.collider.name == "floor")
        {
            b = PlayState.fail;
            lives--;
            aws.PlayOneShot(audioClip);
            if (lives == 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
