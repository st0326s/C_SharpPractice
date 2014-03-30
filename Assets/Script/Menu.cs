using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class Menu : MonoBehaviour 
{

	private const int X_WIDTH = 80;
	private const int Y_HEIGHT = 20;

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
            
            Debug.Log("1_12");

        }

    }
}
