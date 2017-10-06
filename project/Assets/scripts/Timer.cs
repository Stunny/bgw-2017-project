using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   public bool  finished;
   private bool stopped;

   private Text    m_text;
   private float   timeLeft;

   private void Awake()
   {
       m_text = GameObject.Find("Canvas/Timer").GetComponent<Text>();
       timeLeft = 30f;
   }

   private void Start(){
      finished = false;
      stopped = true;
   }

   void Update()
     {
        if(stopped) return;
         timeLeft -= Time.deltaTime;
         m_text.text = Mathf.Round(timeLeft).ToString();
         if(timeLeft < 0)
         {
             m_text.text = "0";
             finished = true;
         }
     }

   public void stopTimer(){
      stopped = true;
   }

   public void startTimer(){
      stopped = false;
   }

   public void ResetTimer(){
      timeLeft = 90f;
   }
}
