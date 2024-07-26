using System.Data;
using System.Reflection;


namespace ConnectionSql.Repositories
{
    public interface IDataTableToBulk
    {
        DataTable MakeTable<T>(T record) where T : class;
        DataTable MakeTable<T>(List<T> records) where T : class;

        object[] ToRowDataTable(object obj);
    }

    public class DataTableToBulk : IDataTableToBulk
    {
        public DataTable MakeTable<T>(T record) where T : class
        {
            List<T> massaDados = new List<T>();
            massaDados.Add(record);

            return MakeTable(massaDados);
        }

        public DataTable MakeTable<T>(List<T> records) where T : class
        {
            try
            {
                if (!records.Any())
                {
                    return null;
                }

                DataTable table = new DataTable();
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                }

                foreach (T record in records)
                {
                    object[] values = new object[properties.Length];

                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(record, null);
                    }

                    table.Rows.Add(values);
                }
                return table;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object[] ToRowDataTable(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(obj, null);
            }
            return values;
        }
    }
}
