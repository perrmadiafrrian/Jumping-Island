using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public Transform starterCube;

	private Transform cube;
	private bool isJumping;

	// Use this for initialization
	void Start () {
		setCube (starterCube);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isJumping && cube != null) {
			transform.position = new Vector3 (cube.position.x, 1f, cube.position.z);
		}
	}

	void setCube(Transform c) {
		cube = c;
	}

	public void Jump(Transform target) {
		if (target.name != cube.name) {
			if (cube.GetComponent<CubeStarter> () == null) {
				cube.GetComponent<CubeMove> ().DestroyMe ();
			} else {
				cube.GetComponent<CubeStarter> ().DestroyMe ();
			}

			setCube (target);
		}
	}
}