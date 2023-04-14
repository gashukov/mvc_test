using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    [SerializeField] private Text _count;
    [SerializeField] private Image _icon;
    
    public string Count
    {
        set => _count.text = value;
    }
    
    public Sprite Icon
    {
        set => _icon.sprite = value;
    } 
}
