using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tools.LogicConditions
{
[Serializable]
public class CompoundCondition
{
    [SerializeField] private LogicOperator logicOperator;
    [SerializeReference] private List<ConditionBase> conditions;

    public CompoundCondition()
    {
        conditions = new ();
    }

    public bool Evaluate()
    {
        if(logicOperator is LogicOperator.AlwaysTrue) return true;
        
        if (!conditions.Any())
        {
            Debug.LogError("Condition list empty, set to always true if no conditions are intended.");
            return true;
        }
        
        foreach (ConditionBase condition in conditions)
        {
            switch (logicOperator)
            {
                case LogicOperator.And:
                    if (!condition.Evaluate()) return false;
                    break;
                case LogicOperator.Or:
                    if (condition.Evaluate()) return true;
                    break;
                case LogicOperator.Nand:
                    if (!condition.Evaluate()) return true;
                    break;
                case LogicOperator.Nor:
                    if (condition.Evaluate()) return false;
                    break;
            }
        }

        return logicOperator is LogicOperator.And or LogicOperator.Nor;;
    }
    

}
}

