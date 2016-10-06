using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CubeMove : MonoBehaviour {

	private bool rided;
	private float x, z;

	new private Transform camera;
	// Use this for initialization
	void Start () {
		rided = false;
		x = Random.Range (1f, 5f);
		z = Random.Range (1f, 5f);

		if (Camera.main == null) {
			Debug.Log ("No Cam");
		} else {
			camera = Camera.main.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		if (!rided) {
			Move(new Vector3(transform.position.x + x, -.5f, transform.position.z + z), 1f);
		} else {
			Vector3 tp = camera.forward * 20f + camera.position;
			tp.y = -.5f;
			Move (tp, 1f);
		}
	}

	void Move(Vector3 targetLocation, float speed) {
		transform.position = Vector3.MoveTowards (transform.position, targetLocation, Time.deltaTime * speed);
	}

	public void ImClicked() {
		if (!rided) {
			rided = true;
			StartCoroutine (Strength ());
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
}
