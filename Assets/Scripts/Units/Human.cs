using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : AIUnit
{
    const float immuneTime = 2;
    float immuneUntilTime;

    public override void InitializeUnit()
    {
        base.InitializeUnit();
        immuneUntilTime = Time.time + immuneTime;
    }
    protected override Vector2 GetMoveDir()
    {
        return -1 * base.GetMoveDir(); //because it runs away
    }

    protected override bool FindClosestTarget(out Vector2 targetPos)
    {
        Zombie z = UnitManager.Instance.GetClosestZombieToPoint(transform.position);
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

    public void Infect()
    {
        if(Time.time >= immuneUntilTime)
            UnitManager.Instance.ConvertHuman(this);
    }
}
