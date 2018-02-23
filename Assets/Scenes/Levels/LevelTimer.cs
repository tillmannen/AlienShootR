using System;
using UnityEngine;

namespace AlienShooter {

    public class LevelTimer : MonoBehaviour {

        private DateTime startTime; 
        private DateTime LastCheck;
        public bool timerStarted;

        public double millisecondsPassed;

        public static string MillisecondsToString(double milliseconds){
            var totseconds = (int)Math.Floor(milliseconds / 1000f);
            var minutes = (int)Math.Floor(totseconds / 60f);
            var seconds = totseconds % 60;
            var millisec = milliseconds % 1000; 
            
            var minuteString = (minutes < 10 ? "0":"") + minutes;
            var secondString = (seconds < 10 ? "0":"") + seconds;
            var milliString = (millisec < 10 ? "000": millisec < 100? "00": millisec < 1000 ? "0" : "") + millisec;
            milliString = milliString.Substring(0,2);

            if(minutes == 0){
                return string.Format("{0}:{1}", secondString, milliString);
            }

            return string.Format("{0}:{1}:{2}", minuteString, secondString, milliString);

        }

        public override string ToString(){
            return MillisecondsToString(millisecondsPassed);
            // var totseconds = (int)Math.Floor(millisecondsPassed / 1000f);
            // var minutes = (int)Math.Floor(totseconds / 60f);
            // var seconds = totseconds % 60;
            // var millisec = millisecondsPassed % 1000; 
            
            // var minuteString = (minutes < 10 ? "0":"") + minutes;
            // var secondString = (seconds < 10 ? "0":"") + seconds;
            // var milliString = (millisec < 10 ? "000": millisec < 100? "00": millisec < 1000 ? "0" : "") + millisec;
            // milliString = milliString.Substring(0,2);

            // if(minutes == 0){
            //     return string.Format("{0}:{1}", secondString, milliString);
            // }

            // return string.Format("{0}:{1}:{2}", minuteString, secondString, milliString);
        } 

        public void StartTimer(){
            timerStarted = true;
            LastCheck = DateTime.Now;            
        }

        public void StopTimer(){
            timerStarted = false;
        }

        public void ResetTimer(){
            millisecondsPassed = 0;
            LastCheck = DateTime.Now;
        }

        void Start(){
            timerStarted = false;
            millisecondsPassed = 0;
        }

        public void UpdateTimer(){
            if(timerStarted){
                if((DateTime.Now - LastCheck).TotalMilliseconds > 5000){
                    // more than five second passed. Reset to 1 millisec
                    LastCheck = DateTime.Now.AddMilliseconds(-1);
                }
                millisecondsPassed += (DateTime.Now - LastCheck).TotalMilliseconds;
                LastCheck = DateTime.Now;
            }
        }
    }
}