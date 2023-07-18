using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{ 

    public Image ObjectWithImageComponent;

    private void Update()
    {

        if(ObjectWithImageComponent != null)
        {
            Debug.Log(ObjectWithImageComponent.GetComponent<Image>().color.a);
            if(ObjectWithImageComponent.GetComponent<Image>().color.a > 0)
            {
                var color = ObjectWithImageComponent.GetComponent<Image>().color;


                ObjectWithImageComponent.fillAmount = 100;
                //Instantiate(ObjectWithImageComponent.GetComponent<Image>());
               // color.a -= 0.01f;
                Debug.Log(color);

                ObjectWithImageComponent.GetComponent <Image>().color = color;
                
            
            }
        }
    }

    public void ScreenFlash2()
    {
        Debug.Log("ScreenFlash");
        var color = ObjectWithImageComponent.GetComponent<Image>().color;
        color.a = 0.8f;

        ObjectWithImageComponent.GetComponent<Image>().color = color;
        Debug.Log("Final color for the Image" + ObjectWithImageComponent.GetComponent<Image>().color);
    }
}
