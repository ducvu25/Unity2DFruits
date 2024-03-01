using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitController : MonoBehaviour
{
    int level = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        level = Rand();
        transform.GetChild(level).gameObject.SetActive(true);
    }
    int Rand()
    {
        float[] probabilitis = { 20, 100, 75, 32, 16, 8, 2, 1, 0.2f };
        List<int> list = new List<int>();
        float x = Random.Range(0, 100);
        for(int i = 0; i<probabilitis.Length; i++)
            if (probabilitis[i] >= x)
                list.Add(i);
        //return list[Random.RandomRange(0, list.Count)];
        return Random.RandomRange(0, transform.childCount);
    }
    public int Level
    {
        get { return level; }
        set { level = value; 
            transform.GetChild(level).gameObject.SetActive(true);
            transform.GetComponent<Animator>().SetTrigger("Zoom");
        }
    }

}
