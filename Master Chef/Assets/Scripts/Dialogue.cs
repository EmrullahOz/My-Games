using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public RawImage image;
    public Texture[] mytexture;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        image.texture = mytexture[index];
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
                image.texture = mytexture[index];
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                gameObject.SetActive(false);
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);

        }
    }
    //public void Bas()
    //{

    //    if (textComponent.text == lines[index])
    //    {
    //        NextLine();
    //    }
    //    else
    //    {
    //        StopAllCoroutines();

    //        textComponent.text = lines[index];
    //        gameObject.SetActive(false);
    //    }

    //}
}
