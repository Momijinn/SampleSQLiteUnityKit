using UnityEngine;
using System.Collections;

public class Database : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Insert
		SqliteDatabase sqlDB = new SqliteDatabase("config.db");
		string query = "insert into user values(1, 'hoge', 20, 'america')";
		sqlDB.ExecuteNonQuery(query);


		// Select
		string selectQuery = "select * from user";
		DataTable dataTable = sqlDB.ExecuteQuery(selectQuery);

		string name = "";
		foreach(DataRow dr in dataTable.Rows){
			name = (string)dr["name"];
			Debug.Log ("name:" + name);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}