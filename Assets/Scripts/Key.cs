using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isCollected = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (isCollected)
        {
            gameObject.SetActive(false) ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Rosa"))
        {
            Platforming player = collision.GetComponent<Platforming>();
            isCollected = true;
        }


    }
}
