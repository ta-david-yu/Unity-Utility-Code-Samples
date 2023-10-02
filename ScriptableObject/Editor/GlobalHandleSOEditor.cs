using UnityEditor;

[CustomEditor(typeof(GlobalHandleSO<>), true)]
public class GlobalHandleSOEditor : Editor
{
    private static bool s_DefaultInspectorFoldout = false;

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
        s_DefaultInspectorFoldout =
            EditorGUILayout.Foldout(s_DefaultInspectorFoldout, "Default Inspector", EditorStyles.foldoutHeader);

        if (s_DefaultInspectorFoldout)
        {
            EditorGUILayout.LabelField("Default Inspector", EditorStyles.centeredGreyMiniLabel);
            base.OnInspectorGUI();
        }
    }
}