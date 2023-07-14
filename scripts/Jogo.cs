using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogo : MonoBehaviour

{
   public float Modificadordevelocidade =1f;

   public float velocidade = 4.5f;
 public GameObject teste; 
   public float velocidadeMax = 10f;

   private void Update(){
     velocidade = Mathf.Clamp(
       velocidade + Modificadordevelocidade * Time.deltaTime,0, velocidadeMax


     );
   } 
   public void ReniciarJogo ()
   {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
            Time.timeScale = 1;
   }
}