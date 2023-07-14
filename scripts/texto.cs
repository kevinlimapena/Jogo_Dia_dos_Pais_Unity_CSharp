using UnityEngine;
using TMPro; 
public class texto : MonoBehaviour
{
   public TMP_Text textLabel;

   private void Start() 
   {
     //GetComponent <TypewriterEffect>().Run("isso é um pouco de texto ",textLabel);
     textLabel.text = "ola isso é \n kevin kevin";
   }

}
