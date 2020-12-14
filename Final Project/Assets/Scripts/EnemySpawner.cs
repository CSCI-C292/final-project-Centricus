using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    public float frequency = 5f;
    
    private float timeRemaining = 0f;

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= (Time.deltaTime);
        if (timeRemaining <= 0)
        {
            timeRemaining = frequency;
            int position = Random.Range(0, spawnPoints.Length);
            Slime enemy;
            if (Random.Range(0, 2) == 0)
            {
                enemy = Resources.Load<Slime>("Enemies/slime");
            }
            else 
            {
                enemy = Resources.Load<Slime>("Enemies/rangedSlime");
            }
            NavMeshAgent instance = Instantiate(enemy).GetComponent<NavMeshAgent>();
            instance.Warp(spawnPoints[position].position);
        }
    }
}
