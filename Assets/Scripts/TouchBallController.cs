using UnityEngine;

public class TouchBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;

	void FixedUpdate() {
		if (Input.GetMouseButton(0)) {
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hitInfo)) {
				var direction = (hitInfo.point - this.transform.position).normalized;
				this.rb.AddForce(direction * this.speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
			}
		}
	}
}