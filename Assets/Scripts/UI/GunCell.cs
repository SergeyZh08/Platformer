using UnityEngine;
using UnityEngine.UI;

public class GunCell : MonoBehaviour
{
    [SerializeField] private Image _backGround;
    [SerializeField] private Image _weapon;
    [SerializeField] private Slider _slider;

    public void Init(Sprite sprite, int currenBullets, int maxBullets)
    {
        _weapon.sprite = sprite;
        _slider.maxValue = maxBullets;
        _slider.value = currenBullets;
        Debug.Log("test");
    }

    public void ChangeSliderInfo(int currenBullets)
    {
        _slider.value = currenBullets;
    }

    public void SetColor(Color color)
    {
        _backGround.color = color;
    }
}
