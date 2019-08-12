using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Aceleration : MonoBehaviour {
	public float speed = 10.0F;
	public Text console,maxAccelerationConsole;
	public float maxAceleration = 0;

	void Update() {
		
		console.text = "La aceleracion es :"+Input.acceleration.magnitude+" y la rotacion en x es :" + DeviceRotation.Get().eulerAngles.x;
		if (Input.acceleration.magnitude > maxAceleration) {
			maxAceleration = Input.acceleration.magnitude;
			maxAccelerationConsole.text = "Aceleracion maxima = " + maxAceleration;
		}

	}

	public float GetRotation(){
		Quaternion referenceRotation = Quaternion.identity;
		Quaternion deviceRotation = DeviceRotation.Get();
		Quaternion eliminationOfXY = Quaternion.Inverse(
			Quaternion.FromToRotation(referenceRotation * Vector3.forward, 
				deviceRotation * Vector3.forward)
		);
		Quaternion rotationZ = eliminationOfXY * deviceRotation;
		float roll = rotationZ.eulerAngles.z;
		return roll;
	}

	public void ResetMaxAcceleration(){
		maxAceleration = 0;
		maxAccelerationConsole.text = "La aceleracion es : 0";
	}
}
