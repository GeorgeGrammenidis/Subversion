using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class BonusManager : MonoBehaviour
{
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming Rosa;
    public Image current_image;

    void Start()
    {

    }

    void Update()
    {
        if (Rosa.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }

        
    }
}
