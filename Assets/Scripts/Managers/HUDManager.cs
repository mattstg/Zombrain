using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager
{
    #region Singleton

    private HUDManager()
    {
    }

    private static HUDManager instance;

    public static HUDManager Instance
    {
        get
        {
            if (instance == null)
                instance = new HUDManager();
            return instance;
        }
    }

    #endregion Singleton

    private Text HumanText;
    private Text ZombieText;
    private GameObject ammoObject;
    private HorizontalLayoutGroup ammoPanel;
    private List<GameObject> ammoList;

    public void Initialise()
    {
        HumanText = GameObject.Find("HumanText").GetComponent<Text>();
        ZombieText = GameObject.Find("ZombieText").GetComponent<Text>();

        ammoObject = Resources.Load<GameObject>("Prefabs/AmmoObject");
        ammoPanel = GameObject.Find("AmmoPanel").GetComponent<HorizontalLayoutGroup>();
        ammoList = new List<GameObject>();

        for (int i = 0; i < Player.AMMO_MAX; i++)
        {
            ammoList.Add(GameObject.Instantiate(ammoObject, ammoPanel.transform));
        }
    }

    public void Update()
    {
        SetHumanText(UnitManager.Instance.humans.Count);
        SetZombieText(UnitManager.Instance.zombies.Count);
        setAmmo(PlayerManager.Instance.players.First().ammo);
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