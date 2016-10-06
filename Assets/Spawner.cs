using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour {

	public GameObject go;

	// Use this for initialization
	void Start () {
		float x = transform.position.x;
		float z = transform.position.z;
		StartCoroutine (spawn (new Vector3 (Random.Range (x + 3f, 10f), -.5f, Random.Range (z + 3f, 10f))));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawn(Vector3 pos) {
		GameObject g = Instantiate (go, pos, Quaternion.identity) as GameObject;
		yield return null;
	}
}
