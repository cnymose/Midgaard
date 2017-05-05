using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAdjustment : MonoBehaviour {

    float height = 0f;
    float width = 0f;
    float xPos, yPos;
    int i = 0;
    private GUIText txt;
    bool writing = true;
    
    string intro = "Centuries have passed since Ragnarok, where fire rained and the gods fell from the heavens." + "\n" + "\n" + "Yggdrasil, the world tree, was ruined, and only seeds remain A young seer, Kenna, is tasked with finding artifacts of old" + "\n" + "\n" + " to once again restore the great tree and heal the world. The night is silent, and upon a dark road awakens a lonely traveler..";

    // Use this for initialization
    void Start () {
        txt = transform.Find("Text").gameObject.GetComponent<GUIText>();
        height = Screen.height;
        width = Screen.width;
        Debug.Log("H =" + height + " W =" + width);
        xPos = width/2;
        yPos = height/2;
        //GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        txt.pixelOffset.Set(xPos,yPos);
        StartCoroutine(WriteText());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WriteText()
    {
        while (writing)
        {
            
            if (i < intro.Length)
            {
                txt.text = txt.text + intro[i];
                i++;
                yield return new WaitForSeconds(0.03f);
            }
            else
            {
                writing = false;
                yield break; 
            }
            
        }
        yield return null;

    }
}
