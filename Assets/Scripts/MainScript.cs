using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainEntry point for program
public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    //In the mainscript, we would update all our singletons and flow control scripts. In this scenario, only the UnitManager and player scripts exist

    public Collider2D worldBounds;
    public CompositeCollider2D wallColliders;
    public Cinemachine.CinemachineVirtualCamera vcam;

    public void Awake()
    {
        instance = this;
        PlayerManager.Instance.Initialize(); 
        UnitManager.Instance.Initialize();
        HUDManager.Instance.Initialise();

        wallColliders.geometryType = CompositeCollider2D.GeometryType.Outlines; //starts as poly for cast reasons
    }

    public void Start()
    {
        PlayerManager.Instance.GameStart();
        UnitManager.Instance.GameStart();
    }

    public void Update()
    {
        PlayerManager.Instance.Update();
        UnitManager.Instance.Update();
        HUDManager.Instance.Update();
    }

    public void FixedUpdate()
    {
        PlayerManager.Instance.FixedUpdate();
        UnitManager.Instance.FixedUpdate();
    }
}
