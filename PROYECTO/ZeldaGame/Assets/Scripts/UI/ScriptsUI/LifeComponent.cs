using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeComponent : MonoBehaviour
{
    public Sprite fullHeart, halfHeart, noHeart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }
    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = noHeart;
                break;
            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }
}
public enum HeartStatus
{
    Empty=0,
    Half=1, 
    Full=2,
}
