using UnityEngine;
using System.Collections;

public class CubeStarter : MonoBehaviour {

	private Vector3 targetLocation;

	new private Transform camera;
	// Use this for initialization
	void Start () {
		if (Camera.main.transform == null) {
			Debug.Log ("No Cam");
		} else {
			camera = Camera.main.transform;
		}
	}

	public void DestroyMe() {
		Destroy (gameObject);
	}

	IEnumerator Strength() {
		float str = 5f;
		while (str > .2) {
			str -= Time.deltaTime;
			yield return null;
		}
		DestroyMe ();
	}

	// Update is called once per frame
	void Update () {
		targetLocation = camera.forward * 20f + camera.position;
		targetLocation.y = -.5f;
		transform.position = Vector3.MoveTowards (transform.position, targetLocation, Time.deltaTime * 3f);
	}

	void OnCollisionEnter(Collision col) {
		if (col.transform.GetComponent<CubeMove> () != null)
			col.transform.GetComponent<CubeMove> ().DestroyMe ();
		else if (col.transform.GetComponent<CubeStarter> () != null) {
			col.transform.GetComponent<CubeStarter> ().DestroyMe ();
		} else {
			Debug.Log ("error");
		}
	}
}
