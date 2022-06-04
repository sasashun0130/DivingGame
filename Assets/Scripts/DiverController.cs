using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiverController : MonoBehaviour
{
    public float speed = 1.5f;
    private float speedMod = 0;

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public bool attacked = false;
    public float attackedtime;
    public GameObject bubbles;

    public float attacktime = 1.0f;
    public bool isAttacking = false;

    public float zanatu = 200.0f;
    public Text ZanatuText;

    public Text PoisonText;
    public bool isPoison;
    public float poisontimer = 0f;
    public float poisonlimit = 5f;

    //public static int power = 1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        isPoison = false;
        attacked = false;
        attackedtime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        resetAttackTime();

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnim.SetBool("attacked",attacked);

        ZanatuManager();

    }


    //Playerの動きを入力されたボタンによって判定
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
            isAttacking = true;
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            speedMod = 2f;
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if(transform.localScale.x == 1)
        {
            myRigidBody.velocity = new Vector3(speed + speedMod, myRigidBody.velocity.y, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-(speed + speedMod), myRigidBody.velocity.y, 0);
        }
    }

    void resetAttackTime()
    {
        if (attacktime <= 0)
        {
            attacktime = 1f;
            isAttacking = false;
            speedMod = 0;
        }
        else if (isAttacking)
        {
            attacktime -= Time.deltaTime;
        }
    }

    //敵判定DiverAbilityで残圧処理
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAttacking == false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                zanatu -= 20;
                //Debug.Log("Damage");
                attacked = true;
                Debug.Log(attacked);
            }
            if (collision.gameObject.tag == "PoisonEnemy")
            {
                isPoison = true;
                attacked = true;
                //Debug.Log("Poison");
                Debug.Log(attacked);
            }
            attackedtimer();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    //残圧を時間経過によって減少させていく
    //残圧がゼロになったらゲームオーバー
    void ZanatuManager()
    {
        if (isPoison == false)
        {
            zanatu -= 0.8f * Time.deltaTime;
            ZanatuText.text = "残圧：" + zanatu.ToString("f0");
        }
        else
        {
            zanatu -= 1.5f * Time.deltaTime;
            poisontimer += Time.deltaTime;
            ZanatuText.text = "残圧：" + zanatu.ToString("f0");
            PoisonText.gameObject.SetActive(true);
            if (poisontimer > poisonlimit)
            {
                poisontimer = 0f;
                isPoison = false;
                PoisonText.gameObject.SetActive(false);
            }
        }

        if (zanatu < 0.0f)
        {
            SceneManager.LoadScene("GameOverStage");
        }
    }

    private void attackedtimer()
    {
        attackedtime -= Time.deltaTime;

        if(attackedtime < 0)
        {
            attacked = false;
        }
    }
}
