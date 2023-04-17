using System.Linq;
using TMPro;
using UI.Core.UIElements;
using UI.Core.Windows;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using GameLogic.Helpers;
using UI.Core.Helpers;

namespace UI.Windows.OfferWindow
{
    public class OfferWindowView : WindowViewBase<OfferWindowModel>
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _description;
        [SerializeField] private Text _price;
        [SerializeField] private TextMeshProUGUI _oldPrice;
        [SerializeField] private Text _sale;
        [SerializeField] private GameObject _saleBlob;
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
            WindowModel.PriceWithSale.SubscribeToText(_price, price => price.ToHardPrice()).AddTo(this);
            WindowModel.Sale.Subscribe( sale =>
            {
                _saleBlob.SetActive(sale != 0);
                _oldPrice.gameObject.SetActive(sale != 0);
                _sale.text = sale.ToHardSale();
            }).AddTo(this);
            WindowModel.Price.Subscribe(oldPrice => _oldPrice.text = oldPrice.ToHardPrice()).AddTo(this);
            WindowModel.IconSprite.Subscribe(sprite => _icon.sprite = sprite).AddTo(this);
            WindowModel.ItemsCollectionObservable.Subscribe(_ =>
            {
                _itemGrid.FillGrid(WindowModel.Items.ToList());
            }).AddTo(this);
        }
    }
}