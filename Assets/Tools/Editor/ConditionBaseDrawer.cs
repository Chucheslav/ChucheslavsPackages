using Tools.LogicConditions;
using UnityEditor;

namespace Tools.Editor
{
[CustomPropertyDrawer(typeof(ConditionBase), true)]
public class ConditionBaseDrawer : SubclassSelectorDrawer<ConditionBase>
{
    protected override string BaseTypeDisplayName => "Logic Condition";
}
}
