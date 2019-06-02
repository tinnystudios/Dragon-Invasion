using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Intelligence))]
public class IntelligenceDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("Box");
        {
            var intelligence = (Intelligence) target;
            foreach (var decision in intelligence.Decisions.OrderByDescending(x => x.Score))
            {
                var style = decision == intelligence.SelectedDecision ? EditorStyles.boldLabel : EditorStyles.label;
                GUILayout.Label($"{decision.name} : {decision.Score}", style);
            }
        }
        GUILayout.EndVertical();

        base.OnInspectorGUI();

        Repaint();
    }
}