using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
	public Transform[] panels;
	public Transform[] wires;
	public SkinnedMeshRenderer smr;

	public float damage = 0f;

	void Update()
	{
		addDamage((float) Random.Range(-10, 10));
	}

	public void addDamage(float value = 10)
	{
		if (damage >= 100f)
			return;

		damage += value;
		if(damage >= 100f)
		{
			foreach(Transform t in wires)
				t.gameObject.SetActive(true);
			foreach (Transform t in panels)
				t.gameObject.SetActive(false);
			smr.SetBlendShapeWeight(0, damage);
		}
	}
}