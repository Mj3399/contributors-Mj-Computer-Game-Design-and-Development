using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class brick : MonoBehaviour
{
    
    public SpriteRenderer b;
    public float alphaLevel = 1f;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<SpriteRenderer>();
        alphaLevel = 1f;
        //each brick is .75 by .25
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public  float getalpha()
    {
        return alphaLevel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

       
        if (collision.collider.name == "ball")
        {
            alphaLevel -= 1/3f;
            this.b.color = new Color(1f, 1f, 1f, alphaLevel);
            if(alphaLevel <= 0)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
