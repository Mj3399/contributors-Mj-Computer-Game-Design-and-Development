using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 5000;
    public GameObject ExplosionPrefab;

    private void Destruct()
    {
        Destroy(gameObject);
    }
    private void Boom()
    {
        GetComponent<PointEffector2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
       
        Invoke("Destruct", 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D coll)

    {

        //Debug.Log(coll.collider);
        if(null != coll.collider.GetComponent<Rigidbody2D>())
        {
            var vel = coll.collider.GetComponent<Rigidbody2D>().velocity.magnitude;
                if (vel >= ThresholdForce)
            {
                Boom();

            }
        }

        
    }


}
