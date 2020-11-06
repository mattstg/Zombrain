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

    public void Initialize()
    {
        humansCount = GameObject.Find("HumansText").GetComponent<Text>();
        zombiesCount = GameObject.Find("ZombiesText").GetComponent<Text>();
    }

    public void Update()
    {
        humansCount.text = "Humans: " + UnitManager.Instance.humans.Count;
        zombiesCount.text = "Zombies: " + UnitManager.Instance.zombies.Count;
    }
}
