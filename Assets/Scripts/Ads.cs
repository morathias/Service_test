using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

	void Awake(){
        Advertisement.Initialize("1408011");
	}

	void Update(){
		if (!Advertisement.isShowing)
			Time.timeScale = 1;
	}

	public void playAd(){
		Time.timeScale = 0;
		StartCoroutine (ShowAdWhenReady());
	}

	IEnumerator ShowAdWhenReady(){
		while (!Advertisement.IsReady())
			yield return null;

		Advertisement.Show ();
	}

	void AdCallbackhandler (ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			PointsManager.updatePoints (5f);
			break;
		case ShowResult.Skipped:
			Debug.Log ("Ad skipped. Son, I am dissapointed in you");
			break;
		}
	}
}
