using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LinkJump : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool linking;
    public float origSpeed;

    public float linkSpeed = 100f;



    // Start is called before the first frame update
    void Start()
    {
        origSpeed = agent.speed;
        linking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agent.isOnOffMeshLink && linking == false)
        {
            linking = true;
            agent.speed = agent.speed * linkSpeed;
        }else if(agent.isOnOffMeshLink && linking == true)
        {
            linking = false;
            agent.velocity = Vector3.zero;
            agent.speed = origSpeed;
        }
    }
}
