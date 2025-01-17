using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spwanPoint;

    float timer;

    void Awake()
    {
        spwanPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        // 타이머변수에 deltaTime을 계속 더하기기
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            // 타이머가 일정 값에 도달하면 소환하도록 작성
            timer = 0;
            Spwan();
        }

    }

    void Spwan()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2));
        enemy.transform.position = spwanPoint[Random.Range(1, spwanPoint.Length)].position;
    }
}
