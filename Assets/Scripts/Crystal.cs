using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public float respawnTime = 5f;
    private SpriteRenderer spriteRenderer;
    private Collider2D crystalCollider;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        crystalCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rosa"))
        {
            StartCoroutine(RespawnCrystal());
        }
    }

    private IEnumerator RespawnCrystal()
    {
        spriteRenderer.enabled=false;
        crystalCollider.enabled=false;
        yield return new WaitForSeconds(respawnTime);
        spriteRenderer.enabled = true;
        crystalCollider.enabled = true;
    }
}
