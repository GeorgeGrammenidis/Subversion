using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public TextMeshProUGUI Progress;
    public TextMeshProUGUI Beggining;
    private int stagesCompleted = 0;

    void Start()
    {
        int stone;
        int stones = 0;
        for (int i = 1; i < 26; i++)
        {
            stone = PlayerPrefs.GetInt($"Stone_{i}", 0);
            if (stone == 1)
            {
                Debug.Log("Stone: " + i);
                stones++;
            }
        }
        stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        if (stagesCompleted == 0)
        {
            Beggining.gameObject.SetActive(true);
            Progress.gameObject.SetActive(false);
        }
        else
        {
            Beggining.gameObject.SetActive(false);
            Progress.gameObject.SetActive(true);
        }
        Progress.text = "Progress so far: \nChapter " + (stagesCompleted + 1).ToString() + "\n" + stones + "/25 Stones Of Wisdom";
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Initiate.Fade("Chapter" + (stagesCompleted + 1).ToString(), Color.black, 0.5f);
        }
    }
}
