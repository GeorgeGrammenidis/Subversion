using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stone : MonoBehaviour
{
    public int stone_index = 1;
    void Start()
    {
        if (PlayerPrefs.GetInt($"Stone_{stone_index}", 0) == 1)
        {
            gameObject.SetActive(false); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rosa"))
        {
            CollectStone();
        }
    }

    private void CollectStone()
    {
        PlayerPrefs.SetInt($"Stone_{stone_index}", 1);
        //PlayerPrefs.Save(); 
        gameObject.SetActive(false);
    }


}
