using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Jogador : MonoBehaviour
{
    public float pontos;
    public float moedas = 20;
    public float Highscore ;
    public Text pontostext;
    public Text Highscoretext; 
    
    public bool TomandoDano;

    private bool estanochao;
    public LayerMask Layerchao;
     public float distanciaMinimaChao = 1 ;
    public Rigidbody2D rb;
    public float forcaPulo;

    public float multiplicadorpontos = 1 ; 
    
    public Text vidatext ; 
    public int vida = 3 ;
    public int vidafinal = 0 ; 
    public AudioSource pularAudiosource;

    public GameObject pontosprefab;




    // Start is called before the first frame update
    void Start()
    {
        Highscore = PlayerPrefs.GetFloat("HIGHSCORE");  
        Highscoretext.text = Mathf.FloorToInt(Highscore).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
      pontos  += Time.deltaTime * multiplicadorpontos;
       
      var pontosArrendondados = Mathf.FloorToInt(pontos);

      pontostext.text = pontosArrendondados.ToString();
      vidatext.text = Mathf.FloorToInt(vida).ToString();

       if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
            pularAudiosource.Play();
        }

    }

     void Pular()
    {
       if(estanochao)
       {
          rb.AddForce(Vector2.up * forcaPulo);
         
       }
       
    }
    private void FixedUpdate() 
     {
       estanochao= Physics2D.Raycast(transform.position , Vector2.down, distanciaMinimaChao, Layerchao); 
     } 



    private void OnCollisionEnter2D(Collision2D other) 
     {
         if(other.gameObject.CompareTag("Inimigos"))
         {
            if (pontos>Highscore)
            {
               Highscore = pontos;
               
               PlayerPrefs.SetFloat("HIGHSCORE",Highscore);
            }

            if(other.gameObject.CompareTag("Inimigos"))
            {
              vida = vida -1 ;
              //Time.timeScale = 0;
              TomandoDano = true; 
               
            }    
             if (vida <= vidafinal  )
            {
              Time.timeScale = 0;
            }
           // if(other.gameObject.CompareTag("Pontos"))
           // { 
                
                //pontos = pontos + 20;
           // pontosprefab.SetActive(false) ;
              
          //  }
                   
         } 
     }
     
}
