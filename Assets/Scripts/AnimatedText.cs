using System.Collections;
using TMPro;
using UnityEngine;

public class AnimatedText : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float delay = 0.1f;

    public void DisplayMessage(string message)
    {
        StartCoroutine(AnimateText(message));
    }

    private IEnumerator AnimateText(string message)
    {
        tmpText.text = "";
        foreach (char letter in message)
        {
            tmpText.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }
}