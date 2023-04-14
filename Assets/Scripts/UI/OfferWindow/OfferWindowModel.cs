using System;
using UniRx;
using UnityEngine;

namespace UI.OfferWindow
{
    public class OfferWindowModel : WindowModelBase
    {
        public StringReactiveProperty Title { get; }
        public StringReactiveProperty Description { get; }
        public StringReactiveProperty IconName { get; }
        public ReadOnlyReactiveProperty<Sprite> IconSprite { get; }
        public FloatReactiveProperty Price { get; }
        public IntReactiveProperty Sale { get; }

        public ReadOnlyReactiveProperty<float> PriceWithSale { get; }

        public ReactiveCollection<ItemData> ItemsData { get; }

        public ReactiveCollection<(ItemId, int, Sprite)> Items { get; }

        public IObservable<Unit> ItemsCollectionObservable { get; }

        private readonly ISpriteProvider<ItemId> _itemsSpriteProvider;
        private readonly ISpriteProvider<string> _resourcesSpriteProvider;


        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public OfferWindowModel(OfferWindowData offerWindowData, ISpriteProvider<ItemId> itemsSpriteProvider,
            ISpriteProvider<string> resourcesSpriteProvider)
        {
            _itemsSpriteProvider = itemsSpriteProvider;
            _resourcesSpriteProvider = resourcesSpriteProvider;
            WindowId = offerWindowData.WindowId;
            Title = new StringReactiveProperty(offerWindowData.Title).AddTo(_disposable);
            Description = new StringReactiveProperty(offerWindowData.Description).AddTo(_disposable);
            IconName = new StringReactiveProperty(offerWindowData.IconName).AddTo(_disposable);
            IconSprite = IconName.Select(_resourcesSpriteProvider.GetSprite).ToReadOnlyReactiveProperty()
                .AddTo(_disposable);
            Price = new FloatReactiveProperty(offerWindowData.Price).AddTo(_disposable);
            Sale = new IntReactiveProperty(offerWindowData.Sale).AddTo(_disposable);
            PriceWithSale = Price.CombineLatest(Sale, (price, sale) => price * (100 - sale) / 100f)
                .ToReadOnlyReactiveProperty().AddTo(_disposable);
            ItemsData = new ReactiveCollection<ItemData>(offerWindowData.Items).AddTo(_disposable);

            var observeAdd = ItemsData.ObserveAdd().Select(_ => Unit.Default);
            var observeRemove = ItemsData.ObserveRemove().Select(_ => Unit.Default);
            var observeMove = ItemsData.ObserveMove().Select(_ => Unit.Default);
            var observeReplace = ItemsData.ObserveReplace().Select(_ => Unit.Default);
            var observeCountChanged = ItemsData.ObserveCountChanged().Select(_ => Unit.Default);

            ItemsCollectionObservable = observeAdd
                .Merge(observeRemove, observeMove, observeReplace, observeCountChanged);

            Items = new ReactiveCollection<(ItemId, int, Sprite)>();
            Items.Clear();
            foreach (var data in ItemsData)
            {
                Items.Add((data.ItemId, data.Count, _itemsSpriteProvider.GetSprite(data.ItemId)));
            }
            ItemsCollectionObservable.Subscribe(unit =>
            {
                Items?.Clear();
                foreach (var data in ItemsData)
                {
                    Items?.Add((data.ItemId, data.Count, _itemsSpriteProvider.GetSprite(data.ItemId)));
                }
            });
        }
    }
}