using Entity.Models;
using Entity.Models.BaseEntityModel;
using Repository.DbConnection;
using Repository.Repository.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericDbRepository : IDbRepository<IEntity>
    {

        public void Close()
        {
            DbConnectionFactory.Instance.getConnection().Close();   
        }
        
        public void Commit()
        {
            DbConnectionFactory.Instance.getConnection().Commit();
        }
        public void Rollback()
        {
            DbConnectionFactory.Instance.getConnection().Rollback();
        }
        public void Delete(IEntity entity, string criteria)
        {
            string query = $"delete from {entity.TableName} where {criteria}";
            SqlCommand cmd = DbConnectionFactory.Instance.getConnection().CreateCommand(query);
            Debug.WriteLine(query);
            int x = cmd.ExecuteNonQuery();
            Console.WriteLine("Affected rows delete: " + x);
        }


        public void Insert(IEntity entity)
        {
			string query = $" INSERT INTO {entity.TableName} ";

			if (entity.PrimaryKey.Length == 1)
				query += $" OUTPUT INSERTED.{entity.PrimaryKey[0]}";

			query += $" VALUES ({entity.InsertValues})";

			SqlCommand cmd = DbConnectionFactory.Instance.getConnection()
                .CreateCommand(query);
			Debug.WriteLine("Generated SQL command: " + query);
			foreach (var parameter in entity.Parameters)
			{
				cmd.Parameters.Add(parameter);
			}
			if (entity.PrimaryKey.Length == 1)
			{
				Debug.WriteLine($"Inserted row with primary key value:" +
                    $" {entity.PrimaryKey[0]}");

				int primaryValue = (int)cmd.ExecuteScalar();
				entity.GetType().GetProperty(entity.PrimaryKey[0])
                    .SetValue(entity, primaryValue);
				Debug.WriteLine($"Inserted row with primary key value:" +
                    $" {primaryValue}");
			}
			else
			{
				int x = cmd.ExecuteNonQuery();
				Console.WriteLine("Affected rows insert: " + x);
			}

		}
        
        public List<IEntity> Select(IEntity entity)
        {
			string query = $"select {entity.SelectedCollumns} from {entity.TableName} {entity.Alijas} {entity.Join} ";

            SqlCommand cmd = DbConnectionFactory.Instance.getConnection().CreateCommand(query);
			Debug.WriteLine("Generated SQL command: " + query);
			SqlDataReader reader = cmd.ExecuteReader();
			List<IEntity> list = entity.GetListOfObjects(reader);
                
			reader.Close();

            return list;
		}
        public List<IEntity> Select(IEntity entity, string criteria)
        {
            string query = $"select {entity.SelectedCollumns} from {entity.TableName}{entity.Alijas}";
            query += $" {entity.Join}";
			query += $" where {criteria} ";
			

            SqlCommand cmd = DbConnectionFactory.Instance.getConnection().CreateCommand(query);
            Debug.WriteLine("Generated SQL command: " + query);
            SqlDataReader reader = cmd.ExecuteReader();
            List<IEntity> list = entity.GetListOfObjects(reader);
            
            reader.Close();
            return list;


		}
        public void Update(IEntity entity, string criteria)
        {
            string query = $"update {entity.TableName}" +
                $" set {entity.UpdateValues}" +
                $" where {criteria}";

            SqlCommand cmd = DbConnectionFactory.Instance.getConnection().CreateCommand(query);
            foreach (var parameter in entity.Parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            Debug.WriteLine("Generated SQL command: " + query);
            int x = cmd.ExecuteNonQuery();

            Console.WriteLine("Affected rows update: " + x);
        }
    }
}
