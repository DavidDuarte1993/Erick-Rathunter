using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BlinkingTextScript : MonoBehaviour
{
    [SerializeField]
    Text BlinkingText;
    [SerializeField]
    Image img = null;
    public string IsBlinkingText = "";
    string WhiteText = "";
    bool IsBlinking = true;

    void Start()
    {
        IsBlinking = true;
        StartCoroutine(BlinkText());

    }

    public void activeBlinkText()
    {
        IsBlinking = true;

        BlinkingText = GetComponent<Text>();

        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (IsBlinking)
        {
            if (BlinkingText != null)
                BlinkingText.text = WhiteText;
            if (img != null)
                img.enabled = false;

            yield return new WaitForSeconds(.5f);
            if (img != null)
                img.enabled = true;
            if (BlinkingText != null)
                BlinkingText.text = IsBlinkingText;
            yield return new WaitForSeconds(1f);
        }
    }
}
