using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CubeMove : MonoBehaviour {

	public Spawner sp;

	private bool rided;
	private GameObject player;
	private float str;

	new private Transform camera;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rided = false;
		if (Camera.main == null) {
			Debug.Log ("No Cam");
		} else {
			camera = Camera.main.transform;
		}

		StartCoroutine (RandomMove ());
	}

	// Update is called once per frame
	void Update () {
		if (rided) {
			Vector3 tp = camera.forward * 20f + camera.position;
			tp.y = -.5f;
			Move (tp, 3f);
		}
	}

	void Move(Vector3 targetLocation, float speed) {
		transform.position = Vector3.MoveTowards (transform.position, targetLocation, Time.deltaTime * speed);
		if (Vector3.Distance (transform.position, player.transform.position) > 60f)
			DestroyMe ();
	}

	public void ImClicked() {
		if (!rided && Vector3.Distance(player.transform.position, transform.position) < 15f) {
			rided = player.GetComponent<PlayerJump> ().Jump (transform);
			if(rided) StartCoroutine (Strength ());
		}
	}

	public void DestroyMe() {
		sp.cubeDecr ();
		Destroy (gameObject);
	}

	IEnumerator Strength() {
		str = 15f;
		while (str > .2) {
			str -= Time.deltaTime;
			yield return null;
		}
		DestroyMe ();
	}

	IEnumerator RandomMove() {
		bool still = true;
		Vector3 t = new Vector3 (transform.position.x + Random.Range (-10f, 10f), -.5f, transform.position.z + Random.Range (-10f, 10f));
		while (Vector3.Distance (transform.position, t) > .5f && !rided) {
			Move (t, 1f);
			if (Vector3.Distance (transform.position, t) < 1f)
				still = false;
			yield return null;
		}
		if (!rided && !still)
			StartCoroutine (RandomMove ());
		if(rided)
			StopCoroutine (RandomMove ());
		yield return null;
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

	public float getStrength() {
		return str;
	}
}
