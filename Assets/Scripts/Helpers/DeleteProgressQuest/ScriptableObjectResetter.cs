using Helpers.DeleteProgressQuest;
using UnityEditor;
using UnityEngine;

#if (UNITY_EDITOR_64 || UNITY_EDITOR)
public class ScriptableObjectResetter : EditorWindow
{
    private ScriptableObjectList _scriptableObjectList;

    [MenuItem("Tools/Reset Scriptable Objects")]
    private static void ShowWindow()
    {
        GetWindow<ScriptableObjectResetter>("Reset Scriptable Objects");
    }

    private void OnGUI()
    {
        _scriptableObjectList = EditorGUILayout.ObjectField("ScriptableObjects List", _scriptableObjectList, typeof(ScriptableObjectList), true) as ScriptableObjectList;

        if (GUILayout.Button("Reset"))
        {
            if (_scriptableObjectList == null)
            {
                Debug.LogError("ScriptableObjectList not set");
                return;
            }

            foreach (var scriptableObject in _scriptableObjectList.Quests)
            {
                scriptableObject.ResetValue();
            }
        }
    }
}
#endif