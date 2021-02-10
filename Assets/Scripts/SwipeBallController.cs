using UnityEngine;

public class SwipeBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;
	Vector3 screenPositionStart;
	float timeStart;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			this.screenPositionStart = Input.mousePosition;
			this.timeStart = Time.time;
		}
		if (Input.GetMouseButtonUp(0)) {
			var timeDifference = Time.time - this.timeStart;
			var screenPositionDifference = (Input.mousePosition - this.screenPositionStart) / Screen.dpi;
			var worldDirection = Vector3.forward * screenPositionDifference.y + Vector3.right * screenPositionDifference.x;
			this.rb.AddForce(worldDirection * this.speed / timeDifference);
		}
	}
}