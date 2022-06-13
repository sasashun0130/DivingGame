using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**Playerが何かにぶつかった時に起こる処理のScripts
 */

public class SceneChange: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            SceneManager.LoadScene("2ndStage");
        }
        else if (collision.gameObject.tag == "Stair1")
        {
            SceneManager.LoadScene("3rdStage");
        }
        else if (collision.gameObject.tag == "FalseStair")
        {
            int stage = Random.Range(1, 11);
            if (stage < 7)
            {
                SceneManager.LoadScene("BStage");
            }
            else
            {
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
