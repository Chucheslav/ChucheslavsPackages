using ScriptableObjectArchitecture.Base;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectArchitecture.Editor
{
[CustomEditor(typeof(CameraVariable))]
public class CameraVariableEditor: GenericVariableEditor<Camera>{}

[CustomEditor(typeof(CameraEvent))]
public class CameraEventEditor: GenericEventEditor<Camera>{}

[CustomEditor(typeof(FloatVariable))]
public class FloatVariableEditor: GenericVariableEditor<float>{}

[CustomEditor(typeof(FloatEvent))]
public class FloatEventEditor: GenericEventEditor<float>{}

[CustomEditor(typeof(BoolVariable))]
public class BoolVariableEditor: GenericVariableEditor<bool>{}

[CustomEditor(typeof(GenericVariable<bool>))]
public class BoolEventEditor: GenericEventEditor<bool>{}

[CustomEditor(typeof(GameObjectVariable))]
public class GameObjectVariableEditor: GenericVariableEditor<GameObject>{}

[CustomEditor(typeof(GameObjectEvent))]
public class GameObjectEventEditor: GenericEventEditor<GameObject>{}

[CustomEditor(typeof(IntVariable))]
public class IntVariableEditor: GenericVariableEditor<int>{}

[CustomEditor(typeof(IntEvent))]
public class IntEventEditor: GenericEventEditor<int>{}

[CustomEditor(typeof(StringVariable))]
public class StringVariableEditor: GenericVariableEditor<string>{}

[CustomEditor(typeof(StringEvent))]
public class StringEventEditor: GenericEventEditor<string>{}

[CustomEditor(typeof(TransformVariable))]
public class TransformVariableEditor: GenericVariableEditor<Transform>{}

[CustomEditor(typeof(TransformEvent))]
public class TransformEventEditor: GenericEventEditor<Transform>{}

[CustomEditor(typeof(Vector2IntVariable))]
public class Vector2IntVariableEditor: GenericVariableEditor<Vector2Int>{}

[CustomEditor(typeof(Vector2IntEvent))]
public class Vector2IntEventEditor: GenericEventEditor<Vector2Int>{}

[CustomEditor(typeof(Vector2Variable))]
public class Vector2VariableEditor: GenericVariableEditor<Vector2>{}

[CustomEditor(typeof(Vector2Event))]
public class Vector2EventEditor: GenericEventEditor<Vector2>{}

[CustomEditor(typeof(Vector3IntVariable))]
public class Vector3IntVariableEditor: GenericVariableEditor<Vector3Int>{}

[CustomEditor(typeof(Vector3IntEvent))]
public class Vector3IntEventEditor: GenericEventEditor<Vector3Int>{}

[CustomEditor(typeof(Vector3Variable))]
public class Vector3VariableEditor: GenericVariableEditor<Vector3>{}

[CustomEditor(typeof(Vector3Event))]
public class Vector3EventEditor: GenericEventEditor<Vector3>{}

[CustomEditor(typeof(Vector3NVariable))]
public class Vector3NVariableEditor: GenericVariableEditor<Vector3?>{}

[CustomEditor(typeof(Vector3NEvent))]
public class Vector3NEventEditor: GenericEventEditor<Vector3?>{}

[CustomEditor(typeof(ColliderVariable))]
public class ColliderVariableEditor: GenericVariableEditor<Collider>{}

[CustomEditor(typeof(ColliderEvent))]
public class ColliderEventEditor: GenericEventEditor<Collider>{}

[CustomEditor(typeof(ColliderVariable))]
public class RaycastHitVariableEditor: GenericVariableEditor<RaycastHit>{}

[CustomEditor(typeof(ColliderEvent))]
public class RaycastHitEventEditor: GenericEventEditor<RaycastHit>{}
}
