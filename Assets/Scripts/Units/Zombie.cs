using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : AIUnit
{
    protected override float detectionRange => 6;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Human"))
        {
            collision.gameObject.GetComponent<Human>().Infect();
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.PlayerDied(collision.gameObject.GetComponent<Player>());
        }
    }

    protected override bool FindClosestTarget(out Vector2 targetPos)
    {
        Human z = UnitManager.Instance.GetClosestHumanToPoint(transform.position,true);
        if (z)
        {
            targetPos = z.transform.position;
            return true;
        }
        else
        {
            targetPos = Vector2.zero;
            return false;
        }
    }
}
