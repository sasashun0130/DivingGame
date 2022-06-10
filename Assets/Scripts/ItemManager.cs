using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public  Text ItemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "zanup"){
            SendMessage("ZanUp");
            Destroy(collision.gameObject);
            ItemText.text = "écà≥Ç™20âÒïúÇµÇΩÅI";
            ItemText.gameObject.SetActive(true);
            Invoke("DeleteText", 1f);
        }
        if(collision.gameObject.tag == "kaihuku"){
            SendMessage("NotPoison");
            Destroy(collision.gameObject);
        }
    }

    void  DeleteText()
    {
        ItemText.gameObject.SetActive(false);
    }

}
