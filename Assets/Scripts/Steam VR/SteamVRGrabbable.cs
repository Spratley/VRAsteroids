using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SteamVRGrabbable : MonoBehaviour
{
	public bool grabbed;
	public Rigidbody rb;

	public virtual void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
}
