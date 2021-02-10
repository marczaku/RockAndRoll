using UnityEngine;

public class SwipeBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;
	Vector3 startPosition;
	float startTime;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			this.startPosition = Input.mousePosition;
			this.startTime = Time.time;
		}
		if (Input.GetMouseButtonUp(0)) {
			var passedTime = Time.time - this.startTime;
			var passedDirectionAndDistance = Input.mousePosition - this.startPosition;
			var direction = Vector3.forward * passedDirectionAndDistance.y + Vector3.right * passedDirectionAndDistance.x;
			this.rb.AddForce(direction * this.speed / passedTime, ForceMode.VelocityChange);
		}
	}
}