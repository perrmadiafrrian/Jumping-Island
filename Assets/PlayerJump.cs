using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	public Transform starterCube;

	private int score;
	private Transform cube;
	private bool isJumping;
	public Text text;
	public GameObject gameOver;
	public Text finalScore;
	public GazeInputModule gim;

	//private Rigidbody rb;

	// Use this for initialization
	void Start () {
		setCube (starterCube);
		score = 0;
	//	rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isJumping && cube != null) {
			transform.position = new Vector3 (cube.position.x, transform.position.y, cube.position.z);
		}
		if (cube != null && cube.GetComponent<CubeStarter> () != null) {
			//text.text = ""+Mathf.RoundToInt(cube.GetComponent<CubeStarter> ().getStrength());
		} else if (cube != null && cube.GetComponent<CubeMove> () != null) {
			//text.text = ""+Mathf.RoundToInt(cube.GetComponent<CubeMove> ().getStrength());
		}
		text.text = ""+score;
		if (cube == null) {
			gameOver.SetActive (true);
			gameOver.transform.localPosition = new Vector3 (0f, 0f, 10f);
			if (DataHelper.getVRMode ()) {
				gameOver.transform.SetParent (GameObject.FindGameObjectWithTag ("Player").transform);
			} else {
				gim.enabled = false;
			}
			finalScore.text = score + " point";
		}
	}

	void setCube(Transform c) {
		cube = c;
	}

	public bool Jump(Transform target) {
		if (cube != null && target.transform != cube.transform && Vector3.Distance (transform.position, target.position) < 15f) {
			StartCoroutine (JumpAnim (target));
			return true;
		} else {
			return false;
		}
	}

	IEnumerator JumpAnim(Transform target) {

		if (cube != null && target.transform != cube.transform && Vector3.Distance(transform.position, target.position) < 15f) {
			isJumping = true;
			score++;
			if (cube.GetComponent<CubeStarter> () == null) {
				cube.GetComponent<CubeMove> ().DestroyMe ();
			} else {
				cube.GetComponent<CubeStarter> ().DestroyMe ();
			}

			setCube (target);

			Vector3 offset = new Vector3(0f,1.5f,0f);

			float t = 0f;
			float distance = Vector3.Distance (transform.position, target.position + offset);

			Vector3 startPosition = transform.position;

			Vector3 topPosition = (target.position + startPosition);
			topPosition.x = topPosition.x / 2f;
			topPosition.y = topPosition.y + distance + (distance/2f);
			topPosition.z = topPosition.z / 2f;

			
			while(t<1f) {
				t += Time.deltaTime * 10f/distance;
				if(target !=null)
				transform.position = Vector3.Lerp (startPosition, Vector3.Lerp (topPosition, target.position+offset, t), t);
				yield return null;
			}

			isJumping = false;
		}
		yield return null;
	}
}