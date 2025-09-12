using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace NavigationExtensions
{
[AddComponentMenu("Custom Components/Navigation/Nav Agent Destination from Tag or Transform")]
[RequireComponent(typeof(NavMeshAgent))]
public class SetNavAgentTargetFromTagOrTransform : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private string targetTag;
    [SerializeField][Min(0)] private float updateInterval = 0.1f;
    [SerializeField] private bool updateToClosest;

    private float _timer;

    private void Update()
    {
        if(!target) return;
        _timer -= Time.deltaTime;
        if(_timer > 0 ) return;
        if (updateToClosest)
        {
            FindAndSetTarget();
            return;
        }

        agent.SetDestination(target.position);
        _timer = updateInterval;
    }

    private void Awake()
    {
        if(agent) return;
        
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void SetNewTargetTag(string newTag)
    {
        targetTag = tag;
        FindAndSetTarget();
    }

    private void OnEnable()
    {
        if(target) return;
        FindAndSetTarget();
    }
    
    private void FindAndSetTarget()
    {
        var targets = GameObject.FindGameObjectsWithTag(targetTag);
        if(! targets.Any()) return;
        target = targets.OrderBy(go => Vector3.Distance(go.transform.position, transform.position)).First().transform;
        _timer = updateInterval;
        agent.SetDestination(target.position);
    }
}
}