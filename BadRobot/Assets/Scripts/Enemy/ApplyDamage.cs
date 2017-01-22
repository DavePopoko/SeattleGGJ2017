using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class ApplyDamage : MonoBehaviour
{
    public int componentMaxHP = 10;
    public int componentHP = 10;

    int blendShapeCount;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    private Mesh skinnedMesh;
    float damage = 0f;
    public int blendIndex = 0;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;
        //Sanity check
        if (blendIndex > (blendShapeCount - 1))
        {
            Debug.Log("Index outside of Blend Shape array.  This will explode later.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Took Damage");

            //int incomingdamage = other.GetComponent<WeaponPropery>().Damage; // Incoming Player Weapon must have WeaponProperty
            int incomingdamage = 1;
            componentHP -= incomingdamage;
            if (componentHP < 0) componentHP = 0;

            damage = 100f -((componentHP*100)/componentMaxHP);
            if (damage > 100f) damage = 100.0f;

            float horizontalSliderPos = skinnedMeshRenderer.GetBlendShapeWeight(0);
            skinnedMeshRenderer.SetBlendShapeWeight(blendIndex, damage);     
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var p = 1;
    }
}