using UnityEditor;
using UnityEngine;

namespace CustomDialogueGraph.Editor
{
    public class CustomDialogueEditorWindow : EditorWindow
    {
        [SerializeField] private CustomDialogueGraphAsset m_currentGraph;  
        [SerializeField] private CustomDialogueGraphView m_currentView;
        [SerializeField] private SerializedObject m_serializedObject;

        public CustomDialogueGraphAsset currentGraph => m_currentGraph;

        public static void Open(CustomDialogueGraphAsset target)
        {
            CustomDialogueEditorWindow[] windows =  Resources.FindObjectsOfTypeAll<CustomDialogueEditorWindow>();
            foreach (var w in windows)
            {
                if (w.currentGraph == target)
                {
                    w.Focus();
                    return; 
                }
               
            }
            CustomDialogueEditorWindow window = CreateWindow<CustomDialogueEditorWindow>(typeof(CustomDialogueEditorWindow), typeof(SceneView));
            window.titleContent = new GUIContent($"{target.name}", EditorGUIUtility.ObjectContent(null, typeof(CustomDialogueGraphAsset)).image);
            window.Load(target);

        }

        public void Load(CustomDialogueGraphAsset target)
        {
            m_currentGraph = target;
            DrawGraph();
        }

        private void DrawGraph()
        {
            m_serializedObject = new SerializedObject(m_currentGraph);
            m_currentView = new CustomDialogueGraphView();
            rootVisualElement.Add(m_currentView);

        }
    }
}
