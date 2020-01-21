using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamVRHand : MonoBehaviour
{
	public bool holding;
	public SteamVRGrabbable overlapObject;
	public Rigidbody rb;

	private Vector3 previousPos;
	public Vector3 velocity;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>(); 
		
		previousPos = transform.position;
		
	}

	private void FixedUpdate()
	{
		if (holding)
		{
			overlapObject.transform.position = transform.position;
			CalculateVelocity();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (holding)
			return;

		SteamVRGrabbable tryGrab;
		if(other.TryGetComponent(out tryGrab))
			overlapObject = tryGrab;
	}

	private void OnTriggerExit(Collider other)
	{
		if (holding)
			return;

		SteamVRGrabbable tryGrab;
		if (other.TryGetComponent(out tryGrab))
			if(tryGrab == overlapObject)
				overlapObject = null;
	}

	private void CalculateVelocity()
	{
		Vector3 deltaPos = transform.position - previousPos;

		//velocity = (deltaPos / Time.fixedDeltaTime) * (0.2f);
		velocity = Vector3.zero;
	}
}
