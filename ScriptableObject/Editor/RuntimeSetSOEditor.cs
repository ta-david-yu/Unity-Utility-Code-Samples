using UnityEditor;

[CustomEditor(typeof(RuntimeSetSO<>), true)]
public class RuntimeSetSOEditor : Editor
{
    private static bool m_DefaultInspectorFoldout = false;

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
        m_DefaultInspectorFoldout =
            EditorGUILayout.Foldout(m_DefaultInspectorFoldout, "Default Inspector", EditorStyles.foldoutHeader);

        if (m_DefaultInspectorFoldout)
        {
            EditorGUILayout.LabelField("Default Inspector", EditorStyles.centeredGreyMiniLabel);
            base.OnInspectorGUI();
        }
    }
}
