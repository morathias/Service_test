using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour {
    public static void retrievePoints(int points) {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object> { {"points: ", points} });
    }
}
