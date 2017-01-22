using UnityEngine;
using System.Collections;

public class MirrorCam : MonoBehaviour
{
	public Transform eyes;

	void Awake()
	{
		
	}

	void Start()
	{
		
	}
		
	void FixedUpdate()
	{
		Vector3 incoming = transform.position - eyes.position;
		float dx = Vector3.Dot(incoming, transform.right);
		float dy = Vector3.Dot(incoming, transform.up);
		float dz = Vector3.Dot(incoming, transform.forward);
		float thetaX = Mathf.Atan2(dy, dx);
		float thetaY = -Mathf.Atan2(dz, dy);
		float nx = Mathf.Cos(180 - thetaX);
		float ny = Mathf.Cos(180 - thetaY);
		float nz = Mathf.Sin(180 - thetaX);
		Vector3 lookAt = transform.TransformPoint(new Vector3(nx, ny, nz));
		//transform.up = Vector3.up;
		//transform.forward = lookAt;
	}
		
	void Update()
	{
		
	}
}