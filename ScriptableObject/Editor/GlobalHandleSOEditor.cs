using UnityEditor;

[CustomEditor(typeof(GlobalHandleSO<>), true)]
public class GlobalHandleSOEditor : Editor
{
    private static bool m_DefaultInspectorFoldout = false;

    public override void OnInspectorGUI()
    {
        GlobalHandleSO globalHandleSo = (target as GlobalHandleSO);

        var instance = globalHandleSo.InstanceAsComponent;

        if (instance)
        {
            EditorGUILayout.LabelField($"registered object", EditorStyles.centeredGreyMiniLabel);
            
            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.ObjectField(instance, typeof(UnityEngine.Object), allowSceneObjects: true);
            }
        }
        else
        {
            EditorGUILayout.LabelField("There is currently no object registered to this handle",
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