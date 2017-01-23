using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DumbDamage : MonoBehaviour
{

	public GameObject me;
	public SkinnedMeshRenderer smr;
	public int i = 0;

	public void damage()
	{
		print("damage");
		if (i >= smr.sharedMesh.blendShapeCount)
			return;
		print("damaging");
		smr.SetBlendShapeWeight(i, 100);
		i++;
		me.GetComponent<Animator>().SetTrigger("isRoboStag");
		if (i >= smr.sharedMesh.blendShapeCount)
		{
			me.GetComponent<Animator>().SetTrigger("isRoboDeath");
			me.GetComponent<StatePatternBob>().enabled = false;
			me.GetComponent<NavMeshAgent>().enabled = false;
		}
	}
}