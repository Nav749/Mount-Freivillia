using UnityEngine;
using UnityEditor;

namespace CustomDialogueGraph.Editor
{
    [CustomEditor(typeof(CustomDialogueGraphAsset))]
    public class CustomDialogueGraphAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Open"))
            {
                CustomDialogueEditorWindow.Open((CustomDialogueGraphAsset)target);
            }
        }
    }
}
