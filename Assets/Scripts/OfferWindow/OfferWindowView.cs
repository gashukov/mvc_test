using UnityEngine;
using UnityEngine.UI;

namespace OfferWindow
{
    public class OfferWindowView : MonoBehaviour, IOfferWindowView
    {
        [SerializeField] private Text _title;
        [SerializeField] private Text _description;

        public string Title
        {
            set => _title.text = value;
        }

        public string Description
        {
            set => _description.text = value;
        }
    }
}