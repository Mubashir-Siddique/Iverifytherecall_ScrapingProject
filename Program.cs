using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Iverifytherecall_Scraping
{
    class Program
    {
        static void Main(string[] args)
        {
            string webAddress = "http://iverifytherecall.com/Search.aspx";

            string text = "geeksforgeeks";
            string url = "https://google.com/search?q=" + text;

            for (int i = 0; i < 200; i++)
            {
                string response = Get(url); 
            }


        }

        static String Get(String url)
        {
            String resul = String.Empty;
            try
            {
                HttpWebRequest _WebRequest = (HttpWebRequest)WebRequest.Create(url);

                //WebProxy myproxy = new WebProxy("127.0.0.1:8888", false);
                //myproxy.BypassProxyOnLocal = false;
                //_WebRequest.Proxy = myproxy;
                _WebRequest.Method = "GET";

                _WebRequest.Credentials = CredentialCache.DefaultCredentials;

                //GetResponce
                HttpWebResponse responce = (HttpWebResponse)_WebRequest.GetResponse();
                Console.WriteLine(responce.StatusDescription);

                if (responce.StatusDescription == "OK")
                {
                    //Read Responce Stream
                    using (Stream dataStream = responce.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            resul = reader.ReadToEnd();
                            //Console.WriteLine(responcefromServer);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
            return resul;
        }

    }
}
