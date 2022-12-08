using UnityEngine;

/// <summary>
/// Even handler for Orb objects
/// </summary>
public class Orb : MonoBehaviour
{
    /// <summary>
    /// If this gets called, then we're off screen
    /// So destroy ourselves
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        if(gameObject.transform.position.x < 0 || gameObject.transform.position.x > Screen.width)
        {
            Destroy(gameObject);
        }


        if (gameObject.transform.position.y < 0 || gameObject.transform.position.y > Screen.height)
            {
            Destroy(gameObject);
        }

            }

    /// <summary>
    /// If this is called, then we hit something
    /// Destroy ourselves unless the thing we hit was another Orb.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == gameObject.name)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
