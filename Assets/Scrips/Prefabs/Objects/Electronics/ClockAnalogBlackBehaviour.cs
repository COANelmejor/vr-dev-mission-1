using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnalogBlackBehaviour : MonoBehaviour
{
    private GameObject hourHand;
    private GameObject minuteHand;
    private GameObject secondHand;

    private void Start() {
        // Find the hands in the children of the clock
        hourHand = transform.Find("Clock_Analog_A_Hour").gameObject;
        minuteHand = transform.Find("Clock_Analog_A_Minute").gameObject;
        secondHand = transform.Find("Clock_Analog_A_Second").gameObject;
    }

    private void FixedUpdate() {
        // Get the current time
        System.DateTime time = System.DateTime.Now;

        // Calculate the rotation of the hands
        float hourRotation = GetFixedRotation((time.Hour % 12) * 30 + time.Minute * 0.5f);
        float minuteRotation = GetFixedRotation(time.Minute * 6);
        float secondRotation = GetFixedRotation((time.Second * 6));

        // Apply the rotation to the hands
        hourHand.transform.localRotation = Quaternion.Euler(hourRotation, 0, -90);
        minuteHand.transform.localRotation = Quaternion.Euler(minuteRotation, 0, -90);
        secondHand.transform.localRotation = Quaternion.Euler(secondRotation, 0, -90);
    }

    private float GetFixedRotation(float rotation) {
        // The rotation of the hands is based on the father gameobject,
        // so we need an offset for the children
        return rotation + 90;
    }
}
