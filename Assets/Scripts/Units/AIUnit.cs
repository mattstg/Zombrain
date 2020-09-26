using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIUnit : Unit
{
    protected virtual float detectionRange => 5;
    const int intervalOfRandomDir = 5;
    float nextRandTime;
    Vector2 lastRandDir;
    protected override Vector2 GetMoveDir()
    {
        Vector2 targetPos;
        if(FindClosestTarget(out targetPos) && Vector2.SqrMagnitude(targetPos - (Vector2)transform.position) <= detectionRange)
        {
            return (targetPos - (Vector2)transform.position).normalized;
        }
        else
        {
            if (Time.time > nextRandTime)
            {
                lastRandDir = Random.insideUnitCircle.normalized;
                nextRandTime = Time.time + intervalOfRandomDir;
            }
            return lastRandDir;
        }

    }

    abstract protected bool FindClosestTarget(out Vector2 targetPos);
   
}
