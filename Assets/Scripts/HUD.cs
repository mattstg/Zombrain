using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;

    public Text HumanText;
    public Text ZombieText;
    public GameObject ammoResource;
    public HorizontalLayoutGroup ammoPanel;

    private List<GameObject> ammoList;

    private void Start()
    {
        instance = this;
        ammoList = new List<GameObject>();

        for (int i = 0; i < Player.AMMO_MAX; i++)
        {
            ammoList.Add(GameObject.Instantiate(ammoResource, ammoPanel.transform));
        }
    }

    public void SetHumanText(int noHumans)
    {
        HumanText.text = "Humans: " + noHumans.ToString();
    }

    public void SetZombieText(int noZombies)
    {
        ZombieText.text = "Zombies: " + noZombies.ToString();
    }

    public void setAmmo(int noAmmo)
    {
        int i = 0;
        foreach (GameObject go in ammoList)
        {
            if (i < noAmmo)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
            i++;
        }
    }
}