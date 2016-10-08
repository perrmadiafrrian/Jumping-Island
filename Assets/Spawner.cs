using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour {

	public GameObject go;

	public float rangeDown = 10f;
	public float rangeUp = 10f;

	private const int maxCube = 7;
	private int cubeCount;
	// Use this for initialization
	void Start () {
		float x = transform.position.x;
		float z = transform.position.z;
		cubeCount = 0;
		while (cubeCount < maxCube) {
			StartCoroutine (spawn (new Vector3 (Random.Range (x - rangeDown, rangeUp), -.5f, Random.Range (z - rangeDown, rangeUp))));
			cubeCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (cubeCount < maxCube) {
			float x = transform.position.x;
			float z = transform.position.z;
			StartCoroutine (spawn (new Vector3 (Random.Range (x - rangeDown, rangeUp), -.5f, Random.Range (z - rangeDown, rangeUp))));
			cubeCount++;
		}
	}

	IEnumerator spawn(Vector3 pos) {
		GameObject g = Instantiate (go, pos, Quaternion.identity) as GameObject;
		g.SetActive (true);
		yield return new WaitForSeconds(1f);
	}

	public void cubeDecr() {
		cubeCount--;
	}
}
