using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    bool myBool;        //Not visible
    public bool myBool1;     //Visible
    [HideInInspector] public bool myBool2; //Not Visible
    [SerializeField] bool myBool3; //Visible

    public InternalClass internalClass;   //Value in inspector
    public Player player;                 //Reference type in inspector

    [Header("Header in Inspector")]
    public int hp;
    [Space(20)]
    public int spacedInt;
    [Range(0, 25)] public float rangedFloat;


    [System.Serializable]
    public class InternalClass
    {
        public int myInt;
        public string myString;

    }
}
