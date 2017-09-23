using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmuPickup : MonoBehaviour
{
    public RaycastShootScript Gun;

    public MyTimer timerPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "DABA")
        {
            Debug.Log("stuff happens");
            Gun.ammunition++;
            other.gameObject.SetActive(false);


            MyTimer t = Instantiate(timerPrefab);
            t.SetUpTimer(2, () => { other.gameObject.SetActive(true); }  );
        }
    }
}
