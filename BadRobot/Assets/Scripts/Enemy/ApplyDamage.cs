using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ApplyDamage : MonoBehaviour
{
    public int componentMaxHP = 10;
    public int componentHP = 10;
    public string componentName = "BodyPart";
    public string parentType = "type";
    [HideInInspector] public bool tookDamage = false;
    [HideInInspector] public Collider incomingCollider;
    public string TagNametoDetect = "Weapon";
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNametoDetect))
        {
            if (!tookDamage)
            {
                //flags this component for aggregation
                Debug.Log("Weapon Collision");
                tookDamage = true;
                incomingCollider = other;
            }
        }
    }
}