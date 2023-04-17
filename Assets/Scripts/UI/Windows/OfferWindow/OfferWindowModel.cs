using System;
using GameLogic.Data;
using GameLogic.Providers;
using UI.Core.Windows;
using UniRx;
using UnityEngine;

namespace UI.Windows.OfferWindow
{
    public class OfferWindowModel : WindowModelBase<OfferWindowData>
    {
        public StringReactiveProperty Title { get; }
        public StringReactiveProperty Description { get; }
        public StringReactiveProperty IconName { get; }
        public ReadOnlyReactiveProperty<Sprite> IconSprite { get; }
        public FloatReactiveProperty Price { get; }
        public ReactiveProperty<uint> Sale { get; }

        public ReadOnlyReactiveProperty<float> PriceWithSale { get; }

        public ReactiveCollection<ItemData> ItemsData { get; }

        public ReactiveCollection<(ItemId, int, Sprite)> Items { get; }

        public IObservable<Unit> ItemsCollectionObservable { get; }

        private readonly ISpriteProvider<ItemId> _itemsSpriteProvider;
        private readonly ISpriteProvider<string> _resourcesSpriteProvider;

        public OfferWindowModel(OfferWindowData offerWindowData, ISpriteProvider<ItemId> itemsSpriteProvider,
            ISpriteProvider<string> resourcesSpriteProvider) : base(offerWindowData)
        {
            _itemsSpriteProvider = itemsSpriteProvider;
            _resourcesSpriteProvider = resourcesSpriteProvider;

            Title = new StringReactiveProperty(offerWindowData.Title).AddTo(Disposable);
            Description = new StringReactiveProperty(offerWindowData.Description).AddTo(Disposable);
            IconName = new StringReactiveProperty(offerWindowData.IconName).AddTo(Disposable);
            IconSprite = IconName.Select(_resourcesSpriteProvider.GetSprite).ToReadOnlyReactiveProperty()
                .AddTo(Disposable);
            Price = new FloatReactiveProperty(offerWindowData.Price).AddTo(Disposable);
            Sale = new ReactiveProperty<uint>(offerWindowData.Sale).AddTo(Disposable);
            PriceWithSale = Price.CombineLatest(Sale, (price, sale) => price * (100 - sale) / 100f)
                .ToReadOnlyReactiveProperty().AddTo(Disposable);
            ItemsData = new ReactiveCollection<ItemData>(offerWindowData.Items).AddTo(Disposable);

            var observeAdd = ItemsData.ObserveAdd().Select(_ => Unit.Default);
            var observeRemove = ItemsData.ObserveRemove().Select(_ => Unit.Default);
            var observeMove = ItemsData.ObserveMove().Select(_ => Unit.Default);
            var observeReplace = ItemsData.ObserveReplace().Select(_ => Unit.Default);
            var observeCountChanged = ItemsData.ObserveCountChanged().Select(_ => Unit.Default);

            ItemsCollectionObservable = observeAdd
                .Merge(observeRemove, observeMove, observeReplace, observeCountChanged);

            Items = new ReactiveCollection<(ItemId, int, Sprite)>();
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