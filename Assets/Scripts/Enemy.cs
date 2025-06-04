using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] int speed = 10;
    GameObject player;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    public bool vertical = true;
    public bool move = false;
    public Platforming Rosa;
    public float x;
    public float y;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Rosa.transform.position.x > x && Rosa.transform.position.y> y)
        {
            move = true;
        }
        if (move) {

            if (vertical)
            {
                body.velocity = new Vector2(0, speed);
            }
            else
            {
                body.velocity = new Vector2(speed, 0);
            }
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Rosa") || collision.gameObject.tag.Equals("Sword"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (!collision.gameObject.tag.Equals("Enemy"))
        {
            DestroyObject(collision.gameObject);
        }

    }
}
