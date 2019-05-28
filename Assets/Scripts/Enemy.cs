using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

	public float speed = 17;

    [HideInInspector]
    public EnemySpawner enemySpawner;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public float hp = 100;

    private NavMeshAgent agent;
       
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.SetDestination(Camera.main.transform.position);
	}


    private void Update()
    {
        if (transform.position.z < 20)
            GetComponent<Animator>().SetBool("attack", true);
        if (transform.position.z < 10)
            GameController.instance.GameOver();
    }

    public void KillMe(float damage)
    {
        hp -= Time.deltaTime * damage;  
        if (hp < 0)
            enemySpawner.SpawnMe(gameObject);
    }
}
