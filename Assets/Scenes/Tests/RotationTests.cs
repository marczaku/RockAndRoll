using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RotationTests {
	[Test]
	public void RotationTestsSimplePasses() {
		var original = new Vector3(1f, 2f, 3f);
		var accelOriginal = new Vector3(original.x, original.y, -original.z);
		var result = Quaternion.Euler(90, 0, 0) * accelOriginal;
		var expected = new Vector3(original.x, original.z, original.y);
		Assert.True(expected == result, $"Expected: {nameof(expected)}:{expected} == ${nameof(result)}:${result}");
	}
}