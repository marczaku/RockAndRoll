using UnityEngine;

public class TiltBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;

	public static Vector3 AccelerationToFlatUnityCoordinates(Vector3 acceleration, bool ignoreGravity = false) {
		// Inverse the z axis, because the accelerometer points the other way
		acceleration.z *= -1;
		// Rotate with the camera's rotation (perspective):
		var result = Quaternion.Euler(90, 0, 0) * acceleration;
		if (ignoreGravity)
			result.y = 0;
		return result;
	}
	
	void FixedUpdate() {
		var direction = new Vector3(Input.acceleration.x, 0f, Input.acceleration.y);
		Debug.Log(direction);
		// Apply the gravity to the ball:
		this.rb.AddForce(direction * this.speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
	}
}