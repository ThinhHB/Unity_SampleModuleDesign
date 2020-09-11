using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Config the barrel transform, it will spawn the bullet prefab when user press leftMouse. Also raise the shoot event when instantiate the bullet
/// </summary>
public class SpawnBulletOnMousePress : MonoBehaviour {
	#region Init, config
	[Header("References")]
	[SerializeField] Transform barrelTrans;

	[Header("Config")]
	[SerializeField] GameObject bulletPrefab;

	[Header("Validation")]
	[SerializeField] bool isFailedConfig;
	void OnValidate() {
		// warnings
		Common.Warning(barrelTrans != null, this, "Missing barrelTrans");
		Common.Warning(bulletPrefab != null, this, "Missing bulletPrefab");
		// mark it as failed config if missing any references
		isFailedConfig = barrelTrans == null
			|| bulletPrefab == null;
	}

	void OnEnable() {
		// disable this component (Update function won't be called)
		if(isFailedConfig) {
			enabled = false;
		}
	}
	#endregion//init, config


	#region Private
	void Update() {
		// fire, left mouse
		if(Input.GetMouseButtonDown(0)) {
			// create bullet, config direction
			var bullet = Instantiate(bulletPrefab, barrelTrans.position, barrelTrans.rotation).transform;
			bullet.up = barrelTrans.up;
			// raise shoot event
			this.PostEvent(EventID.OnMarineShoot);
		}
	}
	#endregion//Private
}
