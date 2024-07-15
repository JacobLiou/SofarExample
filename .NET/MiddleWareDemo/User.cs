using System.ComponentModel.DataAnnotations;

namespace MiddleWareDemo
{
    [TableName("Users")]
    [PrimaryKey("UserId", AutoIncrement = true)]

    public class User
    {
        public int UserId { get; set; }


    }
}
