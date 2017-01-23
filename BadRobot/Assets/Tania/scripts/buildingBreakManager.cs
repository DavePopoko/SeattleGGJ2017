using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingBreakManager : MonoBehaviour {

    public GameObject remains;
    public Transform spawnPoints;

    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Finish"))
            {

                Instantiate(remains, spawnPoints.position, spawnPoints.rotation);
                Destroy(gameObject);
            }
        }  

// spawning test using ESC key
/*    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Instantiate(remains, spawnPoints.position, spawnPoints.rotation);
            Destroy(gameObject);
        }
    } */

}
