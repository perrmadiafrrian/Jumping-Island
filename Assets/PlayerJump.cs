using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	public Transform starterCube;

	private Transform cube;
	private bool isJumping;

	//private Rigidbody rb;

	// Use this for initialization
	void Start () {
		setCube (starterCube);
	//	rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isJumping && cube != null) {
			transform.position = new Vector3 (cube.position.x, transform.position.y, cube.position.z);
		}


	}

	void setCube(Transform c) {
		cube = c;
	}

	public void Jump(Transform target) {
		StartCoroutine (JumpAnim(target));
	}

	IEnumerator JumpAnim(Transform target) {

		if (cube != null && target.transform != cube.transform && Vector3.Distance(transform.position, target.position) < 10f) {
			if (cube.GetComponent<CubeStarter> () == null) {
				cube.GetComponent<CubeMove> ().DestroyMe ();
				target.GetComponent<CubeMove> ().ImClicked ();
			} else {
				cube.GetComponent<CubeStarter> ().DestroyMe ();
				target.GetComponent<CubeMove> ().ImClicked ();
			}

			Vector3 offset = new Vector3(0f,1.5f,0f);

			float t = 0f;
			float distance = Vector3.Distance (transform.position, target.position + offset);

			Vector3 startPosition = transform.position;

			Vector3 topPosition = (target.position + startPosition);
			topPosition.x = topPosition.x / 2f;
			topPosition.y = topPosition.y + distance;
			topPosition.z = topPosition.z / 2f;

			
			while(t<1f) {
				t += Time.deltaTime * 10f/distance;
				transform.position = Vector3.Lerp (startPosition, Vector3.Lerp (topPosition, target.position+offset, t), t);
				yield return null;
			}

			setCube (target);
		}

		yield return null;
	}
}