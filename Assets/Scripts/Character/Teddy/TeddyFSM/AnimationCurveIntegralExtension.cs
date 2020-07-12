using System;
using UnityEngine;

namespace GameCore.ExtensionMethods
{
	/// <summary> used to get area below animation curve </summary>
	public static class AnimationCurveIntegralExtension
	{
		
		// Integrate area under AnimationCurve between start and end time
		public static float IntegrateCurve(this AnimationCurve curve, float startTime, float endTime, int steps)
		{
			return Integrate(curve.Evaluate, startTime, endTime, steps);
		}
 
		// Integrate function f(x) using the trapezoidal rule between x=x_low..x_high
		private static float Integrate(Func<float, float> f, float xLow, float xHigh, int nSteps)
		{
			float h = (xHigh - xLow) / nSteps;
			float res = (f(xLow) + f(xHigh)) / 2;
			for (int i = 1; i < nSteps; i++)
			{
				res += f(xLow + i * h);
			}
			return h * res;
		}
		
	}
}