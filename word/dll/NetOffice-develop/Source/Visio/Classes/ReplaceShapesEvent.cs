﻿using System;
using NetRuntimeSystem = System;
using System.ComponentModel;
using NetOffice;
using NetOffice.Misc;

namespace NetOffice.VisioApi
{

	#region Delegates

	#pragma warning disable
	#pragma warning restore

	#endregion

	///<summary>
	/// CoClass ReplaceShapesEvent 
	/// SupportByVersion Visio, 15, 16
	///</summary>
	[SupportByVersionAttribute("Visio", 15, 16)]
	[EntityTypeAttribute(EntityType.IsCoClass)]
	public class ReplaceShapesEvent : IVReplaceShapesEvent
	{
		#pragma warning disable
		#region Fields
		
		private NetRuntimeSystem.Runtime.InteropServices.ComTypes.IConnectionPoint _connectPoint;
		private string _activeSinkId;
		private NetRuntimeSystem.Type _thisType;
	
		#endregion

		#region Type Information

        /// <summary>
        /// Instance Type
        /// </summary>
        public override Type InstanceType
        {
            get
            {
                return LateBindingApiWrapperType;
            }
        }

        private static Type _type;
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public static Type LateBindingApiWrapperType
        {
            get
            {
                if (null == _type)
                    _type = typeof(ReplaceShapesEvent);
                return _type;
            }
        }
        
        #endregion
        		
		#region Construction

		///<param name="factory">current used factory core</param>
		///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
		public ReplaceShapesEvent(Core factory, ICOMObject parentObject, object comProxy) : base(factory, parentObject, comProxy)
		{
			
		}

        ///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
		public ReplaceShapesEvent(ICOMObject parentObject, object comProxy) : base(parentObject, comProxy)
		{
			
		}

		///<param name="factory">current used factory core</param>
		///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ReplaceShapesEvent(Core factory, ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(factory, parentObject, comProxy, comProxyType)
		{
			
		}

		///<param name="parentObject">object there has created the proxy</param>
        ///<param name="comProxy">inner wrapped COM proxy</param>
        ///<param name="comProxyType">Type of inner wrapped COM proxy"</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ReplaceShapesEvent(ICOMObject parentObject, object comProxy, NetRuntimeSystem.Type comProxyType) : base(parentObject, comProxy, comProxyType)
		{
			
		}
		
		///<param name="replacedObject">object to replaced. replacedObject are not usable after this action</param>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public ReplaceShapesEvent(ICOMObject replacedObject) : base(replacedObject)
		{
			
		}
		
		///<summary>
        /// Creates a new instance of ReplaceShapesEvent 
        ///</summary>		
		public ReplaceShapesEvent():base("Visio.ReplaceShapesEvent")
		{
			
		}
		
		///<summary>
        /// Creates a new instance of ReplaceShapesEvent
        ///</summary>
        ///<param name="progId">registered ProgID</param>
		public ReplaceShapesEvent(string progId):base(progId)
		{
			
		}

		#endregion

		#region Static CoClass Methods

		/// <summary>
        /// Returns all running Visio.ReplaceShapesEvent objects from the environment/system
        /// </summary>
        /// <returns>an Visio.ReplaceShapesEvent array</returns>
		public static NetOffice.VisioApi.ReplaceShapesEvent[] GetActiveInstances()
		{		
			IDisposableEnumeration proxyList = NetOffice.ProxyService.GetActiveInstances("Visio","ReplaceShapesEvent");
			NetRuntimeSystem.Collections.Generic.List<NetOffice.VisioApi.ReplaceShapesEvent> resultList = new NetRuntimeSystem.Collections.Generic.List<NetOffice.VisioApi.ReplaceShapesEvent>();
			foreach(object proxy in proxyList)
				resultList.Add( new NetOffice.VisioApi.ReplaceShapesEvent(null, proxy) );
			return resultList.ToArray();
		}

		/// <summary>
        /// Returns a running Visio.ReplaceShapesEvent object from the environment/system.
        /// </summary>
        /// <returns>an Visio.ReplaceShapesEvent object or null</returns>
		public static NetOffice.VisioApi.ReplaceShapesEvent GetActiveInstance()
		{
			object proxy  = NetOffice.ProxyService.GetActiveInstance("Visio","ReplaceShapesEvent", false);
			if(null != proxy)
				return new NetOffice.VisioApi.ReplaceShapesEvent(null, proxy);
			else
				return null;
		}

