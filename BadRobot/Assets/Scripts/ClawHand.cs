using UnityEngine;
using System.Collections;

public class ClawHand : MonoBehaviour
{
	public Animator myClaw;
	public string clawParameterName;

	private SteamVR_TrackedObject steamvr;

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

		myClaw.SetBool(clawParameterName, !device.GetTouch(SteamVR_Controller.ButtonMask.Trigger));
	}
		
	void Update()
	{
		
	}
}