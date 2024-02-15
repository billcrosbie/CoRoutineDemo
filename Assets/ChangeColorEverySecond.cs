using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Will cycle through the colors listed in the inspector once per second
/// </summary>
public class ChangeColorEverySecond : MonoBehaviour
{
    public Color[] colors = { Color.blue, Color.green, Color.cyan };

    private GameObject objectToChangeColor;
    private Renderer objTCCRender;  //the object to Change Color's renderer component
    private Color originalColor; 


    Coroutine coroutineReference;

    // Start is called before the first frame update
    void Start()
    {
        objectToChangeColor = this.gameObject;
        objTCCRender = objectToChangeColor.GetComponent<Renderer>();
        originalColor = objTCCRender.material.color;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            coroutineReference =  StartCoroutine("CycleColors");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StopCoroutine(coroutineReference);
            objTCCRender.material.color = originalColor;
        }
    }

    IEnumerator CycleColors()
    {
        for (int i=0; i < colors.Length; i++)
        {
            objTCCRender.material.color = colors[i];
            yield return new  WaitForSeconds(1.0f);

        }

        //Done Cylcing - clean up
        objTCCRender.material.color = originalColor;

    }

}
