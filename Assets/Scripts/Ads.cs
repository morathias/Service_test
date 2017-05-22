using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class Ads : MonoBehaviour {

	void Awake(){
        #if UNITY_ADS
        Advertisement.Initialize("1408011");
        #endif
	}

	void Update(){
        #if UNITY_ADS
		if (!Advertisement.isShowing)
			Time.timeScale = 1;
        #endif
	}

	public void playAd(){
        #if UNITY_ADS
		Time.timeScale = 0;
		StartCoroutine (ShowAdWhenReady());
        #endif
	}
    #if UNITY_ADS
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
    #endif
}
