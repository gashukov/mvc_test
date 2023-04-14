using System.Collections.Generic;
using Core;
using UI.OfferWindow;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI.MainMenu
{
    public class MainWindowInputAdapter : WindowInputAdapterBase<MainWindowController>
    {
        [SerializeField] private Button _openOfferWindowButton;
        [SerializeField] private InputField _titleInput;
        [SerializeField] private InputField _descriptionInput;
        [SerializeField] private InputField _priceInput;
        [SerializeField] private InputField _saleInput;
        [SerializeField] private InputField _iconNameInput;
        [SerializeField] private InputField _stackNumberInput;
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        protected override void ConstructInner()
        {
            _openOfferWindowButton.OnClickAsObservable().Subscribe(_ =>
            {
                var items = new List<ItemData>(int.Parse(_stackNumberInput.text));

                Debug.Log($"Adapter {items.Capacity}");
                
                var type = typeof(ItemId);
                var values = type.GetEnumValues();

                for (int i = 0; i < items.Capacity; i++)
                {
                    items.Add(new ItemData
                    {
                        Count = Random.Range(10, 101),
                        ItemId = (ItemId)values.GetValue(Random.Range(0, values.Length))
                    });
                    Debug.Log($"Adapter print {items[i].Count} {items[i].ItemId}");
                }
                WindowController.OnOpenOfferButtonClicked(
                    new OfferWindowData
                    {
                        WindowId = WindowId.OfferWindow,
                        Title = _titleInput.text,
                        Description = _descriptionInput.text,
                        Price = float.Parse(_priceInput.text),
                        Sale = int.Parse(_saleInput.text),
                        IconName = _iconNameInput.text,
                        Items = items
                    });
            }).AddTo(_disposable);
        }
    }
}