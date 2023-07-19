using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{ 

    public Image ObjectWithImageComponent;

    private void Update()
    {

        if(ObjectWithImageComponent != null)
        {
            if(ObjectWithImageComponent.GetComponent<Image>().color.a > 0)
            {
                var color = ObjectWithImageComponent.GetComponent<Image>().color;


                ObjectWithImageComponent.fillAmount = 100;
                //Instantiate(ObjectWithImageComponent.GetComponent<Image>());
               // color.a -= 0.01f;

               ObjectWithImageComponent.GetComponent <Image>().color = color;
                
            
            }
        }
    }

    public void ScreenFlash2()
    {
        var color = ObjectWithImageComponent.GetComponent<Image>().color;
        color.a = 0.8f;

        ObjectWithImageComponent.GetComponent<Image>().color = color;
    }
}
