using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(Consideration), editorForChildClasses: true)]
public class ConsiderationDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        var consideration = (Consideration)target;

        GUILayout.BeginVertical("Box");
        {
            GUILayout.Label($"  Raw Score: {consideration.RawScore}");
            GUILayout.Label($"      Score: {consideration.EvaluateScore(consideration.RawScore)}");
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