using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public Portal connectedPortal;
	public Transform outputPoint;


	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (!collider.isTrigger)
		{
			Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
			float colliderTotalVelocity = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
			Vector2 connectedPortalFacingDirection = (connectedPortal.outputPoint.position  -  connectedPortal.transform.position) / Vector2.Distance(connectedPortal.outputPoint.position , connectedPortal.transform.position);
			collider.transform.position = connectedPortal.outputPoint.position;
			rb.velocity = colliderTotalVelocity * connectedPortalFacingDirection;
		}
	}
}
