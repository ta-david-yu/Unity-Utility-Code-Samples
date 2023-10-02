using UnityEditor;

[CustomEditor(typeof(RuntimeSetSO<>), true)]
public class RuntimeSetSOEditor : Editor
{
    private static bool s_DefaultInspectorFoldout = false;

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
        s_DefaultInspectorFoldout =
            EditorGUILayout.Foldout(s_DefaultInspectorFoldout, "Default Inspector", EditorStyles.foldoutHeader);

        if (s_DefaultInspectorFoldout)
        {
            EditorGUILayout.LabelField("Default Inspector", EditorStyles.centeredGreyMiniLabel);
            base.OnInspectorGUI();
        }
    }
}
