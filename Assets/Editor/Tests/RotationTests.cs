using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RotationTests {
	[Test]
	public void RotatingTheVectorYieldsExpectedResult() {
		var original = new Vector3(1f, 2f, 3f);
		var result = TiltBallController.AccelerationToFlatUnityCoordinates(original);
		var expected = new Vector3(original.x, original.z, original.y);
		Assert.True(expected == result, $"Expected: {nameof(expected)}:{expected} == ${nameof(result)}:${result}");
	}
	
	[Test]
	public void RotatingTheVectorYieldsExpectedResultWithoutGravity() {
		var original = new Vector3(1f, 2f, 3f);
		var result = TiltBallController.AccelerationToFlatUnityCoordinates(original, true);
		var expected = new Vector3(original.x, 0, original.y);
		Assert.True(expected == result, $"Expected: {nameof(expected)}:{expected} == ${nameof(result)}:${result}");
	}
}