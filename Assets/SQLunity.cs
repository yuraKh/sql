using UnityEngine;
using System.Collections;

public class SQLunity : MonoBehaviour
{

	char c = ' ';
	WWW webclass;
	JSONObject j_son;
	string name;
	Vector3 pos;
	Quaternion qu;
	void Start ()
	{

	}

	void Update ()
	{
	
		/*if (Input.GetKeyDown (KeyCode.E)) {
			print ("start insert");
			c = 'e';
			WWWForm webform = new WWWForm ();
			webform.AddField ("name", name);
			webform.AddField ("posx", (int)pos.x);
			webform.AddField ("posy", (int)pos.y);
			webform.AddField ("posz", (int)pos.z);
			webform.AddField ("qx", (int)qu.x);
			webform.AddField ("qy", (int)qu.y);
			webform.AddField ("qz", (int)qu.z);
			webform.AddField ("qw", (int)qu.w);
			webclass = new WWW ("http://unityserver.8nio.com/setuser.php", webform);
		}*/
		if (Input.GetKeyDown (KeyCode.R)) {
			print ("start select");
			c = 'r';
			webclass = new WWW ("http://unityserver.8nio.com/getuser.php");
		}
		if (Input.GetKeyDown ("s")) {
			name = transform.name;
			pos = transform.position;
			qu = transform.rotation;
			print ("start up");
			c = 's';
			WWWForm webform = new WWWForm ();  
			webform.AddField ("name", name);
			webform.AddField ("posx", (int)pos.x);
			webform.AddField ("posy", (int)pos.y);
			webform.AddField ("posz", (int)pos.z);
			webform.AddField ("qx", (int)qu.x);
			webform.AddField ("qy", (int)qu.y);
			webform.AddField ("qz", (int)qu.z);
			webform.AddField ("qw", (int)qu.w);
			webclass = new WWW ("http://unityserver.8nio.com/upuser.php", webform);
			print (name);
		}
		
		
		if (webclass != null && webclass.isDone && c == 'e') {
			print ("finish insert " + webclass.text);
			webclass = null;
		} else if (webclass != null && webclass.isDone && c == 'r') {
			print ("finish select ");
			if (webclass.error == null) {
				j_son = new JSONObject (webclass.text);
				foreach (var json in j_son.list) {
					var data = json.ToDictionary ();
					GameObject.Find (data ["name"]).transform.position = new Vector3 (float.Parse (data ["posx"]), float.Parse (data ["posy"]), float.Parse (data ["posz"]));
					GameObject.Find (data ["name"]).transform.rotation = new Quaternion (float.Parse (data ["qx"]), float.Parse (data ["qy"]), float.Parse (data ["qz"]), float.Parse (data ["qw"]));
					print (data ["name"] + " " + data ["posx"] + " " + data ["posy"] + " " + data ["posz"] + " " + data ["qx"] + " " + data ["qy"] + " " + data ["qz"] + "" + data ["qw"]);
				}
			}
			webclass = null;
		} else if (webclass != null && webclass.isDone && c == 's') {
			print ("finish up " + webclass.text);
			webclass = null;
		}
	}
}
