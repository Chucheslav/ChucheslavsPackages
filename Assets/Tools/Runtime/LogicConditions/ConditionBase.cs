using System;

namespace Tools.LogicConditions
{

[Serializable]
public abstract class ConditionBase
{
    public virtual bool Evaluate() => false;
}
}