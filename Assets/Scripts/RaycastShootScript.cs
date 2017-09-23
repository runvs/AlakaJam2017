using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShootScript : MonoBehaviour {


    public int gunDamage = 1;
    public float fireTimer = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public Collector col;

    public int ammunition = 2;
    public UnityEngine.UI.Text ammunitionText;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.0125f);
    private LineRenderer laserLine;
    private float nextFire;



	void Start ()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        ammunitionText.text = "Ammunition: " + ammunition.ToString();


        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && ammunition > 0)
        {
            ammunition--;
            nextFire = Time.time + fireTimer;
            StartCoroutine(ShotEffect());
            System.Console.WriteLine("shoot");

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            laserLine.SetPosition(0, gunEnd.position);
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward,out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                    RespawnScript rs = hit.transform.gameObject.GetComponent<RespawnScript>();
                    if (rs != null)
                    {
                        col.Collect(rs.type);
                        this.StartCoroutine(rs.RespawnEffect());
                        rs.gameObject.SetActive(false);
                    }


                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
            laserLine.SetPosition(1, hit.point);
        }
	}

    private IEnumerator ShotEffect()
    {
        
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
