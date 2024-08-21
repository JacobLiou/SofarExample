import pyodbc

# 连接到MSSQL数据库
def connect_to_mssql():
    # connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={server};DATABASE={database};UID={username};PWD={password}'
    
    # 设置连接字符串
    connection_string = (
        r'DRIVER={ODBC Driver 17 for SQL Server};'
        r'SERVER=(localdb)\MSSQLLocalDB;'  # 指定 LocalDB 实例
        r'DATABASE=MSSQLLocalDB;'       # 替换为你的数据库名称
        r'Trusted_Connection=yes;'
    )

    connection = pyodbc.connect(connection_string)
    return connection

# 执行查询并获取结果
def execute_query(connection, query):
    cursor = connection.cursor()
    cursor.execute(query)
    result = cursor.fetchall()
    return result

# 关闭连接
def close_connection(connection):
    connection.close()

# 主函数
def main():
    # server = '(localdb)\\MSSQLLocalDB'
    # database = 'your_database_name'
    # username = 'your_username'
    # password = 'your_password'

    # 连接到MSSQL数据库
    connection = connect_to_mssql()

    # 执行查询并获取结果
    query = 'SELECT * FROM your_table_name'
    result = execute_query(connection, query)

    # 打印结果
    for row in result:
        print(row)

    # 关闭连接
    close_connection(connection)

if __name__ == '__main__':
    main()




