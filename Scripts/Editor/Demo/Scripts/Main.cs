using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Scripts
{
public class Main
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialization()
    {
        Singleton.Initialize();
    }
}

}