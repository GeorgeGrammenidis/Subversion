using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ControllerButtonTester : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i <= 19; i++)
        {
            if (Input.GetKeyDown("joystick button " + i))
            {
                Debug.Log("Button " + i + " pressed");
            }
        }
    }
}