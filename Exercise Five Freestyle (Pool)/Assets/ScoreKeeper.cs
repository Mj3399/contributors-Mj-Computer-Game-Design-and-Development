using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{

    private float score;  // everyone has the same score
    public TextMeshPro scoreText; // everyone has the same text
    public static GameObject sc;
    int j = 0;
    public AudioSource aws;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    void Start()
    {
        if(sc == null)
        {
            sc = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText = GetComponent<TextMeshPro>();
        UpdateText();
        DontDestroyOnLoad(gameObject);

        aws = GetComponent<AudioSource>();
        if (aws == null)
        {
            aws = gameObject.AddComponent<AudioSource>();
        }
        score = 0;
    }
    public void AddToScore(float points)
    {

        if (j == 0)
        {
            score += points;

            UpdateText();
        }
      

    }
    
     public void UpdateText()
    {

        if (j == 0)
        {
            scoreText.text = "Score: " + score;

        }
        
    }

    private void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    internal void Update()
    {

        if (score == 15 && j==0)
        {
            scoreText.text = "Win!";
            j++;
            audioClip = Resources.Load<AudioClip>("do you feel accomplished now");

            aws.PlayOneShot(audioClip);

        }
        if (score < 0 && j == 0)
        {
            scoreText.text = "Lose!!!!!!!!!!!!!!!";
            j++;
            audioClip2 = Resources.Load<AudioClip>("Sitcom Laughter Applause  Gaming Sound Effect HD");

            aws.PlayOneShot(audioClip2);

        }
        if ( (Input.GetKeyDown("escape") && score>= 0 && score <15 && j ==0))
        {

            reset();
        }
        if ((Input.GetKeyDown("escape") && j>0))
        {
            reset();
            score = 0;
            scoreText.text = "Score: " + score;

            j = 0;
        }
    }
    
}