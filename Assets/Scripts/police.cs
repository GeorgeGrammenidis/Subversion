using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : Scene1Manager
{
    public GameObject officer1;
    public GameObject officer2;
    public bool alive = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (cur == 1 && alive!=false)
        {
            officer1.transform.Rotate(0, 0, 90);
            officer2.transform.Rotate(0, 0, 90);
            alive = false;
        }
    }
}
