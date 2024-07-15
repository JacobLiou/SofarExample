public static class DbFactory
{
    public static DatabaseFactory dbFactory;

    public static Database GetDatabase()
    {
        return dbFactory.GetDatabase();
    }

      static DbFactory()
    {        
        dbFactory = DatabaseFactory.Config(x =>
        {
            // 也可以在这里配置实体的映射关系
            x.UsingDatabase(() => new Database(
                "Data Source=mydatabase.db;", 
                DatabaseType.SQLite, 
                SqliteFactory.Instance)
            );             
        });
        InitDB();
    }

    static void InitDB()
    {
        // 创建数据库文件
        File.Create("mydatabase.db").Close();
        // 创建表
        using (IDatabase db = dbFactory.GetDatabase())
        {
            db.Execute(@"
                -- 创建Users表
                CREATE TABLE IF NOT EXISTS Users (
                    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Email TEXT,
                    CreateTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    UpdateTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                );
                -- 创建触发器，在Users 表上的数据更新后自动更新 UpdateTime 字段
                CREATE TRIGGER IF NOT EXISTS update_user_time
                AFTER UPDATE OF Email, CreateTime ON Users
                BEGIN
                    UPDATE Users SET UpdateTime = CURRENT_TIMESTAMP WHERE rowid = NEW.rowid;
                END;"
            );
        }
}