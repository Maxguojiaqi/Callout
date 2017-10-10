package md5d1b56e5099a02cfcebb7bf5431e73a8e;


public abstract class UserInteractionHandler
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Esri.ArcGISRuntime.UI.UserInteractionHandler, Esri.ArcGISRuntime, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", UserInteractionHandler.class, __md_methods);
	}


	public UserInteractionHandler () throws java.lang.Throwable
	{
		super ();
		if (getClass () == UserInteractionHandler.class)
			mono.android.TypeManager.Activate ("Esri.ArcGISRuntime.UI.UserInteractionHandler, Esri.ArcGISRuntime, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", "", this, new java.lang.Object[] {  });
	}

	public UserInteractionHandler (md57e9adfe234148a34f9aeb4cfea507483.GeoView p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == UserInteractionHandler.class)
			mono.android.TypeManager.Activate ("Esri.ArcGISRuntime.UI.UserInteractionHandler, Esri.ArcGISRuntime, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", "Esri.ArcGISRuntime.UI.Controls.GeoView, Esri.ArcGISRuntime, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
