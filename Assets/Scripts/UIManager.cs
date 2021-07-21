using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text zombieCountText;
    public Text humanCountText;

    Transform gridLayoutParent;
    GameObject fishUIResource;

    public void InitializeUI(int initialAmmo)
    {
        gridLayoutParent = MainScript.instance.ammoHudParent;
        fishUIResource = Resources.Load<GameObject>("Prefabs/FishAmmoUI");
        //bool b = fishUIResource == null;
        //Debug.Log("b:" + b);
        ModifyAmmoCount(initialAmmo);
    }

    public void UpdateCounts(int numOfHumans, int numOfZombies)
    {
        humanCountText.text = numOfHumans.ToString();
        zombieCountText.text = numOfZombies.ToString();
    }

    public void ModifyAmmoCount(int modBy)
    {
        for (int i = 0; i < Mathf.Abs(modBy); i++)
        {
            if (modBy > 0)
            {
                //add fish images
                GameObject.Instantiate(fishUIResource, gridLayoutParent);
            }
            else
            {
                //delete fish images
                if(gridLayoutParent.childCount > 0)
                {
                    Transform firstChild = gridLayoutParent.GetChild(0);
                    GameObject.Destroy(firstChild.gameObject);
                }
            }
        }
    }

}
