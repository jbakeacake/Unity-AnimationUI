using Unity_AnimationUI.Scripts.Editor.Demo.Scripts;
using UnityEditor;
using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Editor
{

[CustomEditor(typeof(AudioManager))]
public class AudioManagerInspector : UnityEditor.Editor
{
    AudioManager _script;

    void OnEnable()
    {
        this._script = (AudioManager)this.target;
    }
    public override void OnInspectorGUI()
    {
        this.DrawDefaultInspector();

        int i = 0;
        int j = 0;
        int width = 100;
        while(i < this._script.SFX.Length)
        {
            j = 0;
            EditorGUILayout.BeginHorizontal();
            do
            {
                var nameProperty = this.serializedObject.FindProperty("SFX").
                    GetArrayElementAtIndex(i).FindPropertyRelative("ClipName");
                var clipProperty = this.serializedObject.FindProperty("SFX").
                    GetArrayElementAtIndex(i).FindPropertyRelative("Clip");
                var volumeProperty = this.serializedObject.FindProperty("SFX").
                    GetArrayElementAtIndex(i).FindPropertyRelative("Volume");
                
                EditorGUILayout.BeginVertical();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.Width(20));
                EditorGUILayout.PropertyField(nameProperty, GUIContent.none, GUILayout.Width(75));
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PropertyField(clipProperty, GUIContent.none, GUILayout.Width(75));
                EditorGUILayout.PropertyField(volumeProperty, GUIContent.none, GUILayout.Width(20));
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();

                EditorGUILayout.Space();
                i++;
                j++;
            }
            while((j+1)*width < EditorGUIUtility.currentViewWidth && i < this._script.SFX.Length);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

        }


            GUILayout.FlexibleSpace();

        this.serializedObject.ApplyModifiedProperties();

    }
}

// You've gone too far, adventurer.

}