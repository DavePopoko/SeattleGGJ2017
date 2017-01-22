using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingTimedDestruct : MonoBehaviour {

    public float timer = 5.0f;
    public AudioClip breakingSound;

    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(breakingSound, 0.4f);
        StartCoroutine(Kaboom());
    }

    IEnumerator Kaboom()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}