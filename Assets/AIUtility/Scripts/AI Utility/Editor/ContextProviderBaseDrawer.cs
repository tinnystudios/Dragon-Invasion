using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(ContextProviderBase), editorForChildClasses: true)]
public class ContextProviderBaseDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        var provider = (IContextProvider) target;
        var text = provider.Validate ? "All Assigned" : $"Missing Context {provider.Type}";

        GUILayout.BeginVertical("Box");
        {
            GUILayout.Label(text);
        }
        GUILayout.EndVertical();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }

        base.OnInspectorGUI();
    }
}