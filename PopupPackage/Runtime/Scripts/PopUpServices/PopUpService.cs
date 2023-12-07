using System;
using Services.PopUp.View;
using UnityEngine;
using Utils.ObjectPool;

namespace Services.PopUp
{
    public sealed class PopUpService : IPopUpService
    {
        private ObjectPoolMono<PopUpView> _popUpPool;

        /// <summary>
        /// Paste a prefab popup view
        /// </summary>
        /// <param name="popUpView"> prefab PopUpView </param>
        public PopUpService(IPopUpView popUpView)
        {
            if (popUpView is PopUpView popUp)
            {
                var containerTransform = new GameObject(popUp.GetType().ToString()).transform;
                _popUpPool = new ObjectPoolMono<PopUpView>(popUp, containerTransform, 2,true);
            }
            else
            {
                throw new ArgumentException("Conversion from IPopUpView to the PopUpView is not allowed");
            }
        }

        /// <summary>
        /// Show PopUp message with one button
        /// </summary>
        /// <param name="title"> Title text </param>
        /// <param name="body"> Body text </param>
        /// <param name="onApproveAction"> Action clicked approved </param>
        public void Show(string title, string body, Action onApproveAction = null)
        {
            _popUpPool.GetFreeElement().OpenWithOneButton(title, body, onApproveAction);
        }

        /// <summary>
        /// Show PopUp message with two button
        /// </summary>
        /// <param name="title"> Title text </param>
        /// <param name="body"> Body text </param>
        /// <param name="onApproveAction"> Action clicked approved </param>
        /// <param name="onCancelAction"> Action clicked canceled </param>
        public void Show(string title, string body, Action onApproveAction = null, Action onCancelAction = null)
        {
            _popUpPool.GetFreeElement().OpenWithTwoButton(title, body, onCancelAction, onApproveAction);
        }
    }
}