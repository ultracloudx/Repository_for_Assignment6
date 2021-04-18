using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    Camera m_MainCamera;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;


    private void Start()
    {
        m_MainCamera = Camera.main;

        agent.updateRotation = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // MOVE OUR AGENT
                agent.SetDestination(hit.point);
            }

        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prize"))
        {
            Debug.Log("Item Get");
            other.gameObject.SetActive(false);
            GameManager.score = GameManager.score + 10;

        }


    }
}
