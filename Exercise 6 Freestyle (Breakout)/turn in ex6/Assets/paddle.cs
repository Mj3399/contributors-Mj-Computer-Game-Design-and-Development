using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class paddle : MonoBehaviour
{
    public BoxCollider2D bc;
    public Rigidbody2D rb;
    public AudioSource aws;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        aws = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3 (mousePosition.x, transform.position.y, transform.position.z);
        if(ball.lives == 0)
        {
            Destroy(gameObject);
        }
    }
}
