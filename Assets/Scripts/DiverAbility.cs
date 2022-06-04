using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**Player�̎c������������Script
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

    // Start is called before the first frame update
    void Start()
    {
        isPoison = false;
        poisontimer = 0f;
        poisonlimit = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ZanatuManager();
    }

    ////�G����DiverAbility�Ŏc������
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

    //�c�������Ԍo�߂ɂ���Č��������Ă���
    //�c�����[���ɂȂ�����Q�[���I�[�o�[
    void ZanatuManager()
    {
        if (isPoison == false)
        {
            zanatu -= 0.8f * Time.deltaTime;
            ZanatuText.text = "�c���F" + zanatu.ToString("f0");
        }
        else
        {
            zanatu -= 1.5f * Time.deltaTime;
            poisontimer += Time.deltaTime;
            ZanatuText.text = "�c���F" + zanatu.ToString("f0");
            PoisonText.gameObject.SetActive(true);
            if(poisontimer > poisonlimit)
            {
                poisontimer = 0f;
                isPoison = false;
                PoisonText.gameObject.SetActive(false);
            }
        }

        if (zanatu < 0.0f){
            SceneManager.LoadScene("GameOverStage");
        }
    }

}
