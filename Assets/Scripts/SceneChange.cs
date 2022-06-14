using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**Playerが何かにぶつかった時に起こる処理のScripts
 */

public class SceneChange: MonoBehaviour {

    public AudioClip audio;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //各フロアにおける階段によって次のステージに変遷
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Stair")
        {
            FadeManager.Instance.LoadScene("2ndStage", 2.0f);
            source.PlayOneShot(audio);
        }
        else if (collision.gameObject.tag == "Stair1")
        {
            FadeManager.Instance.LoadScene("3rdStage", 2.0f);
            source.PlayOneShot(audio);
        }
        //else if (collision.gameObject.tag == "FalseStair")
        //{
        //    source.PlayOneShot(audio);
        //    int stage = Random.Range(1, 11);
        //    if (stage < 7)
        //    {
        //        SceneManager.LoadScene("BStage");
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene("CStage");
        //    }
        //}
        else if (collision.gameObject.tag == "Treasure")
        {
            FadeManager.Instance.LoadScene("ResultStage", 2.0f);
            source.PlayOneShot(audio);
        }
        else if (collision.gameObject.tag == "FalseTresure")
        {
            FadeManager.Instance.LoadScene("GameOverStage", 2.0f);
            source.PlayOneShot(audio);
        }
    }
}
