using UnityEngine;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    /// 
    public Rigidbody2D rb;

    public static float OffScreen;
    public GameObject Ground;

    SpriteRenderer m_SpriteRenderer;
    
   
        //
    internal void Start() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
        
            Scored();
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
  
    {

        //Debug.Log(coll.collider);

        if (GameObject.FindWithTag("Ground") == coll.collider.gameObject)
        {
            Scored();
            
        }
    }
    private void Scored()
    {


        if (m_SpriteRenderer.color != Color.green)
        {
            ScoreKeeper.AddToScore(rb.mass);
        }
        m_SpriteRenderer.color = Color.green;
        
        
    }
}
