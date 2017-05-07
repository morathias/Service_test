using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public float speed;

    ParticleSystem _bullets;
    public GameObject restartBtn;
    Vector3 _direction;

	void Start () {
        _bullets = transform.GetChild(0).GetComponent<ParticleSystem>();
	}
	
	void Update () {
        _direction = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
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
	}

    void shoot() {
        _bullets.Emit(1);
    }

    void OnCollisionEnter(Collision meteor) {
        Debug.Log("perdiste");
        restartBtn.SetActive(true);
        gameObject.SetActive(false);
    }
}
