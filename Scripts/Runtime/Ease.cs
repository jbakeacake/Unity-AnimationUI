using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_AnimationUI.Scripts.Runtime
{
    public static class Ease
    {
        public static float InQuint(float x) => x * x * x * x * x;
        public static float OutQuint(float x) => -((1 - x) * (1 - x) * (1 - x) * (1 - x) * (1 - x)) + 1;

        public static float InOutQuint(float x) => x < 0.5
            ? 8 * x * x * x * x * x
            : 1 -
              ((-2 * x + 2) * (-2 * x + 2) * (-2 * x + 2) * (-2 * x + 2) * (-2 * x + 2)) / 2;

        public static float OutBackQuint(float x) => -(x - 1) * (x - 1) * (x - 1) * (x - 1)
                                                     + 5 * (x - 1) * (x - 1) * (x - 1) + 5 * (x - 1) * (x - 1) + 1;


        public static float InQuart(float x) => x * x * x * x;
        public static float OutQuart(float x) => -((1 - x) * (1 - x) * (1 - x) * (1 - x)) + 1;

        public static float InOutQuart(float x) => x < 0.5
            ? 8 * x * x * x * x
            : 1 -
              ((-2 * x + 2) * (-2 * x + 2) * (-2 * x + 2) * (-2 * x + 2)) / 2;

        public static float OutBackQuart(float x) => -(x - 1) * (x - 1) * (x - 1) * (x - 1)
                                                     + 4 * (x - 1) * (x - 1) * (x - 1) + 4 * (x - 1) * (x - 1) + 1;


        public static float InCubic(float x) => x * x * x;
        public static float OutCubic(float x) => -((1 - x) * (1 - x) * (1 - x)) + 1;

        public static float InOutCubic(float x) => x < 0.5
            ? 4 * x * x * x
            : 1 -
              ((-2 * x + 2) * (-2 * x + 2) * (-2 * x + 2)) / 2;

        public static float OutBackCubic(float x) => -(x - 1) * (x - 1) * (x - 1) * (x - 1)
                                                     + 3 * (x - 1) * (x - 1) * (x - 1) + 3 * (x - 1) * (x - 1) + 1;


        public static float InQuad(float x) => x * x;
        public static float OutQuad(float x) => -((1 - x) * (1 - x)) + 1;

        public static float InOutQuad(float x) => x < 0.5
            ? 2 * x * x
            : 1 -
              ((-2 * x + 2) * (-2 * x + 2)) / 2;

        public static float OutBackQuad(float x) => -(x - 1) * (x - 1) * (x - 1) * (x - 1)
                                                    + 2 * (x - 1) * (x - 1) * (x - 1) + 2 * (x - 1) * (x - 1) + 1;

        public static float Linear(float x) => x;

        private const float BackConstantInOut = 1.70158f * 1.525f;

        public static float InBack(float x) => 2.70158f * x * x * x - 1.70158f * x * x;

        public static float InOutBack(float x) => x < 0.5
            ? (Mathf.Pow(2 * x, 2) * ((BackConstantInOut + 1) * 2 * x - BackConstantInOut)) / 2
            : (Mathf.Pow(2 * x - 2, 2) * ((BackConstantInOut + 1) * (x * 2 - 2) + BackConstantInOut) + 2) / 2;

        public static float OutBackLinear(float x) => -(x - 1) * (x - 1) * (x - 1) * (x - 1)
                                                      + (x - 1) * (x - 1) * (x - 1) + (x - 1) * (x - 1) + 1;


        public static float OutPowBack(float x, float p) => -(x - 1) * (x - 1) * (x - 1) * (x - 1)
                                                            + p * (x - 1) * (x - 1) * (x - 1) + p * (x - 1) * (x - 1) +
                                                            1;

        public static float OutBack(float x) => 1 + 2.70158f * (x - 1) * (x - 1) * (x - 1)
                                                  + 1.70158f * (x - 1) * (x - 1);


        public enum Type
        {
            In,
            Out,
            InOut,
            OutBack
        }

        public enum Power
        {
            Linear,
            Quad,
            Cubic,
            Quart,
            Quint,
            Back
        }

        // Func<float,float> is longer and harder to type than Ease.Function
        // Also it make sure the kind of function that gets passed are function that has
        // a return float that is normalized between 0 and 1 (can also overshoot but the main part is between 0 and 1)
        public delegate float Function(float x);

        public static Dictionary<Power, Dictionary<Type, Function>> powerToTypeDictionary = new()
        {
            {
                Power.Linear, new Dictionary<Type, Function>
                {
                    {Type.In, Linear},
                    {Type.Out, Linear},
                    {Type.InOut, Linear},
                    {Type.OutBack, Linear}
                }
            },
            {
                Power.Quad, new Dictionary<Type, Function>
                {
                    {Type.In, InQuad},
                    {Type.Out, OutQuad},
                    {Type.InOut, InOutQuad},
                    {Type.OutBack, OutBackQuad}
                }
            },
            {
                Power.Cubic, new Dictionary<Type, Function>
                {
                    {Type.In, InCubic},
                    {Type.Out, OutCubic},
                    {Type.InOut, InOutCubic},
                    {Type.OutBack, OutBackCubic}
                }
            },
            {
                Power.Quart, new Dictionary<Type, Function>
                {
                    {Type.In, InQuart},
                    {Type.Out, OutQuart},
                    {Type.InOut, InOutQuart},
                    {Type.OutBack, OutBackQuart}
                }
            },
            {
                Power.Quint, new Dictionary<Type, Function>
                {
                    {Type.In, InQuint},
                    {Type.Out, OutQuint},
                    {Type.InOut, InOutQuint},
                    {Type.OutBack, OutBackQuint}
                }
            },
            {
                Power.Back, new Dictionary<Type, Function>
                {
                    {Type.In, InBack},
                    {Type.Out, OutBack},
                    {Type.InOut, InOutBack},
                    {Type.OutBack, OutBackLinear}
                }
            }
        };

        public static Function GetEase(Type type, Power power)
        {
            if (power == Power.Linear) return Linear;

            return powerToTypeDictionary.TryGetValue(power, out var functions)
                ? functions[type]
                : Linear;
        }
    }
}