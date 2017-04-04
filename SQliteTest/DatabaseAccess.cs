using System;
using System.Collections.Generic;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System.IO;

namespace SQliteTest
{
	public class DatabaseAccess
	{
		//string dbPath;
		SQLiteAsyncConnection db;
		public DatabaseAccess(string path, ISQLitePlatform sqlitePlatform)
		{
			//dbPath = path;
			var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(sqlitePlatform, new SQLiteConnectionString(path, storeDateTimeAsTicks: false)));

			db = new SQLiteAsyncConnection(connectionFactory);
		}
		public List<TableInfo> schemaQuery(string table)
		{
			var output = "";
			output += "\nSchema query example: ";


			var query = "pragma table_info('"+table+"')";

			var existingCols = db.QueryAsync<TableInfo>(query).Result;

			//foreach (var s in existingCols)
			//{
			//	output += "\n" + s.name + " " + s.type;
			//}
			////Console.WriteLine(output);
			////output += query;

			return existingCols;
		}

		public List<String> tableQueries()
		{
			var output = "";
			output += "Table query example: ";
			List<string> st = new List<string>();

			var query = "SELECT name FROM sqlite_master WHERE type=\"table\"";
			var t = db.QueryAsync<MasterTableInfo>(query);

			var tables = t.Result;
			foreach (var s in tables)
			{
				st.Add(s.name);
			}


			return st;
		}

	}

}
