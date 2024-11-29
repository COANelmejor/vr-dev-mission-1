using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : MonoBehaviour {
    // Start is called before the first frame update

    [SerializeField]
    private GameObject hourHand;
    [SerializeField]
    private GameObject minuteHand;
    [SerializeField]
    private GameObject secondHand;
    void Start() {

        // Find the hour, minute, and second hands, based as children of the clock object


    }

    // Update is called once per frame
    void Update() {

        DateTime localDate = DateTime.Now;
        Debug.Log($"{localDate.Hour}:{localDate.Minute}:{localDate.Second}");
        if (hourHand != null) {
            // Rotate the z axis of the hour hand by 30 degrees per hour
            hourHand.transform.localRotation = Quaternion.Euler(90 + (30 * localDate.Hour), 0, -90);
        }
        if (minuteHand != null) {
            // Rotate the minute hand by 6 degrees per minute
            minuteHand.transform.localRotation = Quaternion.Euler(90 + (6 * localDate.Minute), 0, -90);
        }
        if (secondHand != null) {
            // Rotate the second hand by 6 degrees per second
            secondHand.transform.localRotation = Quaternion.Euler(90 + (6 * localDate.Second), 0, -90);
        }
    }
}
