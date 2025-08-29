using UnityEngine;
using UnityEngine.AI;

namespace ThirdPesonCharacter
{

[RequireComponent(typeof(ThirdPersonController))]
[DisallowMultipleComponent]
public class ThirdPersonCharacterMoveFromNavAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ThirdPersonController controller;

    private void Awake()
    {
        if(!agent) agent = GetComponent<NavMeshAgent>();
        if(!controller) controller = GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        agent.updateRotation = false;
        agent.updatePosition = true;
    }

    private void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
            controller.Move(agent.desiredVelocity, false, false);
        else
            controller.Move(Vector3.zero, false, false);
    }
}
}
