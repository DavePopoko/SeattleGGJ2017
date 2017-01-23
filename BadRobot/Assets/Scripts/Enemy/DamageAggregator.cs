using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class DamageAggregator : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    int blendShapeCount;
    private Mesh skinnedMesh;
    [HideInInspector] public int blendIndex = 0;
    public ApplyDamage[] DamagableAreas;
    public int CurrentHP;
    public int MaxHP;

    void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    void Start()
    {
        blendShapeCount = skinnedMesh.blendShapeCount;

        foreach (ApplyDamage da in DamagableAreas)
        {
            CurrentHP += da.componentHP;
            MaxHP += da.componentMaxHP;
        }
    }

    void Update()
    {
        CurrentHP = 0;
        foreach (ApplyDamage da in DamagableAreas)
        {
            CurrentHP += da.componentHP;
            
            if (da.tookDamage)
            {
                int incomingdamage = da.incomingCollider.GetComponent<WeaponPropery>().Damage; // Incoming Player Weapon must have WeaponProperty
                
                Debug.Log("Hit! " + da.componentName + " for " + incomingdamage + " DMG!");

                da.componentHP -= incomingdamage;
                if (da.componentHP <= 0)
                {
                    da.componentHP = 0;
                }
                float damage = 0.0f;
                damage = 100f - ((da.componentHP * 100) / da.componentMaxHP);
                if (damage > 100f) damage = 100.0f;

                int index = LookupIndexByName(da.componentName);

                skinnedMeshRenderer.SetBlendShapeWeight(index, damage);
                da.tookDamage = false;
            }
        }
    }
    private static int LookupIndexByName(string Name)
    {
        int retval = 0;

        switch (Name)
        {
            case "HeadLeft":
                retval = 0;
                break;
            case "HeadCenter":
                retval = 1;
                break;
            case "HeadRight":
                retval = 2;
                break;
            case "ShoulderLeft":
                retval = 3;
                break;
            case "ShoulderRight":
                retval = 4;
                break;
            case "Torso":
                retval = 5;
                break;
            case "HandLeft":
                retval = 6;
                break;
            case "HandRight":
                retval = 7;
                break;
        }
        return retval;
    }
}