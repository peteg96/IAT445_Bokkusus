using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public string textShow = "";
    
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    private void Update()
    {
        if (fullText != textShow)
        {
            textShow = fullText;
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText(){

        char[] chars = textShow.ToCharArray();
        for ( int i = 0; i <= chars.Length - 1; i++)
        {
            
            if (chars[i] == ' ' && i % 3 == 0)
            {
                
                yield return new WaitForSeconds(delay * 2);
            }
            currentText = fullText.Substring(0, i + 1);
            this.GetComponent<Text>().text = currentText;
            
            yield return new WaitForSeconds(delay);
            
        }
    }
    
}
