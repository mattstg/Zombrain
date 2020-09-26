using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Since this is not a mono, other classes need to call it's update
public class UnitManager
{
    #region Singleton
    private UnitManager() { }
    private static UnitManager instance;
    public static UnitManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UnitManager();
            return instance;
        }
    }
    #endregion

    const int VALIDSPOT_ATTEMPTS_MAX = 40; 

    public List<Zombie> zombies;
    public List<Human> humans;

    GameObject zombieResource;
    GameObject humanResource;

    Transform zombieParent;
    Transform humanParent;

    int numberOfHumansToSpawn = 85;
    int numberOfZombiesToSpawn = 5;

    float percentInfected = .2f;  //this could scale with level or something
    public void Initialize()
    {
        zombies = new List<Zombie>();
        humans = new List<Human>();
        zombieParent = new GameObject("Zombie Parent").transform;
        humanParent = new GameObject("Human Parent").transform;
        zombieResource = Resources.Load<GameObject>("Prefabs/Zombie");
        humanResource = Resources.Load<GameObject>("Prefabs/Human");
    }

    public void GameStart()
    {
        Vector2 validSpot = new Vector2();
        for(int i = 0; i < numberOfHumansToSpawn; i++)
            if(GetValidSpot(out validSpot))
                SpawnHuman(validSpot);
        for (int i = 0; i < numberOfZombiesToSpawn; i++)
            if (GetValidSpot(out validSpot))
                SpawnZombie(validSpot);
    }
    public void Update()
    {
        for (int i = zombies.Count - 1; i >= 0; i--)
            zombies[i].UpdateUnit();
        for (int i = humans.Count - 1; i >= 0; i--)
            humans[i].UpdateUnit();
    }

    public void FixedUpdate()
    {
        for (int i = zombies.Count - 1; i >= 0; i--)
            zombies[i].FixedUpdateUnit();
        for (int i = humans.Count - 1; i >= 0; i--)
            humans[i].FixedUpdateUnit();
    }

    public void ConvertHuman(Human toConvert)
    {
        toConvert.gameObject.SetActive(false); //Just in case the new zombie tries to collide with it
        humans.Remove(toConvert);
        SpawnZombie(toConvert.transform.position);
        GameObject.Destroy(toConvert);
    }

    public void ConvertZombie(Zombie toConvert)
    {
        toConvert.gameObject.SetActive(false); //Just in case the new zombie tries to collide with it
        zombies.Remove(toConvert);
        SpawnHuman(toConvert.transform.position);
        GameObject.Destroy(toConvert);
    }

    public void SpawnHuman(Vector2 pos)
    {
        Human newHuman = GameObject.Instantiate(humanResource, humanParent).GetComponent<Human>();
        newHuman.name = "Human";
        newHuman.transform.position = pos;
        newHuman.InitializeUnit();
        humans.Add(newHuman);
    }


    public void SpawnZombie(Vector2 pos)
    {
        Zombie newZombie = GameObject.Instantiate(zombieResource, zombieParent).GetComponent<Zombie>();
        newZombie.name = "Zombie";
        newZombie.transform.position = pos;
        newZombie.InitializeUnit();
        zombies.Add(newZombie);
    }

    private bool GetValidSpot(out Vector2 validSpot)
    {
        Bounds wbounds = MainScript.instance.worldBounds.bounds;
        

        for (int i = 0; i < VALIDSPOT_ATTEMPTS_MAX; i++)
        {
            Vector2 spotInMap = new Vector2(Random.Range(-wbounds.extents.x, wbounds.extents.x), Random.Range(-wbounds.extents.y, wbounds.extents.y)) + (Vector2)wbounds.center;

            if (!Physics2D.OverlapCapsule(spotInMap, new Vector2(2, 2), CapsuleDirection2D.Vertical, 0, LayerMask.GetMask("Unit","Ground")))
            {
                validSpot = spotInMap;
                return true;
            }
        }
        validSpot = new Vector2();
        return false;
    }

    #region GetClosestHardCoded
    public Human GetClosestHumanToPoint(Vector2 pt, bool includePlayer)
    {
        Human closestHuman = null;
        float closestDistance = float.MaxValue;
        float distance = 0; //reuse var to keep stack memory lightweight
        List<Human> humansToCheck = new List<Human>(humans);
        if (includePlayer)
            humansToCheck.AddRange(PlayerManager.Instance.players);

        foreach(Human h in humansToCheck)
        {
            distance = Vector2.SqrMagnitude((Vector2)h.transform.position - pt);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestHuman = h;
            }
        }
        return closestHuman;
    }

    public Zombie GetClosestZombieToPoint(Vector2 pt)
    {
        Zombie closestZombie = null;
        float closestDistance = float.MaxValue;
        float distance = 0; //reuse var to keep stack memory lightweight
        foreach (Zombie z in zombies)
        {
            distance = Vector2.SqrMagnitude((Vector2)z.transform.position - pt);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestZombie = z;
            }
        }
        return closestZombie;
    }

    public Player GetClosestPlayerToPoint(Vector2 pt)
    {
        Player closestPlayer = null;
        float closestDistance = float.MaxValue;
        float distance = 0; //reuse var to keep stack memory lightweight
        foreach (Player p in PlayerManager.Instance.players)
        {
            distance = Vector2.SqrMagnitude((Vector2)p.transform.position - pt);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = p;
            }
        }
        return closestPlayer;
    }
    #endregion

}
