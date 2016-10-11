using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	const string PLAY_SCENE_NAME = "PlayScene";
	const string HOME_SCENE_NAME = "MenuScene";

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

	public void Replay() {
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().name);
	}

	public void Home() {
		SceneManager.LoadSceneAsync (HOME_SCENE_NAME);
	}
}
