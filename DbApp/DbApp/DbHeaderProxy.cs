using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DbApp
{
    /// <summary>
    /// 
    /// </summary>
    public class DbHeaderProxy
    {
        /// <summary>
        /// Connection source
        /// </summary>
        public string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\University\Kate\ApplicationDb\DbApp\DbApp\DatabaseUsers.mdf;Integrated Security=True";

        /// <summary>
        /// Sql connection
        /// </summary>
        public SqlConnection sqlConnection;

        /// <summary>
        /// Sql Builder
        /// </summary>
        public SqlCommandBuilder sqlBuilder;

        /// <summary>
        /// Sql Data Adapter
        /// </summary>
        public SqlDataAdapter adapter;

        /// <summary>
        /// Header collection
        /// </summary>
        public List<string> Header;

        /// <summary>
        /// Update column(true\false)
        /// </summary>
        public bool updateColumns;

        /// <summary>
        ///Update Headers(true\false)
        /// </summary>
        public bool updateHeaders;

        /// <summary>
        /// Update data set(true\false)
        /// </summary>
        public DataSet updateDataSet;

        /// <summary>
        /// Counter to create new column
        /// </summary>
        public int counter = 1;

        /// <summary>
        /// Column width
        /// </summary>
        public int size = 85;

        /// <summary>
        /// Initialize <see cref="DbHeaderProxy"/>
        /// </summary>
        public DbHeaderProxy()
        {
            Header = new List<string>();
            updateDataSet = new DataSet();
            sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Workers", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(updateDataSet, "Workers");
            sqlBuilder.GetDeleteCommand();
            sqlBuilder.GetInsertCommand();
            sqlBuilder.GetUpdateCommand();
        }

        /// <summary>
        /// Add headers to Header collection
        /// </summary>
        /// <param name="header"></param>
        public virtual void AddToList(string header)
        {
            Header.Add(header);
        }
    }
}
