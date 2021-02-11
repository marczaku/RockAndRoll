using UnityEngine;

public class TiltBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;

	void FixedUpdate() {
		var direction = Input.acceleration;
		// Inverse the z axis, because the accelerometer points the other way
		direction.z *= -1;
		// Rotate with the camera's rotation (perspective):
		direction = Quaternion.Euler(90, 0, 0) * direction;
		// Apply the gravity to the ball:
		this.rb.AddForce(direction * this.speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
	}
}