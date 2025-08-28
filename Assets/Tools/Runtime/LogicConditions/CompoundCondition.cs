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
    [Tooltip("Leave empty for always true")]
    [SerializeField] private List<ConditionBase> conditions;

    public CompoundCondition()
    {
        conditions = new ();
    }

    public bool Evaluate()
    {
        if (!conditions.Any())
        {
            Debug.Log("Compound Condition list is empty, returning true");
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

