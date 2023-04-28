// EnemySpawner.cs
/*
    Pooling 기법을 활용하여 적(경찰차)들을 맵 상에 생성합니다.
    적들이 생성되는 시간 간격과 생성되는 좌표 데이터를 가집니다.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPooling))]
public class EnemySpawner : MonoBehaviour {
    [SerializeField] private float spawnTime;
    [SerializeField] private List<Transform> spanwPoints;

    private int index;
    private ObjectPooling pooling;


    private void Init() {
        GameManager.instance.gameOverHandler += SpawnStop;
        this.pooling = GetComponent<ObjectPooling>();
    }

    private void Start() {
        Init();
        StartCoroutine("EnemySpawn");
    }

    IEnumerator EnemySpawn() {
        while (true) {  // TODO: if player is alive
            GameObject enemy = this.pooling.ActivePoolItem();    // spawn

            this.index = Random.Range(0, this.spanwPoints.Count);

            enemy.transform.position = spanwPoints[this.index].position;
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);

            yield return new WaitForSeconds(this.spawnTime);    // wait
        }
    }

    private void SpawnStop() {
        StopCoroutine("EnemySpawn");
    }
}