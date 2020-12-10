using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    
    int pause = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
        
    }
    IEnumerator ShowText(){

        char[] chars = fullText.ToCharArray();
        for ( int i = 0; i <= chars.Length - 1; i++)
        {
            
            pause++;
            if (chars[i] == ' ')
            {
                yield return new WaitForSeconds(delay * 3);
            }
            currentText = fullText.Substring(0, i + 1);
            this.GetComponent<Text>().text = currentText;
            
            yield return new WaitForSeconds(delay);
            
        }
    }
    
}
