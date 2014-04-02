package is.jok.whattodo;

import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.view.Menu;
import android.webkit.JavascriptInterface;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.widget.Toast;

public class MainActivity extends Activity
{
	// TODO: KRAPP http://adndevblog.typepad.com/cloud_and_mobile/2013/08/writing-android-apps-with-html5-javascript.html
     WebAppInterface _interface;
    
     @Override
     protected void onCreate(Bundle savedInstanceState)
     {
           super.onCreate(savedInstanceState);
           setContentView(R.layout.activity_main);
          
           setTitle("KRAPP");
          
           WebView webView = (WebView) findViewById(R.id.webview);
           WebSettings webSettings = webView.getSettings();
           webSettings.setJavaScriptEnabled(true);
          
           _interface = new WebAppInterface(this);
          
           webView.addJavascriptInterface(
                     _interface,
                     "WebAppInterface");
          
           webView.loadUrl("file:///android_asset/Index.html");
     }
 
     @Override
     public boolean onCreateOptionsMenu(Menu menu)
     {
           getMenuInflater().inflate(R.menu.main, menu);
           return true;
     }
    
     public class WebAppInterface
     {
         Context _context;
 
         /** Instantiate the interface and set the context */
         WebAppInterface(Context context) {
         _context = context;
         }
 
         /** Show a toast from the web page */
         @JavascriptInterface
         public void showToast(String msg)
         {
             Toast.makeText(_context, msg, Toast.LENGTH_SHORT).show();
         }
     }
}