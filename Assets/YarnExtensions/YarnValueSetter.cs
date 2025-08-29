using UnityEngine;
using Yarn.Unity;

public abstract class YarnValueSetter<T> : MonoBehaviour
{
    [SerializeField] protected string variableName;
    [SerializeField] protected VariableStorageBehaviour variableStorage;

    protected void Awake()
    {
        if(!variableStorage) variableStorage = FindObjectOfType<VariableStorageBehaviour>(); 
    }
    
    public abstract void SetValue(T value);
}