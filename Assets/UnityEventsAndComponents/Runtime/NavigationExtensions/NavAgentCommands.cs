using UnityEngine;
using UnityEngine.AI;

namespace NavigationExtensions
{
[AddComponentMenu("Custom Events/Commands/Nav Agent Commands")]
public class NavAgentCommands : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    
    public void SetMeAsTarget() => agent.SetDestination(transform.position);
}
}
