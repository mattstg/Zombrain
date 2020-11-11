using Destructible2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    #region Singleton
    private UIManager() { }
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();
            return instance;
        }
    }
    #endregion

    Text humansCount;
    Text zombiesCount;

    GameObject fishHudPanel;
    GameObject fishAmmoPanelPrefab;
    GameObject fishAmmoPanelClone;
    List<GameObject> ammoList;

    public void Initialize()
    {
        humansCount = GameObject.Find("HumansText").GetComponent<Text>();
        zombiesCount = GameObject.Find("ZombiesText").GetComponent<Text>();
        fishHudPanel = GameObject.Find("FishHUDPanel");
        fishAmmoPanelPrefab = Resources.Load<GameObject>("Prefabs/UI/FishAmmoPanel");
        ammoList = new List<GameObject>();
    }

    public void Update()
    {
        humansCount.text = "Humans: " + UnitManager.Instance.humans.Count;
        zombiesCount.text = "Zombies: " + UnitManager.Instance.zombies.Count;
    }

    public void AddAmmo()
    {
        fishAmmoPanelClone = new GameObject();
        fishAmmoPanelClone = GameObject.Instantiate(fishAmmoPanelPrefab);
        fishAmmoPanelClone.transform.SetParent(fishHudPanel.transform, false);
        //ammoList.Add(fishAmmoPanelClone);

    }

    public void RemoveAmmoUI()
    {
        ammoList.Remove(fishAmmoPanelClone);
        //GameObject.Destroy(fishAmmoPanelClone);
    }

    public void RefreshUI(int ammo)
    {
  

    }

}
