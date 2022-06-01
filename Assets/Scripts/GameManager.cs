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
        //ステージ遷移しても残圧・残り時間・攻撃力を保持
        //PlayerPrefs
    }

    // Update is called once per frame
    void Update()
    {
        //残圧を時間経過によって減少させていく.残圧がゼロになったらゲームオーバー
        zanatu -= 0.8f * Time.deltaTime;
        ZanatuText.text = "残圧：" + zanatu.ToString("f0");

        if(zanatu == 0f)
        {
            SceneManager.LoadScene("GameOverStage");
        }
        
    }
}
