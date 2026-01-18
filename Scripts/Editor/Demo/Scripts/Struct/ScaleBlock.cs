using System;
using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Scripts.Struct
{
    [Serializable]
    /// <summary>
    /// Structure that stores the state of a Scale transition on a Selectable.
    /// </summary>
    public struct ScaleBlock : IEquatable<ScaleBlock>
    {
        [SerializeField] private float m_NormalScale;
        [SerializeField] private float m_HighlightedScale;
        [SerializeField] private float m_PressedScale;
        [SerializeField] private float m_SelectedScale;
        [SerializeField] private float m_DisabledScale;
        [Range(1, 5)] [SerializeField] private float m_ScaleMultiplier;
        [SerializeField] private float m_FadeDuration;

        /// <summary>
        /// The normal Scale for this Scale block.
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///     public float newScale;
        ///
        ///     void Start()
        ///     {
        ///         //Changes the button's Normal Scale to the new Scale.
        ///         ScaleBlock cb = button.Scales;
        ///         cb.normalScale = newScale;
        ///         button.Scales = cb;
        ///     }
        /// }
        /// ]]>
        ///</code>
        /// </example>
        public float normalScale       { get { return this.m_NormalScale; } set { this.m_NormalScale = value; } }

        /// <summary>
        /// The highlight Scale for this Scale block.
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///     public float newScale;
        ///
        ///     void Start()
        ///     {
        ///         //Changes the button's Highlighted Scale to the new Scale.
        ///         ScaleBlock cb = button.Scales;
        ///         cb.highlightedScale = newScale;
        ///         button.Scales = cb;
        ///     }
        /// }
        /// ]]>
        ///</code>
        /// </example>
        public float highlightedScale  { get { return this.m_HighlightedScale; } set { this.m_HighlightedScale = value; } }

        /// <summary>
        /// The pressed Scale for this Scale block.
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///     public float newScale;
        ///
        ///     void Start()
        ///     {
        ///         //Changes the button's Pressed Scale to the new Scale.
        ///         ScaleBlock cb = button.Scales;
        ///         cb.pressedScale = newScale;
        ///         button.Scales = cb;
        ///     }
        /// }
        /// ]]>
        ///</code>
        /// </example>
        public float pressedScale      { get { return this.m_PressedScale; } set { this.m_PressedScale = value; } }

        /// <summary>
        /// The selected Scale for this Scale block.
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///     public float newScale;
        ///
        ///     void Start()
        ///     {
        ///         //Changes the button's Selected Scale to the new Scale.
        ///         ScaleBlock cb = button.Scales;
        ///         cb.selectedScale = newScale;
        ///         button.Scales = cb;
        ///     }
        /// }
        /// ]]>
        ///</code>
        /// </example>
        public float selectedScale     { get { return this.m_SelectedScale; } set { this.m_SelectedScale = value; } }

        /// <summary>
        /// The disabled Scale for this Scale block.
        /// </summary>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        ///
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public Button button;
        ///     public float newScale;
        ///
        ///     void Start()
        ///     {
        ///         //Changes the button's Disabled Scale to the new Scale.
        ///         ScaleBlock cb = button.Scales;
        ///         cb.disabledScale = newScale;
        ///         button.Scales = cb;
        ///     }
        /// }
        /// ]]>
        ///</code>
        /// </example>
        public float disabledScale     { get { return this.m_DisabledScale; } set { this.m_DisabledScale = value; } }

        /// <summary>
        /// Multiplier applied to Scales (allows brightening greater then base Scale).
        /// </summary>
        public float ScaleMultiplier   { get { return this.m_ScaleMultiplier; } set { this.m_ScaleMultiplier = value; } }

        /// <summary>
        /// How long a Scale transition between states should take.
        /// </summary>
        public float fadeDuration      { get { return this.m_FadeDuration; } set { this.m_FadeDuration = value; } }

        /// <summary>
        /// Simple getter for a code generated default ScaleBlock.
        /// </summary>
        public static ScaleBlock defaultScaleBlock;

        static ScaleBlock()
        {
            defaultScaleBlock = new ScaleBlock
            {
                m_NormalScale      = 1,
                m_HighlightedScale = 1.1f,
                m_PressedScale     = 1.2f,
                m_SelectedScale    = 1.1f,
                m_DisabledScale    = 1,
                ScaleMultiplier    = 1.0f,
                fadeDuration       = 0.15f
            };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ScaleBlock))
                return false;

            return this.Equals((ScaleBlock)obj);
        }

        public bool Equals(ScaleBlock other)
        {
            return this.normalScale == other.normalScale &&
                this.highlightedScale == other.highlightedScale &&
                this.pressedScale == other.pressedScale &&
                this.selectedScale == other.selectedScale &&
                this.disabledScale == other.disabledScale &&
                this.ScaleMultiplier == other.ScaleMultiplier &&
                this.fadeDuration == other.fadeDuration;
        }

        public static bool operator==(ScaleBlock point1, ScaleBlock point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator!=(ScaleBlock point1, ScaleBlock point2)
        {
            return !point1.Equals(point2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}