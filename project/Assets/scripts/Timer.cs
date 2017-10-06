using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public int  Minutes = 2;
   public int  Seconds = 0;
   public bool  finished;
   private bool stopped;

   private Text    m_text;
   private float   m_leftTime;

   private void Awake()
   {
       m_text = GameObject.Find("Canvas/Timer").GetComponent<Text>();
       m_leftTime = GetInitialTime();
   }

   private void Start(){
      finished = false;
      stopped = false;
   }

   private void Update()
   {
      if(stopped) return;
       if (m_leftTime > 0f)
       {
           //  Update countdown clock
           m_leftTime -= Time.deltaTime;
           Minutes = GetLeftMinutes();
           Seconds = GetLeftSeconds();

           //  Show current clock
           if (m_leftTime > 0f)
           {
               m_text.text = "Time : " + Minutes + ":" + Seconds.ToString("00");
           }
           else
           {
               //  The countdown clock has finished
               m_text.text = "Time : 0:00";
               finished = true;
           }
       }
   }

   private float GetInitialTime()
   {
       return Minutes * 60f + Seconds;
   }

   private int GetLeftMinutes()
   {
       return Mathf.FloorToInt(m_leftTime / 60f);
   }

   private int GetLeftSeconds()
   {
       return Mathf.FloorToInt(m_leftTime % 60f);
   }

   public void stopTimer(){
      stopped = true;
   }

   public void ResetTimer(){
      Awake();
   }
}
