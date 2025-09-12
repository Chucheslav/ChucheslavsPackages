using UnityEngine;
using UnityEngine.AI;

namespace NavigationExtensions
{
[AddComponentMenu("Custom Components/Navigation/Nav Agent Destination from Pointer Click")]
public class SetNavAgentFromPointerClick : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField][Range(0,5)] private int mouseButtonIndex;
    [SerializeField] private Camera raycastCamera;

    private void Awake()
    {
        if(!raycastCamera) raycastCamera = Camera.main;
        if (agent) return;
        if(!TryGetComponent(out NavMeshAgent navAgent))
        {
            Debug.LogError($"NavAgentCommands cannot find NavMeshAgent component, please assign manually");
            return;
        }
        agent = navAgent;
    }

    private void Update()
    {
        if(!Input.GetMouseButtonDown(mouseButtonIndex)) return;
        Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit)) agent.SetDestination(hit.point);
    }
}
}
