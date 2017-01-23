using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ClawHand : MonoBehaviour
{
	public Animator myClaw;
	public string clawParameterName;

	private SteamVR_TrackedObject steamvr;
	private bool isTriggerDown = false;
	private Transform hovering = null;
	private Transform holding = null;

	private Vector3 lastPosition;
	private Vector3 lastRotation;

	void Awake()
	{
		steamvr = GetComponent<SteamVR_TrackedObject>();
	}

	void Start()
	{
		
	}
		
	void FixedUpdate()
	{
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)steamvr.index);

		isTriggerDown = device.GetTouch(SteamVR_Controller.ButtonMask.Trigger);
		myClaw.SetBool(clawParameterName, !isTriggerDown);

		if (hovering != null && isTriggerDown && holding == null)
		{
			holding = hovering;
			holding.parent = transform;
			Rigidbody rb = holding.GetComponent<Rigidbody>();
			rb.useGravity = false;
			rb.isKinematic = true;

			holding.GetComponent<StatePatternBob>().enabled = false;
			holding.GetComponent<NavMeshAgent>().enabled = false;
			SkinnedMeshRenderer smr = holding.GetComponent<SkinnedMeshRenderer>();
			if(smr != null)
				smr.SetBlendShapeWeight(0, 100);
		}

		if (holding != null && !isTriggerDown)
		{
			Rigidbody rb = holding.GetComponent<Rigidbody>();
			holding.parent = null;
			holding = null;

			rb.velocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
			rb.angularVelocity = (transform.eulerAngles - lastRotation) / Time.fixedDeltaTime;
			rb.useGravity = true;
			rb.isKinematic = false;
		}

		lastPosition = transform.position;
		lastRotation = transform.eulerAngles;
	}
		
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Vehicle")
			hovering = other.transform;
		if (other.gameObject.tag == "Enemy")
		{
			//other.GetComponent<Animator>().SetTrigger("isRoboStag");
			other.GetComponent<DumbDamage>().damage();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.transform == hovering)
			hovering = null;
	}

		void OnCollisionEnter(Collision collision)
	{
		print("hit coll");
	}
}