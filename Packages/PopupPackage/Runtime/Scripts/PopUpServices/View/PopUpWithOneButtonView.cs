using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services.PopUp.View
{
    public sealed class PopUpWithOneButtonView : MonoBehaviour, IPopUpWithOneButtonView
    {
        [SerializeField] private Button approveButton;

        public Action ApproveButton { get; set; }

        private void Awake()
        {
            approveButton.onClick.AddListener(() => ApproveButton?.Invoke());
        }

        private void OnDestroy()
        {
            approveButton.onClick.RemoveAllListeners();
        }
    }
}