using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour {

    public GameObject Crossbow;
    public GameObject Sickle;
    public GameObject Bombs;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Select1"))
        {
            SwitchToSickle();
        }
        if (Input.GetButtonDown("Select2"))
        {
            SwitchToCrossbow();
        }
        //if (Input.GetButtonDown("Select3"))
        //{
        //    SwitchToBombs();
        //}
    }

    private void SwitchToSickle()
    {
        Sickle.SetActive(true);
        Crossbow.SetActive(false);
        Bombs.SetActive(false);
    }

    private void SwitchToCrossbow()
    {
        Sickle.SetActive(false);
        Crossbow.SetActive(true);
        Bombs.SetActive(false);
    }

    private void SwitchToBombs()
    {
        Sickle.SetActive(false);
        Crossbow.SetActive(false);
        Bombs.SetActive(true);
    }
}
