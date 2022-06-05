using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**‹›‚Ì“G‚Ì“®‚«‚ğˆ—‚·‚éScript
 */

public class FishEnemy : MonoBehaviour
{
    public float speed = 0.3f;

    private float turnTimer;
    float timeTrigger;

    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        turnTimer = 0;
        timeTrigger = Random.Range(2, 6);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(myRigidbody.transform.localScale.x * speed, myRigidbody.velocity.y, 0f);

        turnTimer += Time.deltaTime;
        if (turnTimer > timeTrigger){
            turn();
            turnTimer = 0;
        }

    }

    void turn()
    {
        if (transform.localScale.x == 1){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else{
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
