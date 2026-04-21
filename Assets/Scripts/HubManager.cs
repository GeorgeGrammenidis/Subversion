using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    public GameObject Door1;
    public GameObject Door2;
    public DialogueTrigger Tristan;
    public DialogueTrigger Tristan2;
    public GameObject Museum;
    public CharacterController Rosa;
    int progress;
    void Start()
    {
        progress = progress = PlayerPrefs.GetInt("Chapter4Key", 0);
        if (!string.IsNullOrEmpty(CharacterController.lastdoor))
        {
            GameObject door = GameObject.Find(CharacterController.lastdoor);
            Rosa.transform.position = door.transform.position - new Vector3 (0, 1.5f, 0); 

        }
        if (progress==0){
            Door1.SetActive(false);
            Door2.SetActive(true);
            Museum.SetActive(false);
        }
        else if (progress == 1)
        {
            Door1.SetActive(true);
            Door2.SetActive(false);
            Museum.SetActive(false);
        }
        else if (progress == 2)
        {
            Door1.SetActive(true);
            Door2.SetActive(true);
            Museum.SetActive(true);
        }
    }

    void Update()
    {
        if (Tristan.hasSpoken && Rosa.canMove)
        {
            progress = 1;
            PlayerPrefs.SetInt("Chapter4Key",1);
            CharacterController.lastdoor = null;
            Initiate.Fade("Room", Color.black, 0.5f);
        }
        else if (Tristan2.hasSpoken && Rosa.canMove)
        {
            PlayerPrefs.SetInt("Chapter4Key", 2);
            CharacterController.lastdoor = null;
            Initiate.Fade("Room", Color.black, 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("Chapter4Key", 0);
            CharacterController.lastdoor = null;
            SceneManager.LoadScene("Hub");
        }

        
    }
}
