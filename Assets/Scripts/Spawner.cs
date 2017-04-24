using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject meteor;

    float _spawnTimer = 3f;
    float _randomScale;
	
	void Update () {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0) {
            _spawnTimer = 3f;

            Vector3 meteorPosition = transform.position;

            meteorPosition.x = Random.Range(-50f, 50f);

            _randomScale = Random.Range(1f, 2f);
            meteor.transform.localScale = new Vector3(_randomScale, _randomScale, _randomScale);

            Instantiate(meteor, meteorPosition, Quaternion.identity);
        }
	}

    public float getPointMultiplier() {
        return _randomScale;
    }
}
