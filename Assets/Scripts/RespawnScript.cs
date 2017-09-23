using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{

    private WaitForSeconds WaitTilRespawn ;

    public int type;

	// Use this for initialization
	void Start ()
    {
        WaitTilRespawn = new WaitForSeconds(Random.Range(3, 15));

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnDisable()
    {
         WaitTilRespawn = new WaitForSeconds(Random.Range(3, 15));
        //StartCoroutine(RespawnEffect());
    }


    public IEnumerator RespawnEffect()
    {
        yield return WaitTilRespawn;
        this.gameObject.SetActive(true);
    }

}
