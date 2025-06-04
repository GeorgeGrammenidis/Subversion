using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boost : MonoBehaviour
{
    public float respawnTime = 2f;
    private SpriteRenderer spriteRenderer;
    public bool charge = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Sword") && charge)
        {
            StartCoroutine(RechargeBoost());
        }
        

    }

    private IEnumerator RechargeBoost()
    {
        spriteRenderer.color = Color.red;
        charge = false;
        yield return new WaitForSeconds(respawnTime);
        spriteRenderer.color = Color.white;
        charge = true;
        
    }
}
