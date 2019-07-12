using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    private GameObject text;

    void Start()
    {
        // text = GameObject.Find("Text");
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            // text.GetComponent<Text>().text = currentText;
            // GameObject.Find("Text").text = currentText;
            GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
