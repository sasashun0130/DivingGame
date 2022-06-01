using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiverController : MonoBehaviour
{
    public float speed = 1.5f;

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public GameObject bubbles;

    public static float zanatu = 200.0f;
    public Text ZanatuText;

    public static int power = 1;

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

        //残圧を時間経過によって減少させていく.残圧がゼロになったらゲームオーバー
        zanatu -= 0.8f * Time.deltaTime;
        ZanatuText.text = "残圧：" + zanatu.ToString("f0");

        if (zanatu < 0.0f)
        {
            SceneManager.LoadScene("GameOverStage");
        }

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
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            MovePlayer();
        }
        */
        
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
        if (collision.gameObject.tag == "Stair")
        {
            SceneManager.LoadScene("2ndStage");
        }
        else if (collision.gameObject.tag == "Stair1")
        {
            SceneManager.LoadScene("3rdStage");
        }
        else if (collision.gameObject.tag == "Stair2")
        {
            SceneManager.LoadScene("1stStage");
        }
        else if (collision.gameObject.tag == "FalseStair")
        {
            int stage = Random.Range(1, 11);
            if (stage < 7)
            {
                //Debug.Log(stage);
                SceneManager.LoadScene("BStage");
            }
            else
            {
                //Debug.Log(stage); 
                SceneManager.LoadScene("CStage");
            }
        }
        else if (collision.gameObject.tag == "Treasure")
        {
            SceneManager.LoadScene("ResultStage");
        }
        else if (collision.gameObject.tag == "FalseTresure")
        {
            SceneManager.LoadScene("GameOverStage");
        }



    }
}
