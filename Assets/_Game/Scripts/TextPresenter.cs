using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPresenter : MonoBehaviour
{
    public int wordsPerMinute = 250;
    public int baselineWordLength = 4;
    public Text text;
     
    private TextAsset textAsset;

    void Start ()
    {
        textAsset = Resources.Load<TextAsset>("frank_heinen");
        StartCoroutine(PresentText());
	}
	
	private IEnumerator PresentText ()
    {
        foreach (string word in textAsset.text.Split(' '))
        {
            text.text = word;
            yield return new WaitForSeconds((60f / wordsPerMinute) * GetWordDurationModifier(word));
        }

        text.text = "";
    }

    private float GetWordDurationModifier (string word)
    {
        char last = word[word.Length - 1];
        float punctuationModifier;

        switch (last)
        {
            case ',':
                punctuationModifier = 1.5f;
                break;
            case ':':
                punctuationModifier = 1.5f;
                break;
            case ';':
                punctuationModifier = 1.5f;
                break;
            case '.':
                punctuationModifier = 2f;
                break;
            case '?':
                punctuationModifier = 2f;
                break;
            case '!':
                punctuationModifier = 2f;
                break;
            default:
                punctuationModifier = 1f;
                break;
        }

        float lengthModifier = 0.5f + (word.Length / baselineWordLength) * 0.5f;

        return punctuationModifier * lengthModifier;
    }
}
