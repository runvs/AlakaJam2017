using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarScript : MonoBehaviour {

    private UnityEngine.Light light;

    public float origy;
    public Collector col;
    

	// Use this for initialization
	void Start () {
        light = transform.parent.GetComponentInChildren<Light>();
        origy = light.transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {
        light.transform.position = new Vector3(light.transform.position.x, origy + Mathf.Sin(Time.time) * 3, light.transform.position.z);

    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if (other.tag == "Player")
        {
            if (col.CheckResults())
            {
                col.ResetAll();
            }
        }
    }

}
