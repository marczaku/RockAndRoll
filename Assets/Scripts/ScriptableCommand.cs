using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class ScriptableCommand : ScriptableObject {
	public event System.Action CommandFired;

	public void Execute() {
		this.CommandFired?.Invoke();
	}
}