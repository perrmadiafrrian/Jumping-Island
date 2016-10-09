using UnityEngine;
using System.Collections;

public class DataHelper : MonoBehaviour {
	public static void setVRMode(bool vrMode) {
		PlayerPrefs.SetInt ("VRMode", vrMode ? 1 : 0);
	}

	public static bool getVRMode() {
		return PlayerPrefs.GetInt ("VRMode",0) == 1 ? true : false;
	}
}
