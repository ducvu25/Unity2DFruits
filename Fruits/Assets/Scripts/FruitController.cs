using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitController : MonoBehaviour
{
    int level = 0;
    bool controlWithPlayer = true;
    bool spawn = true;

    [SerializeField] float speed = 5f;
    [SerializeField] float distance = 2;
    Vector3 pInit;
    public bool isMatch = true;
    Rigidbody2D rb;
    float moveX;


    GameController controller;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = FindAnyObjectByType<GameController>();
    }
    // Start is called before the first frame update
    void Start()
    {

        rb.gravityScale = 0;
        pInit = transform.position;
        for (int i=0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        level = Rand();
        transform.GetChild(level).gameObject.SetActive(true);
    }
    void Run()
    {
        rb.velocity = new Vector2(moveX*speed, 0);
        if((transform.position.x - pInit.x < -distance && rb.velocity.x < 0) || (transform.position.x - pInit.x > distance && rb.velocity.x > 0))
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void Update()
    {
        if (controlWithPlayer)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                moveX = -1;
            else if (Input.GetKey(KeyCode.RightArrow))
                moveX = 1;
            else
                moveX = 0;
            Run();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.gravityScale = 1;
                controlWithPlayer = false;
            }
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FruitController fruitController = collision.transform.GetComponent<FruitController>();
        if(fruitController != null)
        {
            if (collision.transform.CompareTag("Fruits") && fruitController.isMatch && isMatch && !controlWithPlayer && level < 10
            && fruitController.Level == level)
            {
                if (level != 0)
                {
                    controller.Spawn(transform.position, collision.transform.position, level + 1);
                }
                isMatch = false;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
        if (spawn)
        {
            controller.Spawn();
            spawn = false;
        }
        
    }
    public int Level
    {
        get { return level; }
        set { level = value;
            controlWithPlayer = false;
            transform.GetChild(level).gameObject.SetActive(true);
            transform.GetComponent<Animator>().SetTrigger("Zoom");
            rb.gravityScale = 1;
        }
    }

}
