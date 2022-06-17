using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class DiverController : MonoBehaviour
{
    public float speed = 1.5f;
    private float speedMod = 0;

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    public GameObject bubbles;
    public GameObject death;

    public bool attack;

    public float attacktime = 1.0f;
    public bool isAttacking = false;

    public static float zanatu = 180.0f;
    public Text ZanatuText;

    public Text PoisonText;
    public static bool isPoison;
    public float poisontimer = 0f;
    public float poisonlimit = 5f;

    public PostProcessVolume effect;

    public AudioClip enemy;
    public AudioClip poison;
    public AudioClip recovery;
    public AudioClip playeraudio;
    private AudioSource mysource;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mysource = GetComponent<AudioSource>();
        isPoison = false;
        attack = false;

        effect.isGlobal = false;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        resetAttackTime();

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnim.SetBool("attack",attack);

        ZanatuManager();

    }


    //Playerの動きを入力されたボタンによって判定
    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0){
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
        
        if (Input.GetKeyDown(KeyCode.Space)){
            isAttacking = true;
            zanatu -= 5;
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            speedMod = 1f;
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        if(transform.localScale.x == 1){
            myRigidBody.velocity = new Vector3(speed + speedMod, myRigidBody.velocity.y, 0);
        }
        else{
            myRigidBody.velocity = new Vector3(-(speed + speedMod), myRigidBody.velocity.y, 0);
        }
    }

    void resetAttackTime()
    {
        if (attacktime <= 0){
            attacktime = 1f;
            isAttacking = false;
            speedMod = 0;
        }
        else if (isAttacking){
            attacktime -= Time.deltaTime;
        }
    }

    //敵判定DiverAbilityで残圧処理
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAttacking == false)
        {
            if (collision.gameObject.tag == "Enemy"){
                zanatu -= 20;
                mysource.PlayOneShot(playeraudio);
                attack = true;
                Invoke("Attack", 0.7f);
              
            }
            if (collision.gameObject.tag == "PoisonEnemy"){
                zanatu -= 10;
                mysource.PlayOneShot(poison);
                isPoison = true;
                attack = true;
                effect.isGlobal = true;
                Invoke("Attack", 0.7f);
            }
            
        }
        else{
            Destroy(collision.gameObject);
            mysource.PlayOneShot(enemy);
            if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PoisonEnemy")
            {
                Instantiate(death, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }
        }
    }

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
            PoisonText.text = "！毒感染中！";
            PoisonText.gameObject.SetActive(true);
            if (poisontimer > poisonlimit){
                poisontimer = 0f;
                isPoison = false;
                effect.isGlobal = false;
                PoisonText.gameObject.SetActive(false);
            }
        }

        if (zanatu < 0.0f){
            SceneManager.LoadScene("GameOverStage");
            zanatu = 180.0f;
        }
    }

    void Attack(){
        attack = false;
    }

    void ZanUp(){
        zanatu += 20;
        mysource.PlayOneShot(recovery);
    }

    void NotPoison(){
        mysource.PlayOneShot(recovery);
        if(isPoison == true)
        {
            isPoison = false;
            effect.isGlobal = false;
            PoisonText.text = "毒から回復した！";
            PoisonText.gameObject.SetActive(true);
            Invoke("DeleteText", 1f);
        }
        else
        {
            PoisonText.text = "残圧が10回復した！";
            PoisonText.gameObject.SetActive(true);
            Invoke("DeleteText", 1f);
        }
    }

    void DeleteText()
    {
        PoisonText.gameObject.SetActive(false);
    }

}
