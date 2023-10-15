using Dapper;
using Npgsql;
using workersView.Interface;


namespace workersView.Data
{
    public class DataRepo : IDataRepo
    {
        private readonly IConfiguration configuration;

        public DataRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<T> Get<T>(string tableName, string connectionId, long id)
        {
            using var con = new NpgsqlConnection(configuration.GetConnectionString(connectionId));
            await con.OpenAsync();
            var sql = $"SELECT * FROM {tableName} WHERE id={id};";
            //var worker = await con.QueryAsync<T>(sql);
            var worker = await con.QueryFirstOrDefaultAsync<T>(sql);
            return worker;
        }
        public async Task<List<T>> GetUserReportByUniq<T>(string tableName, string connectionId, long uniq)
        {
            using var con = new NpgsqlConnection(configuration.GetConnectionString(connectionId));
            await con.OpenAsync();
            var sql = $"SELECT * FROM {tableName} WHERE uniq={uniq};";
            var list = await con.QueryAsync<T>(sql);
            return list.ToList();
        }
        public async Task<List<T>> GetUsers<T>(string tableName, string connectionId)
        {
            using var con = new NpgsqlConnection(configuration.GetConnectionString(connectionId));
            await con.OpenAsync();
            var sql = $"SELECT * FROM {tableName};";
            var list = await con.QueryAsync<T>(sql);
            return list.ToList();
        }
        public async Task<List<T>> GetUsersStatus<T>(string connectionId)
        {
            using var con = new NpgsqlConnection(configuration.GetConnectionString(connectionId));
            await con.OpenAsync();
            var sql = $"SELECT workerinfo.uniq,workerinfo.name,project,workerinfo.workerstatus FROM rezofwork LEFT JOIN workerinfo ON rezofwork.uniq=workerinfo.uniq WHERE rezofwork.id=(SELECT MAX(id) FROM rezofwork WHERE rezofwork.uniq=workerinfo.uniq) ORDER BY workerstatus DESC;";
            var list = await con.QueryAsync<T>(sql);
            return list.ToList();
        }
        public async Task<List<T>> GetUsersSalarySumPerDate<T>(string tableName, string connectionId, string dataDo, string dataPosle)
        {
            using var con = new NpgsqlConnection(configuration.GetConnectionString(connectionId));
            await con.OpenAsync();
            var sql = $"SET datestyle = dmy;SELECT uniq,name, SUM(salary) FROM {tableName} WHERE tbegin>='{dataDo}' AND tend<='{dataPosle}' GROUP BY uniq,name;";
            var list = await con.QueryAsync<T>(sql);
            return list.ToList();
        }

        public async Task UpdateUser<T>(string tableName, string connectionId, T user)
        {
            using var con = new NpgsqlConnection(configuration.GetConnectionString(connectionId));
            await con.OpenAsync();
            var sql = $"UPDATE {tableName} SET uniq=@uniq, name=@name, price=@price WHERE id=@id;";
            var list = await con.ExecuteAsync(sql,user);
            
        }
    }
}
