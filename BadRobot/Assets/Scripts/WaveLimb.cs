using UnityEngine;
using System.Collections;

public class WaveLimb : MonoBehaviour
{
	public Transform mainBodyJoint;
	public Transform handJoint;
	public Transform firstJoint;
	public Transform lastJoint;

	public float controlPointMultiplier = 0.5f;

	private int jointCount = 0;

	void Awake()
	{
		for (Transform joint = firstJoint; joint != lastJoint; joint = joint.GetChild(0))
			jointCount++;
		jointCount++;
	}
		
	void FixedUpdate()
	{
		Vector3 firstPosition, lastPosition;
		
		//apply first
		transform.position = mainBodyJoint.position;
		transform.up = mainBodyJoint.forward;
		firstPosition = transform.position;

		//calculate last
		lastJoint.right = handJoint.up;
		lastJoint.up = -handJoint.forward;
		Vector3 distance = lastJoint.position - lastJoint.GetChild(0).position;
		lastPosition = handJoint.position + distance;

		//bezier method:
		float cpDistance = Mathf.Abs((lastPosition - firstPosition).magnitude) * controlPointMultiplier;
		Vector3 cp1 = firstPosition + transform.up * cpDistance;
		Vector3 cp2 = lastPosition - lastJoint.up * cpDistance;
		Transform prev = transform;
		int i = 0;
		for (Transform joint = firstJoint; joint != lastJoint; joint = joint.GetChild(0))
		{
			i++;
			float u = (float) i / (float) jointCount;
			Vector3 currentPoint = Bezier.getBezierCurvePoint(firstPosition, cp1, cp2, lastPosition, u);
			joint.position = currentPoint;
			joint.forward = prev.forward;
			joint.right = prev.right;
			joint.up = currentPoint - prev.position;
			prev = joint;
		}

		//apply last (previous joints changed this)
		lastJoint.right = handJoint.up;
		lastJoint.up = -handJoint.forward;
		lastJoint.position = lastPosition;
	}
}