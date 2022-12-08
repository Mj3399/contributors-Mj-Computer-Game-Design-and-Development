using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public ScoreKeeper s;
    public AudioSource aws;
    public AudioClip audioClip;
    private void Start()
    {
        aws = GetComponent<AudioSource>();
        if (aws == null)
        {
            aws = gameObject.AddComponent<AudioSource>();
        }
        audioClip = Resources.Load<AudioClip>("yeah, ok");
        s = GameObject.FindObjectOfType<ScoreKeeper>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.name == "murder victim")
        {
            s.AddToScore(1);

            aws.PlayOneShot(audioClip);
            collision.collider.gameObject.SetActive(false);
            //Destroy(collision.collider.gameObject);
        }
    }
}
