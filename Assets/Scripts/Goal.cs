using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Ball") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}
}