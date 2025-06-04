using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Platforming : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    //public StageManager stagemanager;
    bool isball1 = false;
    bool isball2 = false;
    bool tookrecord = false;
    float record1;
    float record2;
    float record3;
    int deaths;
    public Sprite normal;
    public Sprite ball;
    public Sprite ball2;
    public float deathheight = -20f;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public GameObject sword;
    //public Image status;
    public int orbs = 0;
    public bool swap = false;
    bool canjump = true;
    public static int keys = 0;
    private float horizontalInput;
    private float verticalInput;
    int stagesCompleted;
    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);

    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (isGrounded())
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
        
        if (Input.GetKeyDown(KeyCode.U) && stagesCompleted>2)
        {
            if (!swap)
            {
                swap = true;
            }
            else if (swap)
            {
                swap = false;
            }
        }
        if (Input.GetKey(KeyCode.H) && swap)
        {
            StartCoroutine(Hit());
        }
        if (isGrounded())
        {
            orbs = 0;
            if (body.velocity.y == 0) {
                canjump = true;
            }
        }
        if (horizontalInput > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        if (body.velocity.x != 0 && isGrounded())
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


        if  (Input.GetKeyDown(KeyCode.J))
        {
            if (isGrounded()) {

                body.velocity = new Vector2(body.velocity.x, height);
            }
            else if (!isGrounded() && orbs > 0)
            {
                orbs = 0;
                body.velocity = new Vector2(body.velocity.x, height);
            }
            else if (onWallleft() && !isGrounded())
            {
                body.velocity = new Vector2(speed, height);

            }
            else if (onWallright() && !isGrounded())
            {
                body.velocity = new Vector2(speed, height);

            }

        }
        if (body.velocity.y >0)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            if (tookrecord)
            {
                tookrecord = false;
            }
        }
        else if (body.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            if (!tookrecord)
            {
                record1 = transform.position.y;
                tookrecord = true;
            }
            
        }
        else
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (Input.GetKeyDown(KeyCode.H) && !swap && body.velocity.y < 0)
        {
            isball1 = true;
            animator.SetBool("short", true);
            spriteRenderer.sprite = ball;
            record2 = transform.position.y;
        }
        if (isGrounded() && !isball1)
        {
            tookrecord = false;
        }
        if (isGrounded() && isball1)
        {
            isball1 = false;
            spriteRenderer.sprite = normal;
            if ((record1 - record2) * 3 > 40) {
                body.velocity = new Vector2(body.velocity.x, 40);
                StartCoroutine(Short());
            }
            else
            {
                body.velocity = new Vector2(body.velocity.x, (record1 - record2) * 3);
                StartCoroutine(Short());
            }

        }

        if ((Input.GetKeyDown(KeyCode.K) && body.velocity.y < 0) && canjump)
        {
            isball2 = true;
            animator.SetBool("long", true);
            spriteRenderer.sprite = ball2;
            record3 = transform.position.y;
            canjump = false;

        }
        if (isGrounded() && !isball2 && !isball1)
        {
            tookrecord = false;
            //canjump = true;
        }

        else if (isGrounded() && isball2)
        {
            isball2 = false;
            spriteRenderer.sprite = normal;
            body.velocity = new Vector2(body.velocity.x, (record1 - record3) * 3);
            StartCoroutine(Long());



        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }

        isFallen();
    }

    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deaths = PlayerPrefs.GetInt("deaths", 0);
        deaths = deaths + 1;
        PlayerPrefs.SetInt("deaths" , deaths);
    }
    private void isFallen()
    {
        if (transform.position.y < deathheight)
        {
            Death();
            
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Orb"))
        {
            orbs++;
        }
        if (collision.gameObject.tag.Equals("Key"))
        {
            keys++;
        }
        if (collision.gameObject.tag.Equals("End"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            string nextScenePath = SceneUtility.GetScenePathByBuildIndex(currentSceneIndex + 1);
            string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(nextScenePath);
            keys = 0;
            Initiate.Fade(nextSceneName, Color.black, 0.5f);
            
        }
        if (collision.gameObject.tag.Equals("Hazard"))
        {
            Death();
        }
        if (collision.CompareTag("Teleporter"))
        {
            Teleporter teleporter = collision.GetComponent<Teleporter>();
            transform.position = teleporter.teleportLocation;
            body.velocity = Vector2.zero;
        }
        if (collision.gameObject.tag.Equals("Speed"))
        {
            DestroyObject(collision.gameObject);
            speed = speed * 2;
        }
        if (collision.gameObject.tag.Equals("Potion"))
        {
            DestroyObject(collision.gameObject);
            speed = 15;
        }

    }

    private bool onWallright()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private bool onGroundright()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onGroundleft()
    {

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.left, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWallleft()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.left, 0.1f, wallLayer);

        return raycastHit.collider != null;
    }
    private IEnumerator Long()
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("isJumping", true); 
        animator.SetBool("long", false);
    }

    private IEnumerator Short()
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("isJumping", true);
        animator.SetBool("short", false);
    }

    private IEnumerator Hit()
    {
        sword.SetActive(true);
        animator.SetBool("isAttacking",true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("isAttacking", false);
        sword.SetActive(false);

    }


}
