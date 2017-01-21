using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToMeleeAttackState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToRangeAttackState()
    {

    }
}