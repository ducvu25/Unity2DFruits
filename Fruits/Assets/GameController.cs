using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject goFruitPrefabs;
    [SerializeField] Transform pSpawn;
    [SerializeField] float distanceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Spawn()
    {
        Instantiate(goFruitPrefabs, pSpawn.position, Quaternion.identity);
    }
    public void Spawn(Vector3 p1, Vector3 p2, int level)
    {
        Vector3 p = (p1 + p2) / 2;
        GameObject go = Instantiate(goFruitPrefabs, p, Quaternion.identity);
        go.transform.GetComponent<FruitController>().Level = level;

    }
}
