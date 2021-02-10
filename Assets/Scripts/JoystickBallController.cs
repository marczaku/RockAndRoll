using UnityEngine;

public class JoystickBallController : MonoBehaviour {
	public float speed = 1f;
	public Joystick joystick;
	public Rigidbody rb;

	void FixedUpdate() {
		var direction = Vector3.forward * this.joystick.Vertical + Vector3.right * this.joystick.Horizontal;
		this.rb.AddForce(direction * this.speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
	}
}