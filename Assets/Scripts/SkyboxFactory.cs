using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SkyboxFactory : MonoBehaviour {
	public GameObject ActiveSkyboxCamera;
	public AssetReference SkyboxReference;
	public AssetLabelReference SkyboxLabelReference;
	void Start() {
		Destroy(this.ActiveSkyboxCamera);
		var assetLoadingTask = Addressables.LoadAssetAsync<GameObject>(this.SkyboxReference);
		assetLoadingTask.Completed += OnSkyboxReady;
	}

	void OnSkyboxReady(AsyncOperationHandle<GameObject> handle) {
		this.ActiveSkyboxCamera = Instantiate(handle.Result);
	}
}