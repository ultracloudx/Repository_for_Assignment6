using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public GameObject player;
    public CapsuleCollider capsule;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent.updateRotation = false;
        //player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(player.transform.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            Debug.Log("Collided with: " + other.name);
            GameManager.lives--;
        }
    }
}
