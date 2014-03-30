using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;


public class Menu : MonoBehaviour 
{

	private const int X_WIDTH = 80;
	private const int Y_HEIGHT = 20;

    enum abcde
    {
        oks=0,
        ngs=1
    };

	#region practice 1_1
	class Class1_1
	{
		public string Name{ get; set;}
	}
	#endregion

	#region practice 1_4
	static class Class1_4
	{
		static internal void SayHello(string name = null,int age = -1)
		{
			if (age >= 0) 
			{
				UnityEngine.Debug.Log ("age=" + age.ToString());
			}

			if(name != null)
			{
				UnityEngine.Debug.Log ("name=" + name);
			}
		}
	}
	#endregion

	#region practice 1_10
	static class Class1_10
	{
		static internal bool ValOver(int checkval)
		{
			return checkval > 100;
		}
	}
	#endregion

    
    #region practice 1_12
    class Class1_12
    {
       public string A,B,C;
    }
    #endregion
    
    #region practice 1_12
    void Class1_14(Action goAction)
    {
        UnityEngine.Debug.Log(" Door Open");
        goAction();
        UnityEngine.Debug.Log(" Door Close");
    }
    #endregion

    class A
    {
        public void MethodDynamic()
        {
            UnityEngine.Debug.Log("dynamic");
        }
    }


    class Class_1_18A
    {
        private static string three;
        public static void Three()
        {
            Debug.Log(three);
        }

        static Class_1_18A()
        {
            Debug.Log("two");
            three = "three";

        }
    }

    class Sample_2_1 : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for(int i=0; i<10; i++)
            {
                Debug.Log("before int GetEnumerator");
                yield return i;
                Debug.Log("after int GetEnumerator");
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }


    /// <summary>
    /// UI
    /// </summary>


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (10, 10, X_WIDTH, Y_HEIGHT), "1_1")) 
		{
			Debug.Log("1_1");

			Class1_1 b = new Class1_1(){Name = "abcde"};

			Debug.Log("Name=" + b.Name);
		}

		if (GUI.Button (new Rect (100, 10, X_WIDTH, Y_HEIGHT), "1_4")) 
		{
			Debug.Log("1_4");
			Class1_4.SayHello("taro",17);
			Class1_4.SayHello("hanako");
			Class1_4.SayHello();
		}

		if (GUI.Button (new Rect (190, 10, X_WIDTH, Y_HEIGHT), "1_5")) 
		{
			Debug.Log("1_5");
			string[] a ={"ichiro","jiro","saburo"};
			foreach(var n in a.Select((s,i) => new{i,s}))
	        {
				Debug.Log("No=" + n.i + " Name=" + n.s );
			}
		}

		
		if (GUI.Button (new Rect (280, 10, X_WIDTH, Y_HEIGHT), "1_6")) 
		{
			Debug.Log("1_6");
			string[] a ={null,"ichiro","jiro",null,"saburo"};
			foreach(var n in a.Where(c => c != null))
			{
				Debug.Log("Name=" + n);
			}
		}
		
		
		if (GUI.Button (new Rect (370, 10, X_WIDTH, Y_HEIGHT), "1_7")) 
		{
			Debug.Log("1_7");

			string src = "12345";
			int result;
			Debug.Log((int.TryParse(src, out result) ? result : -1).ToString());

			src = "abcde";
			Debug.Log((int.TryParse(src, out result) ? result : -1).ToString());

		}

		
		if (GUI.Button (new Rect (10, 40, X_WIDTH, Y_HEIGHT), "1_8")) 
		{
			Debug.Log("1_8");
			
			string src = "12345";
			int result;
			int.TryParse(src, out result);

			Debug.Log(result.ToString());

			src = "abcde";
			int.TryParse(src, out result);
			
			Debug.Log(result.ToString());

		}

		if (GUI.Button (new Rect (100, 40, X_WIDTH, Y_HEIGHT), "1_10")) 
		{

			Debug.Log("1_10");
			Debug.Log( Class1_10.ValOver(101));
			Debug.Log( Class1_10.ValOver(100));

		}

		if (GUI.Button (new Rect (190, 40, X_WIDTH, Y_HEIGHT), "1_11")) 
		{
			
			Debug.Log("1_11");
			string abc = "We are the World";
			Debug.Log(abc ?? "(null)");
            abc = null;
            Debug.Log(abc ?? "(null)");

		}

        if (GUI.Button (new Rect (280, 40, X_WIDTH, Y_HEIGHT), "1_12")) 
        {
           
            var sample = new Class1_12()
            {
                A = "",
                B = "This is B",
                C = "This is C"
            };

            Debug.Log("1_12 " + sample.A + " " + sample.B + " " + sample.C );

        }

        
        if (GUI.Button (new Rect (370, 40, X_WIDTH, Y_HEIGHT), "1_13")) 
        {
            Action DebugLogs = () => {};
            DebugLogs = () => Debug.Log("Action Go");
            DebugLogs();
        }
        
        if (GUI.Button (new Rect (10, 70, X_WIDTH, Y_HEIGHT), "1_14")) 
        {
            Class1_14(() => Debug.Log("welcome"));
            Class1_14(() => Debug.Log("Hello"));

        }


        if (GUI.Button (new Rect (100, 70, X_WIDTH, Y_HEIGHT), "1_15")) 
        {
            int[] ar = {1,0};
            var q = from n in ar select n;

            if(q.Any((c) => c <= 0))
            {
                Debug.Log("minus");
            }

            using(var writer = File.CreateText("aaaa"))
            {
                foreach( var n in q)
                {
                    writer.WriteLine(n);
                }
            }
        }


        if (GUI.Button (new Rect (190, 70, X_WIDTH, Y_HEIGHT), "1_16")) 
        {
//            dynamic t = new A();
//            t.MethodDynamic();
//            t.Class_1_16();
        }

        if (GUI.Button (new Rect (280, 70, X_WIDTH, Y_HEIGHT), "1_18")) 
        {
            Debug.Log("one");
            Class_1_18A.Three();
            //            t.MethodDynamic();
            //            t.Class_1_16();
        }

        
        if (GUI.Button (new Rect (10, 100, X_WIDTH, Y_HEIGHT), "2_1")) 
        {
            foreach(var n in new Sample_2_1())
            {
                Debug.Log(n.ToString());
            }
        }


        if (GUI.Button (new Rect (100, 100, X_WIDTH, Y_HEIGHT), "2_2")) 
        {
            foreach(var n in Enumerable.Range(0,10))
            {
                Debug.Log("renban = " + n.ToString());
            }
        }
        
        if (GUI.Button (new Rect (190, 100, X_WIDTH, Y_HEIGHT), "2_3_1")) 
        {
            var s = Enumerable.Range(1,7);
            var q = from n in s from m in s select string.Format("{0,7}{1}",Math.Pow(n,m),m == 7 ? "¥n":"");

            foreach( var n in q) 
            {
                Debug.Log(n.ToString());
            }
        }

        
        if (GUI.Button (new Rect (280, 100, X_WIDTH, Y_HEIGHT), "2_3_2")) 
        {
            var s = Enumerable.Range(1,7);
            var q = s.SelectMany(c=>s,(n,m) =>string.Format("{0,7}",Math.Pow(n,m), m == 7 ? "¥n" :""));

            foreach( var n in q) Debug.Log(n.ToString());
        }
        


    }
}
