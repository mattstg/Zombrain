using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zombie"))
        {
            GameObject.Destroy(gameObject);
            UnitManager.Instance.ConvertZombie(collision.gameObject.GetComponent<Zombie>());
        }
        else if(collision.gameObject.CompareTag("Human"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
