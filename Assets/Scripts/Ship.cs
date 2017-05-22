using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public float speed;

    ParticleSystem _bullets;
    public GameObject restartBtn;
    Vector3 _direction;

    void Start()
    {
        _bullets = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void Update()
    {
#if UNITY_EDITOR
        //_direction = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            _direction = -Input.GetTouch(0).deltaPosition;

#elif UNITY_ANDROID
		if(Input.touchCount>0){
			_direction = new Vector3(-Input.GetTouch(0).deltaPosition.x, -Input.GetTouch(0).deltaPosition.y, transform.position.z);
		}
#endif
        _direction *= speed;
        transform.Translate(_direction * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
            shoot();

        if (transform.position.x > 60)
            transform.position = new Vector3(-60, transform.position.y, transform.position.z);
        if (transform.position.x < -60)
            transform.position = new Vector3(60, transform.position.y, transform.position.z);

        if (transform.position.y <= -30)
            transform.position = new Vector3(transform.position.x, -30, transform.position.z);

        if (transform.position.z > 54.31f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 54.31f);

        if (transform.position.z < 54f)
            transform.position = new Vector3(transform.position.x, transform.position.y, 54f);
    }

    void shoot()
    {
        _bullets.Emit(1);
    }

    void OnCollisionEnter(Collision meteor)
    {
        Debug.Log("perdiste");
        restartBtn.SetActive(true);

        AnalyticsManager.retrievePoints(PointsManager.points);
        PlayServicesManager.addScoreToLeaderBoard(GPGSIds.leaderboard_leaderboard, PointsManager.points);
        PlayServicesManager.unlockAchivement(GPGSIds.achievement_you_died);
        PointsManager.points = 0;

        gameObject.SetActive(false);
    }
}
