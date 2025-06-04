using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Security.Cryptography;
public class Stage4Manager : MonoBehaviour
{
    int keys = 0;
    public GameObject wall1;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming Rosa;
    public TextMeshProUGUI key_count;
    public GameObject storybox;
    public TextMeshProUGUI story;
    public static bool checkpoint = false;
    public Key key1;
    public Key key2;
    public Key key3;
    public Key key4;
    public Key key5;
    void Start()
    {
        storybox.SetActive(false);
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(-5, 396);
            Platforming.keys = 5;
            key1.gameObject.SetActive(false);
            key2.gameObject.SetActive(false);
            key3.gameObject.SetActive(false);
            key4.gameObject.SetActive(false);
            key5.gameObject.SetActive(false);
        }
        else
        {
            Platforming.keys = 0;
        }

    }


    void Update()
    {
        keys = Platforming.keys;
        if (Rosa.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }
        if (keys < 5)
        {
            key_count.text = keys.ToString() + "/5 keys";
        }
        if (keys == 5)
        {
            key_count.text = "Gate Open";
            wall1.SetActive(false);
        }

        if (Rosa.transform.position.x > -14 && Rosa.transform.position.x < 0 && Rosa.transform.position.y > -65 && Rosa.transform.position.y < -40)
        {
            storybox.SetActive(true);
            story.text = "Are we the real monsters";
        }
        else if (Rosa.transform.position.x > 17 && Rosa.transform.position.x < 63 && Rosa.transform.position.y > 175 && Rosa.transform.position.y < 200)
        {
            storybox.SetActive(true);
            story.text = "Will we lose our humanity along the way";
        }
        else if (Rosa.transform.position.x > -17 && Rosa.transform.position.x < 0 && Rosa.transform.position.y > 390 && Rosa.transform.position.y < 450)
        {
            storybox.SetActive(true);
            story.text = "We will carry this guilt forever";
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.x > -5 && Rosa.transform.position.y > 392)
        {
            checkpoint = true;
        }
    }
}
