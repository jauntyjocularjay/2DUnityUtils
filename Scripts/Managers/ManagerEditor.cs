using UnityEngine;
using UnityEditor;


namespace DMBTools
{
    [CustomEditor(typeof(Manager), true)]
    public class ManagerEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawDefaultInspector();
            GUILayout.Space(20);
            if(GUILayout.Button("Setup Camera"))
            {
                Manager manager = (Manager) target;
                Manager.SetupCamera();
            }
        }
    }
}
