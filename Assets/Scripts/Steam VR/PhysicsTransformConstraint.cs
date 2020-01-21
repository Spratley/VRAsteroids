using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTransformConstraint : MonoBehaviour
{
	public Transform parent;

	private void FixedUpdate()
	{
		transform.position = parent.position;
		transform.rotation = parent.rotation;
	}
}
