# SampleSQLiteUnityKit
Unityにおけるデータベースを操作するためのプログラム  
SQLiteUnityKitを使用しています  

# 動作環境
* Unity 5.4.1.f1
* SQLite

# 導入方法
1. データベースを作成するために、SQLiteのツールをダウンロードする  
   [ここ](https://sqlite.org/2016/sqlite-tools-win32-x86-3150200.zip)  

   展開し、展開したディレクトリでcmdを開く  
   以下のコマンドを打つ(データベースを作成している)
   ```
   C:\sqlite-tools-win32-x86-3150200> sqlite3 config.db
   sqlite> create table user(id integer, name text, old integer, address text);
   sqlite> .exit
   ```

2. SQLiteUnityKitをクローンまたはダウンロードする  
   [ここ](https://github.com/Busta117/SQLiteUnityKit)

3. SQLiteのバイナリをダウンロードする  
   windows32bitの場合：<https://sqlite.org/2016/sqlite-dll-win32-x86-3150200.zip>  
   windows64bitの場合：<https://sqlite.org/2016/sqlite-dll-win64-x64-3150200.zip>  

4. Unityを開く

5. Assetsに各種ダウンロードしたファイル以下のように入れる  
   Assets\Plugin\Android\libsqlite3.so  
   (32bitの場合)Assets\Plugin\x86\sqlite3.dll  
   (64bitの場合)Assets\Plugin\x64\sqlite3.dll  
   Assets\Script\DataTable.cs  
   Assets\Script\SqliteDatabase.cs  

6. データベースを操作するためのスクリプトファイルを作成する  
   ここでは**Database.cs**とする  
   ```csharp, c#:Database.cs
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
   ```

7. GameObjectを作成し、作成したスクリプトをAddComponentする

# 参考文献
1. <http://ameblo.jp/mk-soundtrack/entry-12086698310.html>
2. <http://qiita.com/hiroyuki7/items/5335e391c9ed397aee50>
3. <http://pro132007.wp.xdomain.jp/unitysqlite%E3%82%92%E4%BD%BF%E3%81%86-%E3%81%9D%E3%81%AE1/>