		/// <summary>
        /// Returns a running Visio.ReplaceShapesEvent object from the environment/system. 
        /// </summary>
	    /// <param name="throwOnError">throw an exception if no object was found</param>
        /// <returns>an Visio.ReplaceShapesEvent object or null</returns>
		public static NetOffice.VisioApi.ReplaceShapesEvent GetActiveInstance(bool throwOnError)
		{
			object proxy  = NetOffice.ProxyService.GetActiveInstance("Visio","ReplaceShapesEvent", throwOnError);
			if(null != proxy)
				return new NetOffice.VisioApi.ReplaceShapesEvent(null, proxy);
			else
				return null;
		}
		#endregion

		#region Events

		#endregion
       
	    #region IEventBinding Member
        
		/// <summary>
        /// Creates active sink helper
        /// </summary>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public void CreateEventBridge()
        {
			if(false == Factory.Settings.EnableEvents)
				return;
	
			if (null != _connectPoint)
				return;
	
            if (null == _activeSinkId)
				_activeSinkId = SinkHelper.GetConnectionPoint(this, ref _connectPoint, null);

 
        }

        /// <summary>
        /// The instance use currently an event listener 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool EventBridgeInitialized
        {
            get 
            {
                return (null != _connectPoint);
            }
        }

        /// <summary>
        ///  The instance has currently one or more event recipients 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public bool HasEventRecipients()       
        {
			if(null == _thisType)
				_thisType = this.GetType();
					
			foreach (NetRuntimeSystem.Reflection.EventInfo item in _thisType.GetEvents())
			{
				MulticastDelegate eventDelegate = (MulticastDelegate) _thisType.GetType().GetField(item.Name, 
																			NetRuntimeSystem.Reflection.BindingFlags.NonPublic |
																			NetRuntimeSystem.Reflection.BindingFlags.Instance).GetValue(this);
					
				if( (null != eventDelegate) && (eventDelegate.GetInvocationList().Length > 0) )
					return false;
			}
				
			return false;
        }
        
        /// <summary>
        /// Target methods from its actual event recipients
        /// </summary>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public Delegate[] GetEventRecipients(string eventName)
        {
			if(null == _thisType)
				_thisType = this.GetType();
             
            MulticastDelegate eventDelegate = (MulticastDelegate)_thisType.GetField(
                                                "_" + eventName + "Event",
                                                NetRuntimeSystem.Reflection.BindingFlags.Instance |
                                                NetRuntimeSystem.Reflection.BindingFlags.NonPublic).GetValue(this);

            if (null != eventDelegate)
            {
                Delegate[] delegates = eventDelegate.GetInvocationList();
                return delegates;
            }
            else
                return new Delegate[0];
        }
       
        /// <summary>
        /// Returns the current count of event recipients
        /// </summary>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int GetCountOfEventRecipients(string eventName)
        {
			if(null == _thisType)
				_thisType = this.GetType();
             
            MulticastDelegate eventDelegate = (MulticastDelegate)_thisType.GetField(
                                                "_" + eventName + "Event",
                                                NetRuntimeSystem.Reflection.BindingFlags.Instance |
                                                NetRuntimeSystem.Reflection.BindingFlags.NonPublic).GetValue(this);

            if (null != eventDelegate)
            {
                Delegate[] delegates = eventDelegate.GetInvocationList();
                return delegates.Length;
            }
            else
                return 0;
           }
        
        /// <summary>
        /// Raise an instance event
        /// </summary>
        /// <param name="eventName">name of the event without 'Event' at the end</param>
        /// <param name="paramsArray">custom arguments for the event</param>
        /// <returns>count of called event recipients</returns>
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public int RaiseCustomEvent(string eventName, ref object[] paramsArray)
		{
			if(null == _thisType)
				_thisType = this.GetType();
             
            MulticastDelegate eventDelegate = (MulticastDelegate)_thisType.GetField(
                                                "_" + eventName + "Event",
                                                NetRuntimeSystem.Reflection.BindingFlags.Instance |
                                                NetRuntimeSystem.Reflection.BindingFlags.NonPublic).GetValue(this);

            if (null != eventDelegate)
            {
                Delegate[] delegates = eventDelegate.GetInvocationList();
                foreach (var item in delegates)
                {
                    try
                    {
                        item.Method.Invoke(item.Target, paramsArray);
                    }
                    catch (NetRuntimeSystem.Exception exception)
                    {
                        Factory.Console.WriteException(exception);
                    }
                }
                return delegates.Length;
            }
            else
                return 0;
		}

        /// <summary>
        /// Stop listening events for the instance
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public void DisposeEventBridge()
        {

			_connectPoint = null;
		}
        
        #endregion

		#pragma warning restore
	}
}