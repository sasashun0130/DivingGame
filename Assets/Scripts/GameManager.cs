using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float zanatu = 200.0f;
    public static int power = 1;
    public Text ZanatuText;


    // Start is called before the first frame update
    void Start()
    {
        //�X�e�[�W�J�ڂ��Ă��c���E�c�莞�ԁE�U���͂�ێ�
        //PlayerPrefs
    }

    // Update is called once per frame
    void Update()
    {
        //�c�������Ԍo�߂ɂ���Č��������Ă���.�c�����[���ɂȂ�����Q�[���I�[�o�[
        zanatu -= 0.8f * Time.deltaTime;
        ZanatuText.text = "�c���F" + zanatu.ToString("f0");

        if(zanatu == 0f)
        {
            SceneManager.LoadScene("GameOverStage");
        }
        
    }
}
