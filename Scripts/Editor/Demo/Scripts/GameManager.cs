using Unity_AnimationUI.Scripts.Runtime;
using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Scripts
{
public class GameManager : MonoBehaviour
{
    void OnEnable()
    {
        AnimationUI.OnSetActiveAllInput += this.SetActiveAllInput;
    }
    void OnDisable()
    {
        AnimationUI.OnSetActiveAllInput -= this.SetActiveAllInput;
    }
    public void SetActiveAllInput(bool isActive)
    {
        this.transform.GetChild(0).gameObject.SetActive(!isActive);
    }
}

}