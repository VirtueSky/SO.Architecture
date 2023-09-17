using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using VirtueSky.Core;
using VirtueSky.Variables;

namespace VirtueSky.Events
{
    public class BaseEventListener<TEvent, TResponse> : BaseMono, IEventListener
        where TEvent : BaseEvent
        where TResponse : UnityEvent
    {
        [SerializeField] private BindingListener bindingListener;
        [SerializeField] private List<EventResponseData> listEventResponseDatas = new List<EventResponseData>();
        private readonly Dictionary<BaseEvent, UnityEvent> _dictionary = new Dictionary<BaseEvent, UnityEvent>();

        [Serializable]
        public class EventResponseData
        {
            public TEvent @event;
            public TResponse response;
        }

        public override void ListenEvents()
        {
            base.ListenEvents();
            foreach (var t in listEventResponseDatas)
            {
                t.@event.AddListener(this);
                _dictionary.TryAdd(t.@event, t.response);
            }
        }

        public override void StopListenEvents()
        {
            base.StopListenEvents();
            foreach (var t in listEventResponseDatas)
            {
                t.@event.RemoveListener(this);
                if (_dictionary.ContainsKey(t.@event)) _dictionary.Remove(t.@event);
            }
        }

        public virtual void OnEventRaised(BaseEvent eventRaise)
        {
            _dictionary[eventRaise].Invoke();
        }

        public override void DoDisable()
        {
            base.DoDisable();
            if (bindingListener == BindingListener.UNTIL_DISABLE)
            {
                StopListenEvents();
            }
        }

        public override void DoDestroy()
        {
            base.DoDestroy();
            if (bindingListener == BindingListener.UNTIL_DESTROY)
            {
                StopListenEvents();
            }
        }
    }

    public class BaseEventListener<TType, TEvent, TResponse> : BaseMono, IEventListener<TType>
        where TEvent : BaseEvent<TType>
        where TResponse : UnityEvent<TType>
    {
        [SerializeField] private BindingListener bindingListener;

        [SerializeField] protected List<EventResponseData> listEventResponseDatas = new List<EventResponseData>();

        protected readonly Dictionary<BaseEvent<TType>, UnityEvent<TType>> _dictionary =
            new Dictionary<BaseEvent<TType>, UnityEvent<TType>>();

        [Serializable]
        public class EventResponseData
        {
            public TEvent @event;
            public TResponse response;
        }

        public override void ListenEvents()
        {
            base.ListenEvents();
            foreach (var t in listEventResponseDatas)
            {
                t.@event.AddListener(this);
                _dictionary.TryAdd(t.@event, t.response);
            }
        }

        public override void StopListenEvents()
        {
            base.StopListenEvents();
            foreach (var t in listEventResponseDatas)
            {
                t.@event.RemoveListener(this);
                if (_dictionary.ContainsKey(t.@event)) _dictionary.Remove(t.@event);
            }
        }

        public virtual void OnEventRaised(BaseEvent<TType> eventRaise, TType value)
        {
            _dictionary[eventRaise].Invoke(value);
        }

        public override void DoDisable()
        {
            base.DoDisable();
            if (bindingListener == BindingListener.UNTIL_DISABLE)
            {
                StopListenEvents();
            }
        }

        public override void DoDestroy()
        {
            base.DoDestroy();
            if (bindingListener == BindingListener.UNTIL_DESTROY)
            {
                StopListenEvents();
            }
        }
    }
}

public enum BindingListener
{
    UNTIL_DISABLE,
    UNTIL_DESTROY
}