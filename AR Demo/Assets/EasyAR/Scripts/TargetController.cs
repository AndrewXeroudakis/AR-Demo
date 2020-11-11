//================================================================================================================================
//
//  Copyright (c) 2015-2020 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
//  EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
//  and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//================================================================================================================================

using System;
using UnityEngine;
using UnityEngine.Events;

namespace easyar
{
    public abstract class TargetController : MonoBehaviour
    {
        public ActiveControlStrategy ActiveControl;
        public bool HorizontalFlip;

        private bool firstFound;

        public UnityEvent TargetFound;
        public UnityEvent TargetLost;

        public enum ActiveControlStrategy
        {
            HideWhenNotTracking,
            HideBeforeFirstFound,
            None,
        }

        public bool IsTracked { get; private set; }
        public bool IsLoaded { get; protected set; }

        protected virtual void Start()
        {
            if (!IsTracked && (ActiveControl == ActiveControlStrategy.HideWhenNotTracking || ActiveControl == ActiveControlStrategy.HideBeforeFirstFound))
            {
                ActivateRenderers(false);
            }
        }

        void ActivateRenderers(bool _active)
        {
            foreach (Renderer renderer in GetComponentsInChildren<Renderer>(true))
            {
                renderer.enabled = _active;
            }
        }

        internal void OnTracking(bool status)
        {
            if (IsTracked != status)
            {
                if (status)
                {
                    if (ActiveControl == ActiveControlStrategy.HideWhenNotTracking || (ActiveControl == ActiveControlStrategy.HideBeforeFirstFound && !firstFound))
                    {
                        ActivateRenderers(true);
                    }
                    firstFound = true;
                    if (TargetFound != null)
                    {
                        TargetFound.Invoke();
                    }
                }
                else
                {
                    if (ActiveControl == ActiveControlStrategy.HideWhenNotTracking)
                    {
                        ActivateRenderers(false);
                    }
                    if (TargetLost != null)
                    {
                        TargetLost.Invoke();
                    }
                }
                IsTracked = status;
            }
            if (IsTracked)
            {
                OnTracking();
            }
        }

        protected abstract void OnTracking();
    }
}
