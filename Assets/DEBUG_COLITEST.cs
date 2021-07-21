using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUG_COLITEST : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }
}
