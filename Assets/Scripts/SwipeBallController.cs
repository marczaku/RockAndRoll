using UnityEngine;

public class SwipeBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;

	public void FixedUpdate() {
		//var direction = Vector3.forward * this.joystick.Vertical + Vector3.right * this.joystick.Horizontal;
		//this.rb.AddForce(direction * this.speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
	}
}