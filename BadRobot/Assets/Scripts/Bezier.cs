using UnityEngine;
using System.Collections;


public class Bezier
{
	public static Vector3 getBezierCurvePoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float u)
	{
		return Mathf.Pow(u, 3) * (p3 + 3 * (p1 - p2) - p0) + 3 * Mathf.Pow(u, 2) * (p0 - 2 * p1 + p2) + 3 * u * (p1 - p0) + p0;
	}
}