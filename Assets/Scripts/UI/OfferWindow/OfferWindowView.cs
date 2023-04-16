using System.Linq;
using TMPro;
using UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.OfferWindow
{
    public class OfferWindowView : WindowViewBase<OfferWindowModel>
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _description;
        [SerializeField] private Text _price;
        [SerializeField] private TextMeshProUGUI _oldPrice;
        [SerializeField] private Text _sale;
        [SerializeField] private Image _icon;
        [SerializeField] private ItemGrid _itemGrid;
        
        protected override void InitializeFields()
        {
            _itemGrid.FillGrid(WindowModel.Items.ToList());
        }

        protected override void SubscribeToModel()
        {
            WindowModel.Title.SubscribeToText(_title).AddTo(this);
            WindowModel.Description.SubscribeToText(_description).AddTo(this);
            WindowModel.PriceWithSale.SubscribeToText(_price, price => $"${price:F2}").AddTo(this);
            WindowModel.Sale.SubscribeToText(_sale, sale => $"-{sale.ToString()}%").AddTo(this);
            WindowModel.Price.Subscribe(oldPrice => _oldPrice.text = $"${oldPrice:F2}").AddTo(this);
            WindowModel.IconSprite.Subscribe(sprite => _icon.sprite = sprite).AddTo(this);
            WindowModel.ItemsCollectionObservable.Subscribe(_ =>
            {
                _itemGrid.FillGrid(WindowModel.Items.ToList());
            }).AddTo(this);
        }
    }
}