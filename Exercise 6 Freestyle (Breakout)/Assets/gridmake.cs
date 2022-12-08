using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class gridmake : MonoBehaviour
{
    public AudioSource aws;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public int j;
    public int k;
    // Start is called before the first frame update
    void Start()
    {
        aws = GetComponent<AudioSource>();
        if (aws == null)
        {
            aws = gameObject.AddComponent<AudioSource>();
        }
        audioClip = Resources.Load<AudioClip>("do you feel accomplished now");
        audioClip2 = Resources.Load<AudioClip>("Sitcom Laughter Applause  Gaming Sound Effect HD");

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(Resources.Load("brick"), new Vector3(j * 2 + -9, i * 1.25f + -0.75f, 0), Quaternion.identity);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("brick");
        if (gameObjects.Length == 0 && k ==0)
        {
            k++;
             aws.PlayOneShot(audioClip);

        }
        if (Input.GetKeyDown("escape"))
        {
            reset();
            ball.b = ball.PlayState.fail;
            
        }
        if (ball.lives == 0 && j == 0 && k!=1)
        {
            j++;
            aws.PlayOneShot(audioClip2);

        }
    }
    private void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
