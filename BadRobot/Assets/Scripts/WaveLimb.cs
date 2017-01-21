using UnityEngine;
using System.Collections;

public class WaveLimb : MonoBehaviour
{
	public Transform mainBodyJoint;
	public Transform handJoint;
	public Transform[] internalJoints;

	void Awake()
	{
		
	}

	void Start()
	{
		
	}
		
	void FixedUpdate()
	{
		Vector3 firstPosition, lastPosition;
		//first
		transform.position = mainBodyJoint.position;
		transform.up = mainBodyJoint.forward;
		firstPosition = transform.position;

		//last
		Transform last = internalJoints[internalJoints.Length - 1];
		last.right = handJoint.up;
		last.up = -handJoint.forward;
		Vector3 distance = last.position - last.GetChild(0).position;
		lastPosition = handJoint.position + distance;

		float countJointSteps = internalJoints.Length;
		Vector3 distancePerStep = (last.position - transform.position) / countJointSteps;
		float anglePerStep = Vector3.Angle(transform.up, last.up) / countJointSteps;
		Vector3 axis = Vector3.Cross(transform.up, last.up);
		for(int i = 0; i < internalJoints.Length - 1; i++)
		{
			internalJoints[i].position = transform.position + distancePerStep * (i + 1);
			internalJoints[i].localRotation = Quaternion.AngleAxis(anglePerStep * (i + 1), axis);
			internalJoints[i].up = lastPosition - firstPosition;
		}

		//apply last
		last.right = handJoint.up;
		last.up = -handJoint.forward;
		last.position = lastPosition;
	}
		
	void Update()
	{
		
	}
}