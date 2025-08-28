using UnityEngine;

namespace Tools.LogicConditions
{

public abstract class ConditionBase: ScriptableObject
{
    public virtual bool Evaluate() => false;
}
}