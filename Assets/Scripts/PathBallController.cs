using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBallController : MonoBehaviour {
	public float speed = 1f;
	public Rigidbody rb;
	List<Vector3> recording;
	List<Vector3> playRecording;
	int playRecordingIndex;

	enum State {
		WaitForInput,
		RecordInput,
		PlayInput
	}

	State state = State.WaitForInput;

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			StartCoroutine(RecordAndPlayInput());
		}
	}

	IEnumerator RecordAndPlayInput() {
		var recording = new List<Vector3>();
		while (!Input.GetMouseButtonUp(0)) {
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hitInfo)) {
				recording.Add(hitInfo.point);
			}
			yield return null;
		}
		foreach (var point in recording) {
			ApplyRaycastPosition(point);
			yield return null;
		}
	}

	void PlayRecording() {
		if (this.playRecording != null) {
			if (this.playRecording.Count <= this.playRecordingIndex) {
				this.playRecording = null;
				this.state = State.WaitForInput;
			} else {
				var targetPosition = this.playRecording[this.playRecordingIndex++];
				ApplyRaycastPosition(targetPosition);
			}
		}
	}

	void RecordAndCheckForEndOfInput() {
		if (Input.GetMouseButton(0)) {
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out var hitInfo)) {
				this.recording.Add(hitInfo.point);
			}
		} else if (Input.GetMouseButtonUp(0)) {
			this.playRecording = this.recording;
			this.recording = null;
			this.playRecordingIndex = 0;
			this.state = State.PlayInput;
		}
	}

	void CheckForInput() {
		if (Input.GetMouseButtonDown(0)) {
			this.recording = new List<Vector3>();
			this.state = State.RecordInput;
		}
	}

	void ApplyIgnoreYPosition(Vector3 targetPosition) {
		targetPosition.y = this.transform.position.y;
		this.transform.position = targetPosition;
	}

	void UpdateStateMachine() {
		switch (this.state) {
			case State.WaitForInput:
				CheckForInput();
				break;
			case State.RecordInput:
				RecordAndCheckForEndOfInput();
				break;
			case State.PlayInput:
				PlayRecording();
				break;
		}
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