using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiverController : MonoBehaviour
{
    public float speed = 1.0f;

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public GameObject bubbles;
    

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
    }

    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            MovePlayer();
        }
        else if(Input.GetAxisRaw("Horizontal") < 0){
            transform.localScale = new Vector3(-1, 1, 1);
            MovePlayer();
        }
        else if(Input.GetAxisRaw("Vertical") > 0){
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, speed, 0);
        }
        else if(Input.GetAxisRaw("Vertical") < 0){
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, -speed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            MovePlayer();
        }
        
    }

    void MovePlayer()
    {
        if(transform.localScale.x == 1)
        {
            myRigidBody.velocity = new Vector3(speed, myRigidBody.velocity.y, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-speed, myRigidBody.velocity.y, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            //Debug.Log("OK!");
            SceneManager.LoadScene("ResultStage");
        }
    }
}
