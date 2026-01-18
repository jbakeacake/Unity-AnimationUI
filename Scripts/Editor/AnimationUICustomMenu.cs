using Unity_AnimationUI.Scripts.Runtime;
using UnityEditor;
using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor
{
public class AnimationUICustomMenu
{
    [MenuItem("GameObject/UI/Create AnimationUI")]
    static void CreateAnimationUI(MenuCommand menuCommand)
    {
        GameObject selected = Selection.activeGameObject;
        GameObject createdGo = new GameObject("AnimationUI");
        createdGo.AddComponent<AnimationUI>();
        GameObjectUtility.SetParentAndAlign(createdGo, selected);
        Undo.RegisterCreatedObjectUndo(createdGo, "Created +"+createdGo.name);
    }

}

}