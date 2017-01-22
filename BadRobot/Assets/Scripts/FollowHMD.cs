using UnityEngine;
using System.Collections;

public class FollowHMD : MonoBehaviour
{
	public Transform hmd;
	public Transform headPivot;
		
	void FixedUpdate()
	{
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, hmd.eulerAngles.y, transform.eulerAngles.z);
		transform.position = hmd.position + (transform.position - headPivot.position);
	}
}