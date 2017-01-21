using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanState : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToScanState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToMeleeAttackState()
    {
    }

    public void ToRangeAttackState()
    {

    }
}