using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Animation Player")]
public class YarnAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if(!animator) animator = GetComponent<Animator>();
    }
    
    [YarnCommand ("playAnimation")]
    public void PlayAnimation(string animationName) => animator.Play(animationName);
}
}