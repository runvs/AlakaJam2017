using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleScript : MonoBehaviour {

    public GameObject Collider;
    public float fireTimer = .25f;
    private float nextFire;
    public int gunDamage = 1;
    public float hitForce = 100f;
    public Collector col;

    private BoxCollider c;
    private Camera fpsCam;

    public Collider[] others;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.1f);
    // Use this for initialization
    void Start ()
    {
        fpsCam = GetComponentInParent<Camera>();
        nextFire = 0;
        c = Collider.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireTimer;
            System.Console.Out.WriteLine("hack");


            others =  Physics.OverlapBox(Collider.transform.position, new Vector3(3, 3, 3));

            foreach (Collider c in others)
            {
                if (c.gameObject.tag == "Attackable")
                {

                    //c.gameObject.GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * hitForce);

                    RespawnScript rs = c.gameObject.GetComponent<RespawnScript>();
                    if (rs != null)
                    {
                        col.Collect(rs.type);
                        this.StartCoroutine(rs.RespawnEffect());
                        rs.gameObject.SetActive(false);
                    }
                }
            }
        }
	}



}


