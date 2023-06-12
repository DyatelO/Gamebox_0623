using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBoardDescription : MonoBehaviour
{
    [SerializeField]
    private Image itemImage;



    public void Awake()
    {
        //ResetDescription();
    }

    public void ResetDescription()
    {
        itemImage.gameObject.SetActive(false);
    }

    public void SetDescription(Sprite sprite)
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = sprite;
    }
}
