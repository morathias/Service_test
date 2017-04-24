using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
    public float speed;
    public float speedRotation;

    int _health = 20;

	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.up * speed * Time.deltaTime, Space.World);

        transform.Rotate(speedRotation * Time.deltaTime, speedRotation * Time.deltaTime, speedRotation * Time.deltaTime);

        if (transform.position.y < -60)
            Destroy(gameObject);
	}

    void OnParticleCollision(GameObject bullet){
        _health--;
        Debug.Log("choco bala");
        if (_health <= 0) {
            PointsManager.updatePoints(transform.localScale.x);
            Destroy(gameObject);
        }
    }
}
