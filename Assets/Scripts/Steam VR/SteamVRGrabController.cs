using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

[System.Serializable]
public class Vector3Event : UnityEvent<Vector3> {}

public class SteamVRGrabController : SteamVRGrabbable
{
	public Vector3Event thrustEvent;
	public Transform ship;

	public SteamVR_Action_Boolean activateBool;

	private SteamVRPlayer player;

	public override void Awake()
	{
		base.Awake(); 

		player = FindObjectOfType<SteamVRPlayer>();

		//if (thrustEvent == null)
		//	thrustEvent = new UnityEvent<Vector3>(); 
	}

	private void Update()
	{
		if(player.GetAction(activateBool) && grabbed)
		{
			onActivate();
		}
	}

	public void onActivate()
	{
		thrustEvent.Invoke(ship.forward);
	}
}
