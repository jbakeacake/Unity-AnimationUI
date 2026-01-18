using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity_AnimationUI.Scripts.Editor.Demo.Scripts.Struct;
using Unity_AnimationUI.Scripts.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Scripts
{

public class ButtonUI : Selectable, IPointerClickHandler, ISubmitHandler
{
    [SerializeField] ColorBlock _textColors = ColorBlock.defaultColorBlock;
    [SerializeField] ScaleBlock _scales = ScaleBlock.defaultScaleBlock;
    [SerializeField] TMP_Text _text;

    public TMP_Text Text { get => this._text; set => this._text = value;}
    public Graphic TargetGraphic { get => this.targetGraphic; set => this.targetGraphic = value; }

    public static event Action s_onClick;
    public static event Action s_onPointerEnter;
    public static event Action s_onPointerExit;
    public static event Action s_onPointerDown;
    public static event Action s_onPointerUp;
    public static event Action s_onSelect;
    public static event Action s_onDeselect;

    [SerializeField] UnityEvent _onClick;
    [SerializeField] UnityEvent _onPointerEnter;
    [SerializeField] UnityEvent _onPointerExit;
    [SerializeField] UnityEvent _onPointerDown;
    [SerializeField] UnityEvent _onPointerUp;
    [SerializeField] UnityEvent _onSelect;
    [SerializeField] UnityEvent _onDeselect;

    protected override void Awake()
    {
        this.transition = Transition.None;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        s_onClick?.Invoke();
        this._onClick?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, Vector3.one*this._scales.pressedScale, Vector3.one*this._scales.highlightedScale, this._scales.fadeDuration, Ease.InOutQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.colors.pressedColor, this.colors.highlightedColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._textColors.pressedColor, this._textColors.highlightedColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        s_onClick?.Invoke();
        this._onClick?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, Vector3.one*this._scales.pressedScale, Vector3.one*this._scales.highlightedScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.colors.pressedColor, this.colors.highlightedColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._textColors.pressedColor, this._textColors.highlightedColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        s_onPointerDown?.Invoke();
        this._onPointerDown?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, this.targetGraphic.transform.localScale, Vector3.one*this._scales.pressedScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.targetGraphic.color, this.colors.pressedColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._text.color, this._textColors.pressedColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        s_onPointerEnter?.Invoke();
        this._onPointerEnter?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, this.targetGraphic.transform.localScale, Vector3.one*this._scales.highlightedScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.targetGraphic.color, this.colors.highlightedColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._text.color, this._textColors.highlightedColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        s_onPointerExit?.Invoke();
        this._onPointerExit?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, this.targetGraphic.transform.localScale, Vector3.one*this._scales.normalScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.targetGraphic.color, this.colors.normalColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._text.color, this._textColors.normalColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        s_onPointerUp?.Invoke();
        this._onPointerUp?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, this.targetGraphic.transform.localScale, Vector3.one*this._scales.normalScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.targetGraphic.color, this.colors.normalColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._text.color, this._textColors.normalColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public override void OnSelect(BaseEventData eventData)
    {
        s_onSelect?.Invoke();
        this._onSelect?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, this.targetGraphic.transform.localScale, Vector3.one*this._scales.selectedScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.targetGraphic.color, this.colors.selectedColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._text.color, this._textColors.selectedColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public override void OnDeselect(BaseEventData eventData)
    {
        s_onDeselect?.Invoke();
        this._onDeselect?.Invoke();
        this._key++;
        if(this.targetGraphic != null)
        {
            this.StartCoroutine(this.TweenLocalScale(this.targetGraphic.transform, this.targetGraphic.transform.localScale, Vector3.one*this._scales.normalScale, this._scales.fadeDuration, Ease.OutBackQuart));
            this.StartCoroutine(this.TweenGraphicColor(this.targetGraphic, this.targetGraphic.color, this.colors.normalColor, this.colors.fadeDuration, Ease.OutQuart));
        }
        if(this._text != null) this.StartCoroutine(this.TweenTextMeshProColor(this._text, this._text.color, this._textColors.normalColor, this._textColors.fadeDuration, Ease.OutQuart));
    }
    public void SetInteractable(bool isInteractable)
    {
        this.interactable = isInteractable;
        if(this.interactable)
        {
            this.targetGraphic.transform.localScale = this._scales.normalScale * Vector3.one;
            this.targetGraphic.color = this.colors.normalColor;
            this._text.color = this._textColors.normalColor;
        }
        else
        {
            this.targetGraphic.transform.localScale = this._scales.disabledScale * Vector3.one;
            this.targetGraphic.color = this.colors.disabledColor;
            this._text.color = this._textColors.disabledColor;
        }
    }




    byte _key;
    IEnumerator TweenGraphicColor(Graphic graphic, Color start, Color end, float duration, Ease.Function easeFunction)
    {
        byte requirement = this._key;
        float startTime = Time.time;
        float t = (Time.time-startTime)/duration;
        while (t <= 1 && requirement == this._key)
        {
            t = Mathf.Clamp((Time.time-startTime)/duration, 0, 2);
            graphic.color = Color.LerpUnclamped(start, end, easeFunction(t));
            yield return null;
        }
        if(requirement == this._key)
            graphic.color = end;
    }

    IEnumerator TweenLocalScale(Transform trans, Vector3 start, Vector3 end, float duration, Ease.Function easeFunction)
    {
        byte requirement = this._key;
        float startTime = Time.time;
        float t = (Time.time-startTime)/duration;
        while (t <= 1 && requirement == this._key)
        {
            t = Mathf.Clamp((Time.time-startTime)/duration, 0, 2);
            trans.localScale = Vector3.LerpUnclamped(start, end, easeFunction(t));
            yield return null;
        }
        if(requirement == this._key)
            trans.localScale = end;
    }

    IEnumerator TweenTextMeshProColor(TMP_Text text, Color start, Color end, float duration, Ease.Function easeFunction)
    {
        byte requirement = this._key;
        float startTime = Time.time;
        float t = (Time.time-startTime)/duration;
        while (t <= 1 && requirement == this._key)
        {
            t = Mathf.Clamp((Time.time-startTime)/duration, 0, 2);
            text.color = Color.LerpUnclamped(start, end, easeFunction(t));
            yield return null;
        }
        if(requirement == this._key)
            text.color = end;
    }


#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Create ButtonUI")]
    static void CreateButtonUI(MenuCommand menuCommand)
    {
        GameObject selected = Selection.activeGameObject;
        GameObject createdGo = new GameObject("ButtonUI");
        GameObject imgGo = new GameObject("Image");
        GameObject textGo = new GameObject("Text");
        GameObjectUtility.SetParentAndAlign(createdGo, selected);
        GameObjectUtility.SetParentAndAlign(imgGo, createdGo);
        GameObjectUtility.SetParentAndAlign(textGo, imgGo);

        Image img = imgGo.AddComponent<Image>();
        img.color = new Color32(0x30,0x30,0x30,0xff);
        RectTransform imgRect = imgGo.GetComponent<RectTransform>();
        imgRect.anchorMin = new Vector2(0, 0);
        imgRect.anchorMax = new Vector2(1, 1);
        imgRect.sizeDelta = Vector2.zero;

        TextMeshProUGUI text = textGo.AddComponent<TextMeshProUGUI>();
        text.text = "Button";
        text.raycastTarget = false;
        text.color = Color.white;
        text.alignment = TextAlignmentOptions.Center;
        text.fontSize = 45;
        text.fontStyle = FontStyles.Bold;
        text.verticalAlignment = VerticalAlignmentOptions.Middle;
        RectTransform textRect = textGo.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.sizeDelta = Vector2.zero;

        ButtonUI buttonUI = createdGo.AddComponent<ButtonUI>();
        buttonUI.targetGraphic = img;
        buttonUI._text = text;
        RectTransform createdRect = createdGo.AddComponent<RectTransform>();
        createdRect.sizeDelta = new Vector2(400, 90);

        buttonUI.targetGraphic = img;
        buttonUI._text = text;

        ColorBlock graphicColorBlock = new ColorBlock
        {
            normalColor = new Color32(0x30, 0x30, 0x30, 0xff),
            highlightedColor = new Color32(0x43, 0x43, 0x43, 0xff),
            pressedColor = Color.white,
            selectedColor = new Color32(0x43, 0x43, 0x43, 0xff),
            disabledColor = new Color32(0x71, 0x71, 0x71, 0xff),
            fadeDuration = 0.15f
        };
        buttonUI.colors = graphicColorBlock;

        ColorBlock textColorBlock = new ColorBlock()
        {
            normalColor = Color.white,
            highlightedColor = Color.white,
            pressedColor = new Color32(0x30,0x30,0x30,0xff),
            selectedColor = Color.white,
            disabledColor = new Color32(0xA8,0xA8,0xA8,0xff),
            fadeDuration = 0.15f,
        };
        buttonUI._textColors = textColorBlock;

        ScaleBlock scaleBlock = ScaleBlock.defaultScaleBlock;
        buttonUI._scales = scaleBlock;

        Undo.RegisterCreatedObjectUndo(createdGo, "Created +"+createdGo.name);
        Undo.RegisterCreatedObjectUndo(imgGo, "Created +"+imgGo.name);
        Undo.RegisterCreatedObjectUndo(textGo, "Created +"+textGo.name);
    }
    protected override void Reset()
    {
        base.Reset();

        ColorBlock graphicColorBlock = new ColorBlock
        {
            normalColor = new Color32(0x30, 0x30, 0x30, 0xff),
            highlightedColor = new Color32(0x43, 0x43, 0x43, 0xff),
            pressedColor = Color.white,
            selectedColor = new Color32(0x43, 0x43, 0x43, 0xff),
            disabledColor = new Color32(0x71, 0x71, 0x71, 0xff),
            fadeDuration = 0.15f
        };
        this.colors = graphicColorBlock;

        ColorBlock textColorBlock = new ColorBlock()
        {
            normalColor = Color.white,
            highlightedColor = Color.white,
            pressedColor = new Color32(0x30,0x30,0x30,0xff),
            selectedColor = Color.white,
            disabledColor = new Color32(0xA8,0xA8,0xA8,0xff),
            fadeDuration = 0.15f,
        };
        this._textColors = textColorBlock;
    }
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(ButtonUI)), CanEditMultipleObjects]
public class ButtonUI2Editor : UnityEditor.Editor
{
    string[] _excludedPropertyIndexes = new string[] {"m_Transition", "m_SpriteState", "m_AnimationTriggers"};
    SerializedProperty navigationProperty;

    void OnEnable()
    {
        this.navigationProperty = this.serializedObject.FindProperty("m_Navigation");
        s_ShowNavigation = EditorPrefs.GetBool(s_ShowNavigationKey);
        s_Editors.Add(this);
        this.RegisterStaticOnSceneGUI();
    }
    void OnDisable()
    {
        s_Editors.Remove(this);
        this.RegisterStaticOnSceneGUI();
    }


    public override void OnInspectorGUI()
    {
        ButtonUI button = (ButtonUI)this.target;
        SerializedProperty iterator = this.serializedObject.GetIterator();

        // m_Script
        iterator.NextVisible(true);
        GUI.enabled = false;
        EditorGUILayout.PropertyField(iterator, true);
        GUI.enabled = true;

        // m_Navigation
        iterator.NextVisible(false);
        // Visualize
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(iterator, true);
        s_ShowNavigation = GUILayout.Toggle(s_ShowNavigation, this.m_VisualizeNavigation, EditorStyles.miniButton);
        if (EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetBool(s_ShowNavigationKey, s_ShowNavigation);
            SceneView.RepaintAll();
        }
        EditorGUILayout.EndHorizontal();



        // m_Transition
        iterator.NextVisible(false);
        // EditorGUILayout.PropertyField(iterator, true);

        // m_Colors
        iterator.NextVisible(false);
        // EditorGUILayout.PropertyField(iterator, true); Move downward

        // m_SpriteState
        iterator.NextVisible(false);
        // EditorGUILayout.PropertyField(iterator, true);

        // m_AnimationTriggers
        iterator.NextVisible(false);
        // EditorGUILayout.PropertyField(iterator, true);

        // m_Interactable
        iterator.NextVisible(false);
        EditorGUILayout.PropertyField(iterator, true);
        EditorGUILayout.Separator();

        // m_TargetGraphic
        iterator.NextVisible(false);
        string latestProperty = iterator.name;
        // EditorGUILayout.PropertyField(iterator, true);

        // Automatic assign
        if(GUILayout.Button("Assign Target Automatic"))
        {
            T RecursiveFindComponent<T>(Transform parent) where T : Component
            {
                if (parent == null) return null;

                T component = parent.GetComponent<T>();
                if (component != null)return component;
                foreach (Transform child in parent)
                {
                    T result = RecursiveFindComponent<T>(child);
                    if (result != null) return result;
                }
                return null;
            }

            button.targetGraphic = button.GetComponent<Image>();
            if(button.targetGraphic == null)
            {
                button.targetGraphic = RecursiveFindComponent<Graphic>(button.transform);
            }
            button.Text = button.GetComponentInChildren<TMP_Text>();
            if(button.Text == null)
            {
                button.Text = RecursiveFindComponent<TMP_Text>(button.transform);
            }
        }

        // Title
        EditorGUILayout.BeginHorizontal();
        GUILayoutOption labelWidth = GUILayout.Width(EditorGUIUtility.labelWidth);
        EditorGUILayout.LabelField("Target Graphic", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_TargetGraphic"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_text"), GUIContent.none);
        GUIContent label = new GUIContent("Scales");
        EditorGUILayout.LabelField(label, GUILayout.Width(EditorGUIUtility.labelWidth/2));
        EditorGUILayout.EndHorizontal();

        // m_Colors, manually
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Normal", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_Colors.m_NormalColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_textColors.m_NormalColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_scales.m_NormalScale"), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Highlighted", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_Colors.m_HighlightedColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_textColors.m_HighlightedColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_scales.m_HighlightedScale"), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Pressed", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_Colors.m_PressedColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_textColors.m_PressedColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_scales.m_PressedScale"), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Selected", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_Colors.m_SelectedColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_textColors.m_SelectedColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_scales.m_SelectedScale"), GUIContent.none);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Disabled", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_Colors.m_DisabledColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_textColors.m_DisabledColor"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_scales.m_DisabledScale"), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Duration", labelWidth);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("m_Colors.m_FadeDuration"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_textColors.m_FadeDuration"), GUIContent.none);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_scales.m_FadeDuration"), GUIContent.none);
        EditorGUILayout.EndHorizontal();

        iterator.NextVisible(false);
        iterator.NextVisible(false);
        iterator.NextVisible(false);
        EditorGUILayout.Separator();
        while (iterator.NextVisible(false))
        {
            EditorGUILayout.PropertyField(iterator, true);
        }
        this.serializedObject.ApplyModifiedProperties();
    }



    // From SelectableEditor
    GUIContent m_VisualizeNavigation = EditorGUIUtility.TrTextContent("Visualize", "Show navigation flows between selectable UI elements.");
    private static bool s_ShowNavigation = false;
    private static string s_ShowNavigationKey = "SelectableEditor.ShowNavigation";
    private static List<ButtonUI2Editor> s_Editors = new List<ButtonUI2Editor>();
    private void RegisterStaticOnSceneGUI()
    {
        SceneView.duringSceneGui -= StaticOnSceneGUI;
        if (s_Editors.Count > 0)
            SceneView.duringSceneGui += StaticOnSceneGUI;
    }
    private static void StaticOnSceneGUI(SceneView view)
    {
        if (!s_ShowNavigation)
            return;

        Selectable[] selectables = Selectable.allSelectablesArray;

        for (int i = 0; i < selectables.Length; i++)
        {
            Selectable s = selectables[i];
            if (UnityEditor.SceneManagement.StageUtility.IsGameObjectRenderedByCamera(s.gameObject, Camera.current))
                DrawNavigationForSelectable(s);
        }
    }
    private static void DrawNavigationForSelectable(Selectable sel)
    {
        if (sel == null)
            return;

        Transform transform = sel.transform;
        bool active = Selection.transforms.Any(e => e == transform);

        Handles.color = new Color(1.0f, 0.6f, 0.2f, active ? 1.0f : 0.4f);
        DrawNavigationArrow(-Vector2.right, sel, sel.FindSelectableOnLeft());
        DrawNavigationArrow(Vector2.up, sel, sel.FindSelectableOnUp());

        Handles.color = new Color(1.0f, 0.9f, 0.1f, active ? 1.0f : 0.4f);
        DrawNavigationArrow(Vector2.right, sel, sel.FindSelectableOnRight());
        DrawNavigationArrow(-Vector2.up, sel, sel.FindSelectableOnDown());
    }
    const float kArrowThickness = 2.5f;
    const float kArrowHeadSize = 1.2f;

    private static void DrawNavigationArrow(Vector2 direction, Selectable fromObj, Selectable toObj)
    {
        if (fromObj == null || toObj == null)
            return;
        Transform fromTransform = fromObj.transform;
        Transform toTransform = toObj.transform;

        Vector2 sideDir = new Vector2(direction.y, -direction.x);
        Vector3 fromPoint = fromTransform.TransformPoint(GetPointOnRectEdge(fromTransform as RectTransform, direction));
        Vector3 toPoint = toTransform.TransformPoint(GetPointOnRectEdge(toTransform as RectTransform, -direction));
        float fromSize = HandleUtility.GetHandleSize(fromPoint) * 0.05f;
        float toSize = HandleUtility.GetHandleSize(toPoint) * 0.05f;
        fromPoint += fromTransform.TransformDirection(sideDir) * fromSize;
        toPoint += toTransform.TransformDirection(sideDir) * toSize;
        float length = Vector3.Distance(fromPoint, toPoint);
        Vector3 fromTangent = fromTransform.rotation * direction * length * 0.3f;
        Vector3 toTangent = toTransform.rotation * -direction * length * 0.3f;

        Handles.DrawBezier(fromPoint, toPoint, fromPoint + fromTangent, toPoint + toTangent, Handles.color, null, kArrowThickness);
        Handles.DrawAAPolyLine(kArrowThickness, toPoint, toPoint + toTransform.rotation * (-direction - sideDir) * toSize * kArrowHeadSize);
        Handles.DrawAAPolyLine(kArrowThickness, toPoint, toPoint + toTransform.rotation * (-direction + sideDir) * toSize * kArrowHeadSize);
    }
    private static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir)
    {
        if (rect == null)
            return Vector3.zero;
        if (dir != Vector2.zero)
            dir /= Mathf.Max(Mathf.Abs(dir.x), Mathf.Abs(dir.y));
        dir = rect.rect.center + Vector2.Scale(rect.rect.size, dir * 0.5f);
        return dir;
    }
}
#endif

}