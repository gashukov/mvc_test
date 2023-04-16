using System.Collections.Generic;
using System.Linq;
using UI;
using UI.OfferWindow;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    private List<ItemCell> _itemCells;

    private void Awake()
    {
        _itemCells = GetComponentsInChildren<ItemCell>().ToList();
    }

    public void FillGrid(List<(ItemId, int, Sprite)> items)
    {
        for (int i = 0; i < _itemCells.Count; i++)
        {
            _itemCells[i].gameObject.SetActive(i < items.Count);
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (i >= _itemCells.Count)
            {
                break;
            }

            _itemCells[i].Count = items[i].Item2.ToString();
            _itemCells[i].Icon = items[i].Item3;
        }
    }
}