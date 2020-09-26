using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Since this is not a mono, other classes need to call it's update
public class PlayerManager
{
    #region Singleton
    private PlayerManager() { }
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                instance = new PlayerManager();
            return instance;
        }
    }
    #endregion

    public List<Player> players;
    GameObject playerResource;
    Transform playerParent;
    public void Initialize()
    {
        playerResource = Resources.Load<GameObject>("Prefabs/Player");
        players = new List<Player>();
        playerParent = new GameObject("PlayerParent").transform;
    }

    public void GameStart()
    {
        Player newPlayer = GameObject.Instantiate(playerResource, playerParent).GetComponent<Player>();
        players.Add(newPlayer);
        newPlayer.InitializeUnit();
        MainScript.instance.vcam.Follow = newPlayer.transform;
    }

    public void Update()
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            players[i].UpdateUnit();
        }
    }

    public void FixedUpdate()
    {
        for (int i = players.Count - 1; i >= 0; i--)
        {
            players[i].FixedUpdateUnit ();
        }
    }

    public void PlayerDied(Player pDied)
    {
        Debug.Log("GAME OVER");
    }

}
