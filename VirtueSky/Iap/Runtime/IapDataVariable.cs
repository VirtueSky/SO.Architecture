﻿#if VIRTUESKY_IAP
using System;
using UnityEngine;
using UnityEngine.Purchasing;
using VirtueSky.Inspector;

namespace VirtueSky.Iap
{
    [Serializable]
    [EditorIcon("scriptable_iap")]
    public class IapDataVariable : ScriptableObject
    {
        [ReadOnly] public string id;
        [ReadOnly] public ProductType productType;

        [Space] public float price;
        [SerializeField] private IapPurchaseSuccess onPurchaseSuccess;
        [SerializeField] private IapPurchaseFailed onPurchaseFailed;
        internal IapPurchaseSuccess OnPurchaseSuccess => onPurchaseSuccess;
        internal IapPurchaseFailed OnPurchaseFailed => onPurchaseFailed;

        [NonSerialized] public Action purchaseSuccessCallback;
        [NonSerialized] public Action<string> purchaseFailedCallback;

        private IapManager iapManager;

        internal void InitIapManager(IapManager _iapManager)
        {
            iapManager = _iapManager;
        }

        public Product GetProduct()
        {
            if (iapManager == null) return null;
            return iapManager.GetProduct(this);
        }

        public SubscriptionInfo GetSubscriptionInfo()
        {
            if (iapManager == null) return null;
            return iapManager.GetSubscriptionInfo(this);
        }

        public void Purchase()
        {
            iapManager.PurchaseProduct(this);
        }

        public bool IsPurchased()
        {
            return iapManager.IsPurchasedProduct(this);
        }
    }
}
#endif