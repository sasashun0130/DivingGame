using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

/**Playerの残圧を処理するScript
 */

public class DiverAbility: MonoBehaviour
{
    public static float zanatu = 200.0f;
    public Text ZanatuText;

    public Text PoisonText;
    public bool isPoison;
    public float poisontimer;
    public float poisonlimit;

    public static int power = 1;

    public bool Poison = false;

    // Start is called before the first frame update
    void Start()
    {
        isPoison = false;
        poisontimer = 0f;
        poisonlimit = 5.0f;

        Debug.Log(Poison);

        Poison = GameObject.Find("PisonVolume").gameObject.GetComponent<PostProcessVolume>().isGlobal;
        Debug.Log(Poison);
        Poison = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ZanatuManager();
    }

    ////敵判定DiverAbilityで残圧処理
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (isAttacking == false)
    //    {
    //        if (collision.gameObject.tag == "Enemy")
    //        {
    //            zanatu -= 20;
    //        }
    //        if (collision.gameObject.tag == "PoisonEnemy")
    //        {
    //            isPoison = true;
    //        }
    //    }
    //    else
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}

    //残圧を時間経過によって減少させていく
    //残圧がゼロになったらゲームオーバー
    //void ZanatuManager()
    //{
    //    if (isPoison == false)
    //    {
    //        zanatu -= 0.8f * Time.deltaTime;
    //        ZanatuText.text = "残圧：" + zanatu.ToString("f0");
    //    }
    //    else
    //    {
    //        zanatu -= 1.5f * Time.deltaTime;
    //        poisontimer += Time.deltaTime;
    //        ZanatuText.text = "残圧：" + zanatu.ToString("f0");
    //        PoisonText.gameObject.SetActive(true);
    //        Poison = true;
    //        if(poisontimer > poisonlimit)
    //        {
    //            poisontimer = 0f;
    //            isPoison = false;
    //            Poison = false;
    //            PoisonText.gameObject.SetActive(false);
    //        }
    //    }

    //    if (zanatu < 0.0f){
    //        SceneManager.LoadScene("GameOverStage");
    //    }
    //}

}
