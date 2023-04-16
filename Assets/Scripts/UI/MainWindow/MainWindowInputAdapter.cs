using System.Collections.Generic;
using System.Globalization;
using Core;
using UI.Core;
using UI.OfferWindow;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI.MainWindow
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

        protected override void SetupValidation()
        {
            _stackNumberInput.onValidateInput += (text, index, addedChar) =>
                Validators.ValidateLimitedIntCount(text, index, addedChar, 1, 6);

            _saleInput.onValidateInput +=
                Validators.ValidatePercents;

            _priceInput.onValidateInput +=
                Validators.ValidateHardPrice;
        }

        protected override void SubscribeToInput()
        {
            _openOfferWindowButton.OnClickAsObservable().Subscribe(_ =>
            {
                var items = GetRandomItems();

                WindowController.OnOpenOfferButtonClicked(
                    new OfferWindowData
                    {
                        Title = _titleInput.text,
                        Description = _descriptionInput.text,
                        Price = float.Parse(_priceInput.text, CultureInfo.InvariantCulture),
                        Sale = uint.Parse(_saleInput.text),
                        IconName = _iconNameInput.text,
                        Items = items
                    });
            }).AddTo(this);
        }

        // this method just a stub
        private List<ItemData> GetRandomItems()
        {
            var items = new List<ItemData>(int.Parse(_stackNumberInput.text));

            for (int i = 0; i < items.Capacity; i++)
            {
                items.Add(new ItemData
                {
                    Count = Random.Range(10, 51),
                    ItemId = EnumHelper.GetRandomValue<ItemId>()
                });
            }

            return items;
        }
    }
}