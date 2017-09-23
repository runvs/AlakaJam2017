using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    public Action final;
    public float time;


    public void SetUpTimer(float t, Action a)
    {
        time = t;
        final = a;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            final();
            Destroy(this);
        }
    }
    
}
