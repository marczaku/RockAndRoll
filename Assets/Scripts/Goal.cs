using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public GameObject[] camerasWithSkybox;
	int currentIndex;
	GameObject currentInstance;
	public GameManager gameManager;

	public void StartLevel2() {
		GameManager.Instance = CreateLevel2GameManager();
	}

	static GameManager CreateLevel2GameManager() {
		return new GameManager();
	}

	public void SwitchToNext() {
		GameManager.Instance.playerWon = true;
		Destroy(this.currentInstance);
		Instantiate(this.camerasWithSkybox[this.currentIndex++]);
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Ball") {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}
}