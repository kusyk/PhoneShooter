using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public int enemiesCount = 5;
    public GameObject enemy;
    public GameObject enemyDeathParticles;

    public float range = 65;

    void Awake () {
        for (int i = 0; i < enemiesCount; i++)
        {
            GameObject o = Instantiate(enemy, NewPosition(), Quaternion.identity) as GameObject;
            o.GetComponent<Enemy>().enemySpawner = this;
        }
	}
	
    
    public void SpawnMe(GameObject e)
    {
        StartCoroutine(SpawnCoroutine(e));
    }

    private Vector3 NewPosition()
    {
        return new Vector3(Random.Range(-range, range), transform.position.y, transform.position.z + (Random.Range(0, range) * 1.5f));
    }


    private IEnumerator SpawnCoroutine(GameObject e)
    {
        e.GetComponent<Enemy>().isDead = true;
        GameObject obj = Instantiate(enemyDeathParticles, e.transform.position + new Vector3(0, 4, 0), e.transform.rotation) as GameObject;
        Destroy(obj, 5);
        yield return new WaitForSeconds(0.2f);
        e.transform.position = NewPosition();
        e.GetComponent<Enemy>().isDead = false;
        e.GetComponent<Enemy>().hp = 100;
        e.GetComponent<Animator>().SetBool("attack", false);
    }
}
