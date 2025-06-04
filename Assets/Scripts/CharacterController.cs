using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public bool canMove = true;
    bool moving;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public static string lastdoor;
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            Animate();
        }
        else
        {
            animator.SetBool("IsMoving", false);
            movement = Vector2.zero; 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void EnableMovement(bool enable)
    {
        canMove = enable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Exit"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else if (collision.gameObject.tag.Equals("Entrance"))
        {
            string sceneName = collision.gameObject.name;
            if (SceneManager.GetActiveScene().name=="Hub")
            {
                lastdoor = sceneName;
            }
            
            SceneManager.LoadScene(sceneName);

        }
        else if (collision.gameObject.tag.Equals("EndChapter2") ){

            SceneManager.LoadScene("End");
        }

        

    }

    void Animate()
    {
        if (movement.magnitude  > 0.1f || movement.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            animator.SetFloat("Horizontal" , movement.x);
            animator.SetFloat("Vertical" , movement.y);
        }
        animator.SetBool("IsMoving", moving);
    }
}
