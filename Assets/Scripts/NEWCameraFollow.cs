using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWCameraFollow : MonoBehaviour
{
	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;

	void Update()
	{
		targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		Vector3 velocity = targetPos - transform.position;
		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, moveSpeed * Time.deltaTime);
	}
}
