using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamVRPlayer : MonoBehaviour
{
	public SteamVR_Action_Boolean teleportAction;
	public SteamVR_Action_Boolean grabAction;
	public SteamVR_Action_Boolean pinchAction;
	
	public HandGrab[] hands;
	public SteamVR_Input_Sources[] handTypes;
	
	private void Update()
	{
		CheckGrab();
		CheckInteract();
		CheckRelease();
	}

	void CheckGrab()
	{
		for (int i = 0; i < 2; i++)
		{
			if(GetActionDown(grabAction, handTypes[i]))
			{
				hands[i].TryGrab();
			}
		}
		//if (GetActionDown(grabAction))
		//{
		//	foreach (SteamVRHand hand in hands)
		//	{
		//		if (hand.overlapObject == null)
		//			continue;
		//
		//		if (!hand.holding && !hand.overlapObject.grabbed)
		//		{
		//			hand.holding = true;
		//			hand.overlapObject.grabbed = true;
		//			
		//			var fj = hand.gameObject.AddComponent<FixedJoint>();
		//			fj.connectedBody = hand.overlapObject.gameObject.GetComponent<Rigidbody>();
		//		}
		//	}
		//}
	}

	void CheckRelease()
	{
		for (int i = 0; i < 2; i++)
		{
			if (GetActionUp(grabAction, handTypes[i]))
			{
				hands[i].TryRelease();
			}
		}
		//if (GetActionUp(grabAction))
		//{
		//	foreach (SteamVRHand hand in hands)
		//	{
		//		if (hand.overlapObject == null)
		//			continue;
		//
		//		if (hand.holding)
		//		{
		//			hand.holding = false;
		//			hand.overlapObject.grabbed = false;
		//
		//			Joint tryJoint;
		//			if(hand.TryGetComponent(out tryJoint))
		//			{
		//				Destroy(tryJoint);
		//			}
		//
		//			hand.overlapObject.rb.velocity = hand.velocity;
		//		}
		//	}
		//}
	}

	void CheckInteract()
	{
		for (int i = 0; i < 2; i++)
		{
			if (GetActionDown(pinchAction, handTypes[i]))
			{
				hands[i].TryInteract();
			}
		}
	}

	public bool GetActionDown(SteamVR_Action_Boolean action, SteamVR_Input_Sources handType)
	{
		return action.GetStateDown(handType);
	}

	public bool GetAction(SteamVR_Action_Boolean action, SteamVR_Input_Sources handType)
	{
		return action.GetState(handType);
	}

	public bool GetActionUp(SteamVR_Action_Boolean action, SteamVR_Input_Sources handType)
	{
		return action.GetStateUp(handType);
	}
}
