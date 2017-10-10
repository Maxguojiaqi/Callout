package md5a04c937ad71459bf91a0582d16723e93;


public class GeoViewRenderer
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Esri.ArcGISRuntime.Xamarin.Forms.GeoViewRenderer, Esri.ArcGISRuntime.Xamarin.Forms, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", GeoViewRenderer.class, __md_methods);
	}


	public GeoViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == GeoViewRenderer.class)
			mono.android.TypeManager.Activate ("Esri.ArcGISRuntime.Xamarin.Forms.GeoViewRenderer, Esri.ArcGISRuntime.Xamarin.Forms, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public GeoViewRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == GeoViewRenderer.class)
			mono.android.TypeManager.Activate ("Esri.ArcGISRuntime.Xamarin.Forms.GeoViewRenderer, Esri.ArcGISRuntime.Xamarin.Forms, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public GeoViewRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == GeoViewRenderer.class)
			mono.android.TypeManager.Activate ("Esri.ArcGISRuntime.Xamarin.Forms.GeoViewRenderer, Esri.ArcGISRuntime.Xamarin.Forms, Version=100.1.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad86", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
