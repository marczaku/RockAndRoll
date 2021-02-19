using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameManager : ScriptableObject {

	static GameManager _instance;

	public static GameManager Instance {
		get {
			if (_instance == null)
				_instance = Resources.Load<GameManager>(
					"GameData/GlobalGameManager");
			return _instance;
		}
		set => _instance = value;
	}
#if UNITY_EDITOR
	[UnityEditor.MenuItem("Marc Zaku/Build Bundles")]
	public static void BuildAssetBundles() {
		const string outputPath = "AssetBundles";
		if (!Directory.Exists(outputPath))
			Directory.CreateDirectory(outputPath);
		UnityEditor.BuildPipeline.BuildAssetBundles(
			outputPath, 
			UnityEditor.BuildAssetBundleOptions.None, 
			UnityEditor.EditorUserBuildSettings.activeBuildTarget);
	}
	#endif

	public static IEnumerator LoadSomeFile() {
		var path = Path.Combine(Application.streamingAssetsPath, "someBundle");
		using var bundleRequest = UnityWebRequestAssetBundle.GetAssetBundle(path);
		yield return bundleRequest.SendWebRequest();
		if (!string.IsNullOrEmpty(bundleRequest.error)) {
			throw new System.Exception($"Error loading texture from {path}: {bundleRequest.error}");
		} else {
			var assetBundle = DownloadHandlerAssetBundle.GetContent(bundleRequest);
			var texture = assetBundle.LoadAsset<Texture>("Assets/Textures/Something.png");
			var sprite = assetBundle.LoadAsset<Texture>("Assets/Sprites/Something.png");
			var prefab = assetBundle.LoadAsset<GameObject>("Assets/Prefabs/Something.png");
			// This is not how you load a scene from a bundle:
			var scene = assetBundle.LoadAsset<SceneAsset>("Assets/Prefabs/Something.png");
			// Instead, you just load the bundle first
			// and then load the scene using the SceneManager:
			yield return SceneManager.LoadSceneAsync("Assets/Scenes/PathScene.unity");
		}
	}
	
	public GameObject player;
	public List<GameObject> enemies;
	public int difficulty;
	public int spawnEnemyCount;
	public bool playerWon;
}