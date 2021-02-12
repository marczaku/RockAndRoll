using System.Collections.Generic;
using UnityEngine;

public class PathBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;
	List<Vector3> recording;
	List<Vector3> playRecording;
	int playRecordingIndex;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			this.recording = new List<Vector3>();
		}

		if (Input.GetMouseButton(0)) {
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hitInfo)) {
				this.recording.Add(hitInfo.point);
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			this.playRecording = this.recording;
			this.recording = null;
			this.playRecordingIndex = 0;
		}

		if (this.playRecording != null) {
			if (this.playRecording.Count <= this.playRecordingIndex) {
				this.playRecording = null;
			} else {
				var targetPosition = this.playRecording[this.playRecordingIndex++];
				ApplyRaycastPosition(targetPosition);
			}
		}
	}

	void ApplyIgnoreYPosition(Vector3 targetPosition) {
		targetPosition.y = this.transform.position.y;
		this.transform.position = targetPosition;
	}

	void ApplyRaycastPosition(Vector3 targetPosition) {
		targetPosition.y += 10f;
		if (Physics.Raycast(targetPosition, Vector3.down, out var hitInfo)) {
			targetPosition = hitInfo.point;
			targetPosition.y += GetComponent<SphereCollider>().radius;
			this.transform.position = targetPosition;
		}
	}
}