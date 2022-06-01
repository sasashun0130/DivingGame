using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public float speed = 1.0f;
    public Text text;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.color = GetAlphaColor(text.color);


        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("1stStage");
        }
    }

    public Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time * 0.75f);

        return color;
    }
}
