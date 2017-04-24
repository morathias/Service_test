using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour {
    Text _pointsTxt;

    public static int points = 0;

	void Start () {
        _pointsTxt = transform.GetChild(0).GetComponent<Text>();
	}

    void Update() {
        _pointsTxt.text = "points: " + points;
    }

    public static void updatePoints(float multiplier) {
        float _points = 50f * multiplier;
        points += (int)_points;
    }
}
