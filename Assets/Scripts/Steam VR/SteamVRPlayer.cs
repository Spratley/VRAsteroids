using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamVRPlayer : MonoBehaviour
{
	public SteamVR_Input_Sources handType;
	public SteamVR_Action_Boolean teleportAction;
	public SteamVR_Action_Boolean grabAction;
	
	public SteamVRHand[] hands;
	
	private void Update()
	{
		CheckGrab();
		CheckRelease();
	}

	void CheckGrab()
	{
		if (GetActionDown(grabAction))
		{
			foreach (SteamVRHand hand in hands)
			{
				if (hand.overlapObject == null)
					continue;

				if (!hand.holding && !hand.overlapObject.grabbed)
				{
					hand.holding = true;
					hand.overlapObject.grabbed = true;
					
					var fj = hand.gameObject.AddComponent<FixedJoint>();
					fj.connectedBody = hand.overlapObject.gameObject.GetComponent<Rigidbody>();
				}
			}
		}
	}

	void CheckRelease()
	{
		if (GetActionUp(grabAction))
		{
			foreach (SteamVRHand hand in hands)
			{
				if (hand.overlapObject == null)
					continue;

				if (hand.holding)
				{
					hand.holding = false;
					hand.overlapObject.grabbed = false;

					Joint tryJoint;
					if(hand.TryGetComponent(out tryJoint))
					{
						Destroy(tryJoint);
					}

					hand.overlapObject.rb.velocity = hand.velocity;
				}
			}
		}
	}

	public bool GetActionDown(SteamVR_Action_Boolean action)
	{
		return action.GetStateDown(handType);
	}

	public bool GetAction(SteamVR_Action_Boolean action)
	{
		return action.GetState(handType);
	}

	public bool GetActionUp(SteamVR_Action_Boolean action)
	{
		return action.GetStateUp(handType);
	}
}
