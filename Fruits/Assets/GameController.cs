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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(goFruitPrefabs, pSpawn.position + new Vector3(Random.Range(-distanceSpawn, distanceSpawn), 0, 0), Quaternion.identity);
    }
}
