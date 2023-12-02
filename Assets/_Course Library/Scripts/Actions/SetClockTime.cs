using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetClockTime : MonoBehaviour
{
    public GameObject hoursHand;
    public GameObject minutesHand;
    public GameObject secondsHand;
    private int prevHour;
    private int prevMinute;
    private int prevSecond;

    // Start is called before the first frame update
    void Start()
    {
        DateTime localDate = DateTime.Now;
        String localTime = localDate.ToString().Split(' ')[1];
        prevHour = Int32.Parse(localTime.Split(':')[0]);
        prevMinute = Int32.Parse(localTime.Split(":")[1]);
        prevSecond = Int32.Parse(localTime.Split(':')[2]);
    }

    // Update is called once per frame
    void Update()
    {
        // Minutes/seconds * 6 + 90
        // Hours * 30 + 90
        DateTime localDate = DateTime.Now;
/*        Debug.Log("local Date & Time: " + localDate);
*/
        String localTime = localDate.ToString().Split(' ')[1];
/*        Debug.Log("local Time: " + localTime);
*/
        int hours = Int32.Parse(localTime.Split(':')[0]);
        int minutes = Int32.Parse(localTime.Split(':')[1]);
        int seconds = Int32.Parse(localTime.Split(':')[2]);
/*        Debug.Log("Hours: " + hours);
        Debug.Log("Minutes: " + minutes);
        Debug.Log("Seconds: " + seconds);*/

        if (prevHour < hours)
        {
            hoursHand.transform.eulerAngles = new Vector3(
                hoursHand.transform.eulerAngles.x + (hours*30),
                hoursHand.transform.eulerAngles.y - 90,
                hoursHand.transform.eulerAngles.z - 90);
            prevHour = hours;
        }
        if (prevMinute < minutes)
        {
            minutesHand.transform.eulerAngles = new Vector3(
                minutesHand.transform.eulerAngles.x + (minutes * 6),
                minutesHand.transform.eulerAngles.y - 90,
                minutesHand.transform.eulerAngles.z - 90);
            prevMinute = minutes;
        }

/*        secondsHand.transform.Rotate(Vector3.up * Time.deltaTime);
*/        secondsHand.transform.rotation = Quaternion.Euler(new Vector3(
            secondsHand.transform.eulerAngles.x + (seconds * 6),
            secondsHand.transform.eulerAngles.y - 90,
            secondsHand.transform.eulerAngles.z - 90) * Time.deltaTime);

      /*      secondsHand.transform.eulerAngles = new Vector3(
                secondsHand.transform.eulerAngles.x + (seconds * 6),
                secondsHand.transform.eulerAngles.y - 90,
                secondsHand.transform.eulerAngles.z - 90);
            prevSecond = seconds;*/
        
    }
}
