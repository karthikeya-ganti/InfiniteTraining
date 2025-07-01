using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    //Question 2
    //Scenario: Mobile Phone – Ring Notification System
    //You are simulating a mobile phone that can ring when someone calls.
    //Different parts of the phone(like ringtone player, screen display, and vibration motor) need to react to the ring event.
    //To model this, use delegates and events.
    //🎯 Task:
    //Implement the following in C#:
    //1. MobilePhone class
    //Has a delegate RingEventHandler and an event OnRing.
    //Has a method ReceiveCall() which triggers the OnRing event.
    //2. Subscriber classes (handlers):
    //RingtonePlayer – prints: "Playing ringtone..."
    //ScreenDisplay – prints: "Displaying caller information..."
    //VibrationMotor – prints: "Phone is vibrating..."
    //3. In the Main() method:
    //Create an instance of MobilePhone.
    //Subscribe all three components to the OnRing event.
    //Call ReceiveCall() to simulate an incoming call.

    class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            OnRing.Invoke();
        }
    }
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }
    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    class MobileMain
    {
        static void Main()
        {
            // Creating objects
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay display = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            // Subscribing
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += display.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            phone.ReceiveCall();

            Console.ReadKey();
        }
    }
}
