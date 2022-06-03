using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemy : MonoBehaviour {

    public int enemyhp = 2;

    public float speed = 0.3f;

    private float turnTimer;
    public float timeTrigger = 3f;

    private Rigidbody2D myRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        turnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(myRigidbody.transform.localScale.x * speed, myRigidbody.velocity.y, 0f);

        turnTimer += Time.deltaTime;
        if(turnTimer > timeTrigger)
        {
            turnAround();
            turnTimer = 0;
        }
    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (enemyhp > 1)
            {
                enemyhp--;
                Debug.Log(enemyhp);
            }
            else
            {
                Destroy(gameObject);
                Debug.Log("Destroy");
            }
        }
    }

    void turnAround()
    {
        if(transform.localScale.x == 1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
