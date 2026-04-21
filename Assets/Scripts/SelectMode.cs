using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    public TextMeshProUGUI Mode1;
    public TextMeshProUGUI Mode2;
    public TextMeshProUGUI Info;
    public Transform selector;

    private int selectedOption = 0;
    private int stagesCompleted = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedOption == 0)
        {
            selector.position = Mode1.transform.position + new Vector3(-200f, 0, -5);
            Info.text = "Super Ego Mode also known as Story Mode, is the intended way to play. You will experience all of the story, characters and stages. Recommended for pretentious tossers.";
        }
        else if (selectedOption == 1)
        {
            selector.position = Mode2.transform.position + new Vector3(-130f, 0, -5);
            Info.text = "ID Mode also known as Arcade Mode, is for those who desire to only play through the stages. Recommended for impulsive chimps.";
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedOption == 0)
            {
                selectedOption = 1;
            }
            else if (selectedOption == 1)
            {
                selectedOption = 0;
            }
   
        }


        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedOption == 0)
            {
                PlayerPrefs.SetString("Mode", "Story");
                SceneManager.LoadScene("Map");
            }
            else if (selectedOption == 1)
            {
                PlayerPrefs.SetString("Mode", "Arcade");
                SceneManager.LoadScene("Arcade");
            }
        }
    }
}
