using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Human
{
    const int AMMO_MAX = 5;
    const float AMMO_RECHARGE_RATE = 1.2f;
    int ammo;
    float timeNextAmmoRecharge;
    public float ammoLaunchForce;
    Vector2 lastAimVec;

    GameObject ammoResource;
    public override void InitializeUnit()
    {
        base.InitializeUnit();
        ammo = AMMO_MAX;
        ammoResource = Resources.Load<GameObject>("Prefabs/Ammo");
        lastAimVec = -Vector2.up;
    }
    protected override Vector2 GetMoveDir()
    {
        Vector2 toRet = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        lastAimVec = (toRet != Vector2.zero) ? toRet : lastAimVec;
        return toRet;
    }

    public override void UpdateUnit()
    {
        base.UpdateUnit();
        if(Time.time > timeNextAmmoRecharge)
        {
            ammo = Mathf.Min(ammo + 1, AMMO_MAX);
            timeNextAmmoRecharge = Time.time + AMMO_RECHARGE_RATE;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Fire();

    }

    void Fire()
    {        
        if (ammo == AMMO_MAX)
            timeNextAmmoRecharge = Time.time + AMMO_RECHARGE_RATE;
        if(ammo > 0)
        {
            GameObject go = GameObject.Instantiate(ammoResource);
            
            go.transform.position = transform.position;
            go.GetComponent<Rigidbody2D>().AddForce(lastAimVec.normalized * ammoLaunchForce, ForceMode2D.Impulse);
            ammo--;
        }
    }
}
