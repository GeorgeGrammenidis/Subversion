using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene72Manager : MonoBehaviour
{
    public GameObject Nava;
    public DialogueManager DialogueManager;
    int speed = 5;
    public Scene1Manager Scene1Manager;
    public CharacterController Rosa;
    public bool doonce = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (doonce && Scene1Manager.cur == 1)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {
        Rosa.canMove = false;
        Nava.SetActive(true);
        while (Vector3.Distance(Nava.transform.position, new Vector2(0, 0)) > 0.1f)
        {
            Nava.transform.position = Vector3.MoveTowards(
                Nava.transform.position,
                new Vector2(0, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }
        while (Vector3.Distance(Nava.transform.position, new Vector2(0, -5)) > 0.1f)
        {
            Nava.transform.position = Vector3.MoveTowards(
                Nava.transform.position,
                new Vector2(0, -5),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Nava.gameObject.SetActive(false);
        Rosa.canMove = true;
        Scene1Manager.cur++;
    }

}
