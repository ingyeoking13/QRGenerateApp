using System;
using System.Collections.Generic;
using System.Reflection;

namespace Kmong_Simple_LoginPage.Infrastructure
{
    public class EventAggregator
    {
        private Dictionary<Type, EventBase> eventDictionary { get; set; } = new Dictionary<Type, EventBase>();
        public TEventBase GetEvent<TEventBase>() where  TEventBase : EventBase, new ()
        {
            if ( eventDictionary.ContainsKey(typeof(TEventBase)))
                return (TEventBase)eventDictionary[typeof(TEventBase)];
            else
            {
                eventDictionary[typeof(TEventBase)] = new TEventBase();
                return (TEventBase)eventDictionary[typeof(TEventBase)];
            }
        }
    }
    public class EventBase
    {
        List<WeakEvent> weakEvents { get; set; } = new List<WeakEvent>();
        public void Publish()
        {
            for(int i = weakEvents.Count-1; i>=0; i--)
            {
                var res = weakEvents[i].CreateMethod();
                if (res == null)
                {
                    weakEvents.RemoveAt(i);
                    continue;
                }
                res.Invoke();
            }
        }

        public void Subscribe(Action _action)
        {
            weakEvents.Add(new WeakEvent(_action));
        }
    }

    public class WeakEvent
    {
        public WeakReference weakReference { get; }
        public MethodInfo methodInfo { get; } 
        public Type delegateType { get; }

        public WeakEvent(Delegate _delegate)
        {
            weakReference = new WeakReference( _delegate.Target);
            methodInfo = _delegate.GetMethodInfo();
            delegateType = _delegate.GetType();
        }

        public Action CreateMethod()
        {
            if (methodInfo.IsStatic) return (Action)methodInfo.CreateDelegate(delegateType, null);
            if (weakReference.Target == null) return null;
            return (Action)methodInfo.CreateDelegate(delegateType, weakReference.Target);
        }
    }
}
