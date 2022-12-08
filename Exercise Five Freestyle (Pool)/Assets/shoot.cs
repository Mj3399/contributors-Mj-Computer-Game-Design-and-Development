using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    Camera cam;
    
    Vector2 f;
    
    Vector3 sp;
    
    Vector3 ep; 

    public Vector2 mip;
    
    public Vector2 map;


    
    public float yolo = 0.02f;
    //anything higher than 7 allows shooting off table we do not want that so dont do that
    
    public Rigidbody2D rb;
    line l;

    public void Start()
    {


        cam = Camera.main;
        l = GetComponent<line>();


    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            sp = cam.ScreenToWorldPoint(Input.mousePosition);
            sp.z = 666;
            //stay visible
          
        }


        if (Input.GetMouseButton(0))
        {
            Vector3 cp = cam.ScreenToWorldPoint(Input.mousePosition);
            cp.z = 666;
            l.rend(sp, cp);
            //pretty lines
            
        }



        if (Input.GetMouseButtonUp(0))
        {
            ep = cam.ScreenToWorldPoint(Input.mousePosition);
            ep.z = 666;
            f = new Vector2(Mathf.Clamp(sp.x - ep.x, mip.x, map.x), Mathf.Clamp(sp.y - ep.y, mip.y, map.y));
            rb.AddForce(f * yolo, ForceMode2D.Impulse);
            l.die(); //kill it
        }
    }
}
