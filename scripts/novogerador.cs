using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novogerador: MonoBehaviour
{
 public GameObject[] inimigoprefabs;
    public float delayinicial;
    public GameObject dinossaurovoadorPrefab;
    public float delayentreinimigos;
    public float dinossaurovoadorYmin = -1 ;
    public float dinossaurovoadorYmax = +1 ; 
    public float dinossaurovoadorPontuacaoMin = 300 ;
    
    public float distanciaminima = 4;
    
    public float distanciaMaxima = 8;  


    public Jogador jogadorScript;

    private void Start()
    {
       // InvokeRepeating("Gerarinimigo",delayinicial, delayentrecactos);
       StartCoroutine(Gerarinimigo());

    }
     

    private IEnumerator Gerarinimigo()
    { 
        yield return new WaitForSeconds(delayinicial);
         
      GameObject Ultimoinimigerado =  null ;
      var distanciaNecessaria = 0f;
        while (true)
        {  
 
          distanciaNecessaria = Random.Range(distanciaminima,distanciaMaxima);          

           var geracaoObjetoLiberada = Ultimoinimigerado == null || Vector3.Distance
           (transform.position, Ultimoinimigerado.transform.position)
           >= distanciaNecessaria ;  
                    
             if(geracaoObjetoLiberada )
             {
               var dado = Random.Range(1,10);

         
           if (jogadorScript.pontos >= dinossaurovoadorPontuacaoMin && dado <= 2)
           {
                var posicaoyAleatrorio = Random.Range(dinossaurovoadorYmin, dinossaurovoadorYmax);

                var posicao = new Vector3(
                transform.position.x,
                transform.position.y + posicaoyAleatrorio,
                transform.position.z
             );
             //GERAR DINO VOADOR
              Ultimoinimigerado = Instantiate(dinossaurovoadorPrefab, posicao, Quaternion.identity) ;
          }

          else
         {
            // GERAR CACTOS ;   
            var quantidadedecactos = inimigoprefabs.Length;
            var indicealeatorio = Random.Range(0, quantidadedecactos);
            var inimigoprefab = inimigoprefabs[indicealeatorio] ;
            Ultimoinimigerado = Instantiate(inimigoprefab,transform.position, Quaternion.identity) ;
         } 
         // var dados = Random.Range(0,1);
          yield return new WaitForSeconds(delayentreinimigos);   
          yield return null;
          distanciaNecessaria = Random.Range(distanciaminima,distanciaMaxima);
        }
              
             }

           
    } 
}
