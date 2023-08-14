using UnityEditor;

[CustomEditor(typeof(RuntimeSetSO<>), true)]
public class RuntimeSetSOEditor : Editor
{
    private static bool _defaultInspectorFoldout = false;

    public override void OnInspectorGUI()
    {
        RuntimeSetSO runtimeSetSo = (target as RuntimeSetSO);

        var instances = runtimeSetSo.InstancesAsObjects;

        if (instances.Count > 0)
        {
            EditorGUILayout.LabelField($"{instances.Count} objects", EditorStyles.centeredGreyMiniLabel);

            using (new EditorGUI.DisabledScope(true))
            {
                foreach (var unityObject in instances)
                {
                    EditorGUILayout.ObjectField(unityObject, typeof(UnityEngine.Object), allowSceneObjects: true);
                }
            }
        }
        else
        {
            EditorGUILayout.LabelField("There is currently no object registered to this runtime set",
                EditorStyles.centeredGreyMiniLabel);
        }

        EditorGUILayout.Separator();
        _defaultInspectorFoldout =
            EditorGUILayout.Foldout(_defaultInspectorFoldout, "Default Inspector", EditorStyles.foldoutHeader);

        if (_defaultInspectorFoldout)
        {
            EditorGUILayout.LabelField("Default Inspector", EditorStyles.centeredGreyMiniLabel);
            base.OnInspectorGUI();
        }
    }
}
