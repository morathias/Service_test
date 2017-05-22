using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class PlayServicesManager : MonoBehaviour {

	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        signIn();
	}

    void signIn() {
        Social.localUser.Authenticate(success => { });
    }

    public void showAchivements()
    {
        Social.ShowAchievementsUI();
    }

    public void showLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public static void unlockAchivement(string id) {
        double progress = 100;
        Social.ReportProgress(id, progress, success => { });
    }

    public static void incrementAchivement(string id, int steps) {
        PlayGamesPlatform.Instance.IncrementAchievement(id, steps, success => { });
    }

    public static void addScoreToLeaderBoard(string leaderBoarsId, long score) {
        Social.ReportScore(score, leaderBoarsId, success => { });
    }
}
