using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	const string PLAY_SCENE_NAME = "PlayScene";

	GvrViewer gvrViewer;

	void Start () {
		gvrViewer = GvrViewer.Instance;
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name.Equals (PLAY_SCENE_NAME)) {
			gvrViewer.VRModeEnabled = DataHelper.getVRMode ();
		}
	}
	
	public void Play(bool vrMode) {
		DataHelper.setVRMode (vrMode);

		SceneManager.LoadSceneAsync (PLAY_SCENE_NAME);
	}
}
